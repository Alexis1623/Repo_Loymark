using Prueba_Tecnica_Loymark.Back_end;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_Tecnica_Loymark.Front_end
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Login_us obj = new Login_us();
            obj.Registrarse();
           
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            if (tbUsuario.Text == "" || tbClave.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacíos!";
            }
            else
            {
                string patron = "Loymark";
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Validar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Session["usuariologueado"] = dr["Id"].ToString();
                            Response.Redirect("/Front-end/Index.aspx");
                        }
                        else
                        {
                            lblError.Text = "Usuario o contraseña incorrecta!";
                        }
                        con.Close();
                    }
                }
            }
        }
        }
}