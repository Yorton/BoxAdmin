using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(object request);
    }
}
