using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Prueba_Tecnica_Loymark.Front_end
{
    public partial class Imagen : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] == null)
            {
                Response.Redirect("/Front-end/Back-end/Login.aspx");
            }
            else
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("CargarImagen", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Request.QueryString["id"];
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            byte[] imagen = (byte[])dr["Imagen"];
                            Response.BinaryWrite(imagen);
                        }
                    }
                }
            }
        }
    }
}