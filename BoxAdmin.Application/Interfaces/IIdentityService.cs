using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxAdmin.Application.DTOs.Identity;
using BoxAdmin.Framework.Results;

namespace BoxAdmin.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress);
    }
}
