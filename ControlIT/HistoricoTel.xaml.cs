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
using Datos;
using System.Data;


namespace ControlIT
{
    /// <summary>
    /// Interaction logic for Historico.xaml
    /// </summary>
    public partial class HistoricoTel : Window
    {
        DatosSQL Fuentedatos = new DatosSQL();
        public EntidadTelefonia objEntidadIpp;// = new Entidaddireccionip();
        
        ResultadoOperacion valorderetorno = new ResultadoOperacion();
        DataTable dt = new DataTable();
        public string IP;

        public HistoricoTel(EntidadTelefonia objEntidadIpp)
        {
            InitializeComponent();

            dt = Fuentedatos.ObteneronsultaTBHistoricoporLineas(objEntidadIpp).Tables[0];
                       myDataGrid.ItemsSource = dt.DefaultView;

        }
    }
}
