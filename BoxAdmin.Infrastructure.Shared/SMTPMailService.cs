using System;
using System.Threading.Tasks;
using BoxAdmin.Application.Interfaces.Shared;

namespace BoxAdmin.Infrastructure.Shared
{
    public class SMTPMailService : IMailService
    {
        public Task SendAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}
