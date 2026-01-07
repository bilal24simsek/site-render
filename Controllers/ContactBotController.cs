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
    [Route("contactbot")]
    public class ContactBotController : Controller
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly ILogger<ContactBotController> _logger;

        public ContactBotController(IOptions<SmtpOptions> smtpOptions, ILogger<ContactBotController> logger)
        {
            _smtpOptions = smtpOptions.Value;
            _logger = logger;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] ContactBotRequest request)
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
                using var mail = new MailMessage(_smtpOptions.From!, toAddress)
                {
                    Subject = $"Yeni Demo Talebi: {request.AdSoyad}",
                    Body = body.ToString(),
                    IsBodyHtml = false
                };

                await client.SendMailAsync(mail);
                return Ok(new { message = "Gönderildi" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chat bot contact mail could not be sent.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "E-posta gönderilemedi." });
            }
        }

        private static StringBuilder BuildBody(ContactBotRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Sohbet Botu Üzerinden Yeni Mesaj");
            sb.AppendLine("-------------------------------");
            sb.AppendLine($"Ad Soyad     : {request.AdSoyad}");
            sb.AppendLine($"E-posta      : {request.Eposta}");
            sb.AppendLine($"Telefon      : {request.Telefon}");
            sb.AppendLine($"Tip          : {request.Tip}");
            sb.AppendLine($"Konu Açıklaması:");
            sb.AppendLine(request.KonuAciklamasi);
            return sb;
        }
    }

    public class ContactBotRequest
    {
        [Required]
        [MinLength(2)]
        public string AdSoyad { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Eposta { get; set; } = string.Empty;

        [Required]
        public string Telefon { get; set; } = string.Empty;

        [Required]
        public string Tip { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string KonuAciklamasi { get; set; } = string.Empty;
    }
}
