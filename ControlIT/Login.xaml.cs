using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entidades;
using Auth;

namespace ControlIT
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    /// 
    public partial class Login : Window
    {
        public EntidadUsuario ObjEntUsuario = new EntidadUsuario();
        public ResultadoOperacion retornoLogin = new ResultadoOperacion();
       
       

        System.Data.DataTable dtopen = new System.Data.DataTable();
        public Login()
        {
            InitializeComponent();

            tbxUsuario.Focus();
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventologin();

         
       
        }

        private void eventologin()
        {
            Authentication auth = Authentication.Instance;
            ObjEntUsuario.Usuario = tbxUsuario.Text;
            ObjEntUsuario.Password = tbxPassword.Password.ToString();
            ObjEntUsuario.Fecha = DateTime.Parse(DateTime.Today.ToShortDateString());

            if (auth.Login(tbxUsuario.Text, tbxPassword.Password.ToString()))
            {
                Session.User = auth.LoggedInUser;

                if (Authorization.HasPermission("LicenceManager", Session.User.NoEmpleado))
                {
                    
                    //Byte[] data = new Byte[0];
                    //data = Session.User.Foto;
                    //System.IO.MemoryStream mem = new System.IO.MemoryStream(data);
                    //yourPictureBox.Image = Image.FromStream(mem);
                  
                  //  fs.Write(Session.User.Foto, 0, barrImg.Length);
                  //  fs.Flush();
                   // fs.Close();


                    string texto = Session.User.Nombre;
                    int posicion = texto.IndexOf(" ");
                    if (posicion == -1)
                        posicion = texto.Length;
                    string substring = Session.User.Nombre.Substring(0, posicion);
                   

                    ObjEntUsuario.Usuario = Session.User.Perfil;
                    ObjEntUsuario.foto = Session.User.Foto;
                    ObjEntUsuario.NombreUsuario = substring+" "+ Session.User.ApellidoPaterno ;
                    ObjEntUsuario.TecnicoLogin = Session.User.UsuarioRed;


                    MainWindow obj = new MainWindow(ObjEntUsuario); obj.Show();
                    this.Close();

                }




            }
            else
            {
                if (Authentication.ErrorMsg != string.Empty)
                {
                    MessageBox.Show(Authentication.ErrorMsg);
                    Authentication.ErrorMsg = string.Empty;
                }
                else
                    MessageBox.Show("Credenciales invalidas");
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //SnackbarThree.MessageQueue?.Enqueue("Chip clicked!");
            
           this.Close();
           // MainWindow.SnackbarThree.MessageQueue?.Enqueue("Chip clicked!");
        }

        private void tbxPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                eventologin();
            }
        }
    }
}
