using System;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace  sistema
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public partial class Cuenta: Form{

    //inicializacion de los datos a solicitar
    private Label lblTituloNombres;
    private Label lblTituloApellidos;
    private Label lblTituloDireccion;
    private Label lblTituloTelefono;
    private Label lblTituloCorreo;
    private Label lblNombres;
    private Label lblApellidos;
    private Label lblDireccion;
    private Label lblTelefono;
    private Label lblCorreo;
        private string correoDeUsuario;
        public Cuenta(string correo){
            InitializeComponent();
            this.correoDeUsuario = correo;
            CargarInformacion();
        }

        //metodo para cargar la informacion de la base de datos
        private void CargarInformacion(){
             string connectionString = "Server=localhost;Database=FinanzasBaseDeDatos;User ID=root;Password=Fernaal1;";
             try{
                using(MySqlConnection connection = new MySqlConnection(connectionString)){
                    connection.Open();
                    string query = "SELECT Nombres, Apellidos, Direccion, Telefono FROM Usuario WHERE Correo = @Correo";
                    
                    using(MySqlCommand command = new MySqlCommand(query, connection)){
                        command.Parameters.AddWithValue("@Correo", correoDeUsuario);
                        using(MySqlDataReader reader = command.ExecuteReader()){
                            if(reader.Read()){
                                lblNombres.Text = reader["Nombres"].ToString();
                                lblApellidos.Text = reader["Apellidos"].ToString();
                                lblDireccion.Text = reader["Direccion"].ToString();
                                lblTelefono.Text = reader["Telefono"].ToString();
                                lblCorreo.Text = correoDeUsuario;
                            }
                        }
                        

                        }
                    }
                }catch(Exception ex){
                    //excepcion de error
                    MessageBox.Show("Erros al cargar la informacion");
                }
             
        }
        //Muestralizacion de los datos extraidos
        private void InitializeComponent(){
        
        this.lblTituloNombres = new Label();
        this.lblTituloApellidos = new Label();
        this.lblTituloDireccion = new Label();
        this.lblTituloTelefono = new Label();
        this.lblTituloCorreo = new Label();

    
        this.lblNombres = new Label();
        this.lblApellidos = new Label();
        this.lblDireccion = new Label();
        this.lblTelefono = new Label();
        this.lblCorreo = new Label();

    
        this.lblTituloNombres.Text = "Nombres:";
        this.lblTituloNombres.Location = new System.Drawing.Point(20, 20);
        this.lblTituloNombres.Size = new System.Drawing.Size(100, 20);
    
        this.lblTituloApellidos.Text = "Apellidos:";
        this.lblTituloApellidos.Location = new System.Drawing.Point(20, 50);
        this.lblTituloApellidos.Size = new System.Drawing.Size(100, 20);
    
        this.lblTituloDireccion.Text = "Dirección:";
        this.lblTituloDireccion.Location = new System.Drawing.Point(20, 80);
        this.lblTituloDireccion.Size = new System.Drawing.Size(100, 20);
    
        this.lblTituloTelefono.Text = "Teléfono:";
        this.lblTituloTelefono.Location = new System.Drawing.Point(20, 110);
        this.lblTituloTelefono.Size = new System.Drawing.Size(100, 20);
    
        this.lblTituloCorreo.Text = "Correo:";
        this.lblTituloCorreo.Location = new System.Drawing.Point(20, 140);
        this.lblTituloCorreo.Size = new System.Drawing.Size(100, 20);

    
        this.lblNombres.Location = new System.Drawing.Point(130, 20);
        this.lblNombres.Size = new System.Drawing.Size(300, 20);
    
        this.lblApellidos.Location = new System.Drawing.Point(130, 50);
        this.lblApellidos.Size = new System.Drawing.Size(300, 20);
    
        this.lblDireccion.Location = new System.Drawing.Point(130, 80);
        this.lblDireccion.Size = new System.Drawing.Size(300, 20);
    
        this.lblTelefono.Location = new System.Drawing.Point(130, 110);
        this.lblTelefono.Size = new System.Drawing.Size(300, 20);
    
        this.lblCorreo.Location = new System.Drawing.Point(130, 140);
        this.lblCorreo.Size = new System.Drawing.Size(300, 20);

    
        this.Controls.Add(this.lblTituloNombres);
        this.Controls.Add(this.lblNombres);
    
        this.Controls.Add(this.lblTituloApellidos);
        this.Controls.Add(this.lblApellidos);
    
        this.Controls.Add(this.lblTituloDireccion);
        this.Controls.Add(this.lblDireccion);
    
        this.Controls.Add(this.lblTituloTelefono);
        this.Controls.Add(this.lblTelefono);
    
        this.Controls.Add(this.lblTituloCorreo);
        this.Controls.Add(this.lblCorreo);

        this.ClientSize = new System.Drawing.Size(400, 250);
        this.Text = "Cuenta";

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}


