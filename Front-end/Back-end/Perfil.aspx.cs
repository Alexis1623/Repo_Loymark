using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ASP_SP.Sources.Pages
{
    public partial class FrmPerfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuariologueado"].ToString());
            if (Session["usuariologueado"] == null)
            {
                Response.Redirect("/Front/Back-end/Login.aspx");
            }
            else
            {
                
                    using (SqlCommand cmd = new SqlCommand("Perfil", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                           
 
                            dr.Close();
                        }
                        con.Close();
                    
                }
            }
        }

        void MetodoOcultar()
        {
            if (contrasenia.Visible == false)
            {
                contrasenia.Visible = true;
                BtnGuardar.Visible = true;
                BtnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasenia.Visible = false;
                BtnGuardar.Visible = false;
                BtnCambiar.Text = "Cambiar contraseña";
                lblErrorClave.Text = "";
            }
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int tamanioarchivo;
            byte[] imagen = FUImage.FileBytes;
            tamanioarchivo = int.Parse(FUImage.FileContent.Length.ToString());
            if (tamanioarchivo >= 2097151000)
            {
                lblError.Text = "El tamaño de la imagen debe ser menor a 10 Mb!";
            }
            else if (FUImage.HasFile)
            {
                SqlCommand cmd = new SqlCommand("CambiarImagen", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = imagen;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                lblError.Text = "";
                con.Close();
            }
            else
            {
                lblError.Text = "No se ha cargado una imagen de perfil nueva!";
            }
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            MetodoOcultar();
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("Eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("usuariologueado");
                    Response.Redirect("/Front/Back-end/Login.aspx");
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string contraseniasinverificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

            if (tbClave.Text == "" || tbClave2.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacíos!";
            }
            else if (tbClave.Text != tbClave2.Text)
            {
                lblError.Text = "Los contraseñas no coinciden!";
            }
            else if (!letras.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Los contraseña debe contener letras!";
            }
            else if (!numeros.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Los contraseña debe contener números!";
            }
            else if (!especiales.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Los contraseña debe contener caracteres especiales!";
            }
            else
            {
                try
                {
                    using (con)
                    {

                        using (SqlCommand cmd = new SqlCommand("Cambiar_Contrasenia", con))
                        {
                            string patron = "Loymark";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = tbClave.Text;
                            cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                            cmd.Parameters.Add("@ID_User", SqlDbType.VarChar).Value = tbuser.Text;
                            cmd.Parameters.Add("@C_date", SqlDbType.Date).Value = DateTime.Now.ToString("dd/MM/yyyy");
                            cmd.Parameters.Add("@Actividad", SqlDbType.VarChar).Value = "Cambio de contraseña";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MetodoOcultar();
                            lblErrorClave.Text = "";
                        }
                    }

                }
                
                catch (Exception ex)
                {
                    lblErrorClave.Text = ex.Message;
                }
                

            }
        }
    }
}