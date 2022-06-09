using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_Tecnica_Loymark.Back_end
{
    public class Login_us
    {


        public void Registrarse()
        {

            HttpContext.Current.Response.Redirect("Registro.aspx", true);


        }
    }
}