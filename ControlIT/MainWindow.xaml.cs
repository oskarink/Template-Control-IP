using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlIT

{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        DatosSQL Fuentedatos = new DatosSQL();
        public Entidaddireccionip objEntidadIp = new Entidaddireccionip();
        ResultadoOperacion valorderetorno = new ResultadoOperacion();
        DataTable dt = new DataTable();
        public EntidadUsuario ObjEntUsuario = new EntidadUsuario();
        public MainWindow(EntidadUsuario pUsuario)
        {

            InitializeComponent();
            ObjEntUsuario = pUsuario;

            
           // si quiro imagen descomento esto: 
                    //BitmapImage biImg = new BitmapImage();
                    //System.IO.MemoryStream ms = new System.IO.MemoryStream(pUsuario.foto);
                    //biImg.BeginInit();
                    //biImg.StreamSource = ms;
                    //biImg.EndInit();
                    //foto.ImageSource = biImg;
           
                   UserID.Text = ObjEntUsuario.NombreUsuario;
            //
        }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            dcPanel.Children.Clear();
         
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ControlIP":
                    fContainer.Navigate(new System.Uri("Pages/ControlIPListView.xaml", UriKind.RelativeOrAbsolute));
                   
                    break;

                case "ControlTelefonia":
                    fContainer.Navigate(new System.Uri("Pages/ControlTel.xaml", UriKind.RelativeOrAbsolute));
                    break;

                case "test":

                // fContainer.Navigate(new System.Uri("Pages/ControlTelListview.xaml", UriKind.RelativeOrAbsolute));
                    break;
                
                default:
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }


        private void ButtonLoadData_Click(object sender, RoutedEventArgs e)
        {
           // llenargrid();
        }

   
        private void llenargrid2()
        {
          //  myDataGrid.ItemsSource = null;
            dt = Fuentedatos.ObtenerListaDireccionesIP2().Tables[0];
           // myDataGrid.ItemsSource = dt.DefaultView;
        }

  

      
       
        
        
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
          //  llnearEntidadIP();
            HistoricoIP Obj = new HistoricoIP(objEntidadIp);
          
           Obj.Show();

            

        }
       
  

  

    
      
      
        private void PreviewUp(object sender, MouseButtonEventArgs e)
        {
          
        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // main1.Content = new Historico(objEntidadIp);
        }

      
    }
}
