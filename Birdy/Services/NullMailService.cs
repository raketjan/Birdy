using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdy.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this._logger = logger;
        }

        public void SendMail(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
