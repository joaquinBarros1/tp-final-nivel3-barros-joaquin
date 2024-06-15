using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using dominio;

namespace AccesoDatos
{
    public class Validaciones
    {
        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                {
                    return false;
                }
                else
                    return true;
            }

            return false;
        }
    }
}
