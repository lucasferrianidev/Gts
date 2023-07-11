using Microsoft.AspNetCore.Identity;

namespace GstAuth.Models
{
    public class Usuario : IdentityUser
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public Usuario() : base() { }
    }
}
