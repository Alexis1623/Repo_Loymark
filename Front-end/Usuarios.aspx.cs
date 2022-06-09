using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Prueba_Tecnica_Loymark.Front_end
{
    public partial class Usuarios : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Perfil", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        dr.Read();
                        this.lblUsuario.Text = dr["Nombre"].ToString() + ", " + dr["Apellido"].ToString();
                        imgPerfil.ImageUrl = "/Front-end/Imagen.aspx?id=" + id;
                    }
                }
            }
            else
            {
                Response.Redirect("/Front-end/Back-end/Login.aspx");
            }
        }

        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/Front-end/Back-end/Perfil.aspx");
        }

        protected void Salir(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("/Front-end/Back-end/Login.aspx");
        }
    }
}