using Prueba_Tecnica_Loymark.Back_end;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_Tecnica_Loymark.Archivos.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public void Registrar()
        {
            int tamanioimagen = int.Parse(FUImage.FileContent.Length.ToString());
            string contraseniasinverificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            con.Open();
            SqlCommand usuario = new SqlCommand("ContarUsuario", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            usuario.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
            int user = Convert.ToInt32(usuario.ExecuteScalar());
            if (tbNombres.Text == "" || tbApellidos.Text == "" || tbCorreo.Text == "" || tbFecha.Text == "" || tbTelefono.Text == "" || tbPais.Value == "" || tbInfo.Value == "" || tbUsuario.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacíos!";
            }
            else if (user >= 1)
            {
                lblError.Text = "El usuario " + tbUsuario.Text + " ya existe!";
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
            else if (!FUImage.HasFile)
            {
                lblError.Text = "No se ha cargado una imagen de perfil!";
            }
            else if (tamanioimagen >= 2097151000)
            {
                lblError.Text = "El tamaño de la imagen no puede ser mayor a 10 Mb!";
            }
            else
            {
                byte[] imagen = FUImage.FileBytes;
                string patron = "Loymark";
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Registroo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombres.Text;
                        cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = tbApellidos.Text;
                        cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbCorreo.Text;
                        cmd.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date).Value = tbFecha.Text;
                        cmd.Parameters.Add("@Telefono", SqlDbType.Int).Value = tbTelefono.Text;
                        cmd.Parameters.Add("@Pais_R", SqlDbType.VarChar).Value = tbPais.Value;
                        cmd.Parameters.Add("@Info", SqlDbType.Bit).Value = tbInfo.Value; ;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                        cmd.Parameters.Add("@ID_User", SqlDbType.VarChar).Value = tbNombres.Text;
                        cmd.Parameters.Add("@C_date", SqlDbType.Date).Value = DateTime.Now.ToString("dd/MM/yyyy");
                        cmd.Parameters.Add("@Actividad", SqlDbType.VarChar).Value = "Registro de Usuario" ;
                        cmd.ExecuteNonQuery();

                    }
                    con.Close();
                    Response.Redirect("/Front-end/Back-end/Login.aspx");


                }
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Registrar();
            
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Registro_us obj = new Registro_us();
            obj.Cancelar();
        }
    }
}