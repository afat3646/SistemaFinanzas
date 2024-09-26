using System;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sistema{
    public partial class Conexion_IncioDeSesion :  Form{

        //inicializacion de los datos a solicitar
        private TextBox txtcorreo;
        private TextBox txtcontraseña;
        private Button btnIniciarSesion;
        //inicializacion y muestralizacion de elementos de pantalla
            private void InitializeLoginComponents(){

                Label lblCorreo = new Label();
                lblCorreo.Text = "Correo:";
                lblCorreo.Location = new System.Drawing.Point(100, 30);
                this.Controls.Add(lblCorreo);

                this.txtcorreo = new System.Windows.Forms.TextBox();
                this.txtcontraseña = new System.Windows.Forms.TextBox();
                this.btnIniciarSesion = new System.Windows.Forms.Button();
                //poner correo configuracion
                


                this.txtcorreo.Location = new System.Drawing.Point(100, 50);
                this.txtcorreo.Name = "txtCorreo";
                this.txtcorreo.Size = new System.Drawing.Size(200, 23);
                this.Controls.Add(this.txtcorreo);

                //poner contraseña configuracion
                Label lblContraseña = new Label();
                lblContraseña.Text = "contraseña:";
                lblContraseña.Location = new System.Drawing.Point(100, 80);
                
                this.Controls.Add(lblContraseña);

                this.txtcontraseña.Location = new System.Drawing.Point(100, 100);
                this.txtcontraseña.Name = "txtContraseña";
                this.txtcontraseña.PasswordChar = '*';
                this.txtcontraseña.Size = new System.Drawing.Size(200, 23);
                this.Controls.Add(this.txtcontraseña);

                //boton para iniciar sesion configuracion
                this.btnIniciarSesion.Location = new System.Drawing.Point(150, 150);
                this.btnIniciarSesion.Name = "btnIniciarSesion";
                this.btnIniciarSesion.Size = new System.Drawing.Size(100, 30);
                this.btnIniciarSesion.Text = "Iniciar sesión";
                this.btnIniciarSesion.UseVisualStyleBackColor = true;
                this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
                this.Controls.Add(this.btnIniciarSesion);

                //pantalla inicio de sesion
                this.ClientSize = new System.Drawing.Size(400, 250);
                this.Text = "Inicio de sesión";
            }
            //meotodos para iniciar y validar la sesion
            private bool ProbarConexion(){
                string connectionString = "Server=localhost;Database=FinanzasBaseDeDatos;User ID=root;Password=Fernaal1;";
                try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión a la base de datos fue exitosa.");
                    return true; 
                }
            }
            catch (Exception)
            {
                return false; 
            }
            }
            private void btnIniciarSesion_Click(Object sender, EventArgs e){
                string correo = txtcorreo.Text;
                string contraseña = txtcontraseña.Text;
                if (ValidarCredenciales(correo, contraseña))
                {
                MessageBox.Show("Inicio de sesión exitoso");
                Cuenta cuentactr = new Cuenta(correo);
                cuentactr.Show();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos");
                }
            }
            private bool ValidarCredenciales(string correo, string contraseña){
                 string connectionString = "Server=localhost;Database=FinanzasBaseDeDatos;User ID=root;Password=Fernaal1;";
                 bool esValido = false;
                 try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para verificar si el usuario existe con las credenciales proporcionadas
                    string query = "SELECT COUNT(1) FROM Usuario WHERE Correo = @Correo AND Contraseña = @Contraseña";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Correo", correo);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        // Ejecutar la consulta y verificar si existe al menos un resultado
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        esValido = (count == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
            }
            return esValido;

            }

        public Conexion_IncioDeSesion(){
            
            if(!ProbarConexion()){
                MessageBox.Show("No se pudo conectar a la base de datos. Cerrando aplicacion");
                Application.Exit();
            }
            else{
                InitializeLoginComponents();
            }
        }
        
           
            
            
        }

    }

