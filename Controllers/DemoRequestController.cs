using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sitem.Web.Settings;

namespace Sitem.Web.Controllers
{
    [ApiController]
    [Route("demorequest")]
    public class DemoRequestController : Controller
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly ILogger<DemoRequestController> _logger;

        public DemoRequestController(IOptions<SmtpOptions> smtpOptions, ILogger<DemoRequestController> logger)
        {
            _smtpOptions = smtpOptions.Value;
            _logger = logger;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] DemoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(_smtpOptions.Host) || string.IsNullOrWhiteSpace(_smtpOptions.From))
            {
                _logger.LogError("SMTP configuration is missing host or from address.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "E-posta gönderimi yapılandırılmamış." });
            }

            try
            {
                using var client = new SmtpClient(_smtpOptions.Host, _smtpOptions.Port == 0 ? 25 : _smtpOptions.Port)
                {
                    EnableSsl = _smtpOptions.EnableSsl
                };

                if (!string.IsNullOrWhiteSpace(_smtpOptions.Username))
                {
                    client.Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password);
                }

                var body = BuildBody(request);
                var toAddress = string.IsNullOrWhiteSpace(_smtpOptions.To) ? _smtpOptions.From! : _smtpOptions.To!;
                
                // Gmail'in "ben" etiketini kırmak ve direkt mail listesinde müşteriyi görmek için:
                // 1. Gönderen ismine müşteriyi yazıyoruz (Adres yine sizin mailiniz kalmalı).
                var fromAddress = new MailAddress(_smtpOptions.From!, $"{request.AdSoyad} | {request.Eposta}");

                using var mail = new MailMessage(fromAddress, new MailAddress(toAddress))
                {
                    // 2. Konu satırının en başına müşterinin adını ekliyoruz.
                    // Bu sayede Gmail listesinde "ben" yazsa bile hemen yanında ismi görürsünüz.
                    Subject = $"[TALEP] {request.AdSoyad} - {request.Urun}",
                    Body = body.ToString(),
                    IsBodyHtml = false
                };

                mail.ReplyToList.Add(new MailAddress(request.Eposta, request.AdSoyad));

                await client.SendMailAsync(mail);
                _logger.LogInformation("Demo request email sent successfully to {ToAddress} from {FromName}", toAddress, request.AdSoyad);
                return Ok(new { message = "Demo talebiniz başarıyla gönderildi!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Demo request email could not be sent.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "E-posta gönderilemedi. Lütfen daha sonra tekrar deneyin." });
            }
        }

        private static StringBuilder BuildBody(DemoRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Yeni Demo Talebi");
            sb.AppendLine("=====================================");
            sb.AppendLine($"Ad Soyad        : {request.AdSoyad}");
            sb.AppendLine($"E-posta         : {request.Eposta}");
            sb.AppendLine($"Telefon         : {request.Telefon}");
            sb.AppendLine($"Seçilen Ürün    : {request.Urun}");
            if (!string.IsNullOrWhiteSpace(request.Notlar))
            {
                sb.AppendLine();
                sb.AppendLine("Müşteri Notu:");
                sb.AppendLine(request.Notlar);
            }
            sb.AppendLine();
            sb.AppendLine("Lütfen müşteri ile en kısa sürede iletişime geçiniz.");
            return sb;
        }
    }

    public class DemoRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Ad Soyad en az 2 karakter olmalıdır.")]
        public string AdSoyad { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Eposta { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; } = string.Empty;

        [Required]
        public string Urun { get; set; } = string.Empty;

        public string? Notlar { get; set; }
    }
}
