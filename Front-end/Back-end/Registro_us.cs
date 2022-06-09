using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Prueba_Tecnica_Loymark.Back_end
{
    public class Registro_us
    {


        public void Cancelar()
        {

            HttpContext.Current.Response.Redirect("Login.aspx", true);
        

        }




    }


}