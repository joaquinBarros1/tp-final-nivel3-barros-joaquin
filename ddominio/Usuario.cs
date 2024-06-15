using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public Usuario() { }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool TipoUsuario { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string ImagenPerfil { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Usuario(string Email, string Password, bool admin)
        {
            this.Email = Email;
            this.Password = Password;
            TipoUsuario = admin;
        }

        public Usuario(int id)
        {
            Id = id;
        }
    }
}
