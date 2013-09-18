using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL
{
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string TelefoneResidencial { get; set; }

    }
}
