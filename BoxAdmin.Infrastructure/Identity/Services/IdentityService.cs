using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BoxAdmin.Application.DTOs.Identity;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Interfaces;
using BoxAdmin.Framework.Results;

namespace BoxAdmin.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly JWTSettings _jwtSettings;

        public IdentityService(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Result<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress)
        {
            var response = new TokenResponse();

            // 驗證帳密
            // throw new Exception("xxxxxxxxx");

            JwtSecurityToken jwtSecurityToken = GenerateJWToken(null, ipAddress);
            response.Id = request.Email;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.IssuedOn = jwtSecurityToken.ValidFrom;
            response.ExpiresOn = jwtSecurityToken.ValidTo;
            response.Email = request.Email;
            response.UserName = "UserName";

            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;

            return await Result<TokenResponse>.SuccessAsync(response);
        }

        private JwtSecurityToken GenerateJWToken(object user, string ipAddress)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, "Email"),
                new Claim("uid", "user"),
                new Claim("first_name", "FirstName"),
                new Claim("last_name", "LastName"),
                new Claim("ip", ipAddress)
            };
            return JWTGeneration(claims);
        }

        private JwtSecurityToken JWTGeneration(IEnumerable<Claim> claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
