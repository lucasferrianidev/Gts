using System.ComponentModel.DataAnnotations;

namespace Gst.Models
{
    public class Ferramenta
    {
        public int CdFerramenta { get; set; }
        public int CdProfissional { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public virtual Profissional Profissional { get; set; }
    }
}
