using GstAuth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GstAuth.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Usuario usuario)
        {
            // 1º Passo preencher o token com as claims (reivindicações)
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim("role", usuario.Role),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            // 2º Passo: gerar a chave que será usada nas signInCredentials
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            // 3º Passo: gerar as signInCredentials
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // 4º Passo: criar o token
            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddMinutes(10), // expira em 10 minutos
                    claims: claims,
                    signingCredentials: signingCredentials
                );

            // 5º Passo: retornar o token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}