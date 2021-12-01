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
using Entidades;
using Datos;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Threading;
 

namespace ControlIT.Pages
{
    /// <summary>
    /// Interaction logic for ControlIP.xaml
    /// </summary>
    public partial class ControlIP : Page
    {
        DatosSQL Fuentedatos = new DatosSQL();
        public Entidades.Entidaddireccionip objEntidadIp = new Entidaddireccionip();
        Entidades.ResultadoOperacion valorderetorno = new ResultadoOperacion();
        DataTable dt = new DataTable();





        public ControlIP()
        {
            InitializeComponent();


            tbxStatus.Items.Add(string.Empty);
            tbxStatus.Items.Add("Asignado");
            tbxStatus.Items.Add("Libre");
            
                tbxPlanta.Items.Add(string.Empty);
                tbxPlanta.Items.Add("P1");
                tbxPlanta.Items.Add("P2");
                tbxPlanta.Items.Add("Mixing");
                tbxPlanta.Items.Add("ADI");


                tbxDeptArea.Items.Add(string.Empty);
                tbxDeptArea.Items.Add("Almacen");
                tbxDeptArea.Items.Add("Area de Calandra");
                tbxDeptArea.Items.Add("Bonded Seal");
                tbxDeptArea.Items.Add("Cadena de Suministro");
                tbxDeptArea.Items.Add("Calidad");
                tbxDeptArea.Items.Add("Caseta");
                tbxDeptArea.Items.Add("Compras");
                tbxDeptArea.Items.Add("Contabilidad");
                tbxDeptArea.Items.Add("Customer Service");
                tbxDeptArea.Items.Add("Direccion");
                tbxDeptArea.Items.Add("Enfermeria");
                tbxDeptArea.Items.Add("Envios");
                tbxDeptArea.Items.Add("Import-Export");
                tbxDeptArea.Items.Add("Ingenieria");
                tbxDeptArea.Items.Add("Laboratorio");
                tbxDeptArea.Items.Add("Logistica");
                tbxDeptArea.Items.Add("Mantenimiento");
                tbxDeptArea.Items.Add("MIXING");
                tbxDeptArea.Items.Add("Planeacion");
                tbxDeptArea.Items.Add("Produccion");
                tbxDeptArea.Items.Add("Recepcion");
                tbxDeptArea.Items.Add("RH");
                tbxDeptArea.Items.Add("Sistemas");
                tbxDeptArea.Items.Add("Toolcrib");
                tbxDeptArea.Items.Add("Ventas");

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            llenargrid();

           
        }

  

        private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            StackPanelFormulario.Visibility = Visibility.Visible;
            DataTable dtopen = new DataTable();
            tbxIP.Focus();
            btnEliminar.IsEnabled = true;
            btnHistorico.IsEnabled = true;
            UpdaterRegistro.IsEnabled = true;
            tbxIP.IsEnabled = false;

            try
            {
                if (myDataGrid.SelectedItem == null)
                    return;
                DataRowView dr = myDataGrid.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                objEntidadIp.ID = int.Parse(Convert.ToString(dr1.ItemArray[0]));

                dtopen = Fuentedatos.ObtenerDireccionIPporID(objEntidadIp).Tables[0];

                tbxIP.Text = dtopen.Rows[0]["IP"].ToString();
                tbxDeviceName.Text = dtopen.Rows[0]["DeviceName"].ToString();
                tbxUserName.Text = dtopen.Rows[0]["UserName"].ToString();
                tbxDeptArea.Text = dtopen.Rows[0]["DeptArea"].ToString();
                tbxPlanta.Text = dtopen.Rows[0]["Planta"].ToString();
                tbxGLPI.Text = dtopen.Rows[0]["GLPI"].ToString();
                tbxStatus.Text = dtopen.Rows[0]["STATUS"].ToString();
                dtpAssigned.Text = dtopen.Rows[0]["ASSIGNED"].ToString();
               // dtpUnassigned.Text = dtopen.Rows[0]["UNASSIGNED"].ToString();
                tbxType.Text = dtopen.Rows[0]["TYPE"].ToString();
                tbxNotas.Text = dtopen.Rows[0]["Expr1"].ToString();

                objEntidadIp.idHistorico = int.Parse(dtopen.Rows[0]["IDHISTORY"].ToString());


            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            llnearEntidadIP();
            HistoricoIP Obj = new HistoricoIP(objEntidadIp);

            Obj.Show();

        }

        private void UpdaterRegistro_Click(object sender, RoutedEventArgs e)
        {

            llnearEntidadIP();


            if (objEntidadIp.idHistorico != 0)
            {
                valorderetorno = Fuentedatos.UPdateRegistroIP(objEntidadIp);

                if (valorderetorno == ResultadoOperacion.ElementoAgregado)
                {

                    LimpiarEntidadIP();
                    StackPanelFormulario.Visibility = Visibility.Hidden;
                    llenargrid();
                }
            }
            else
                //ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;

               
                    Fuentedatos.InsertRegistroIP(objEntidadIp);
                    LimpiarEntidadIP();
                    StackPanelFormulario.Visibility = Visibility.Hidden;
                    llenargrid();
                

        }

        private void btnAgregarRegistro_Click(object sender, RoutedEventArgs e)
        {
            llnearEntidadIP();

            if (btnHistorico.IsEnabled == true)
                valorderetorno = Fuentedatos.InsertRegistroIP(objEntidadIp);
            else
                valorderetorno = Fuentedatos.InsertRegistroIPMain(objEntidadIp);

            if (valorderetorno == ResultadoOperacion.ElementoAgregado)
            {

                LimpiarEntidadIP();
                StackPanelFormulario.Visibility = Visibility.Hidden;
                llenargrid();
            }
        }

        private void llenargrid()
        {
            myDataGrid.ItemsSource = null;
            dt = Fuentedatos.ObtenerListaDireccionesIP().Tables[0];
            myDataGrid.ItemsSource = dt.DefaultView;
        }

        private void LimpiarEntidadIP()
        {
            objEntidadIp.IP = "";
            objEntidadIp.DeviceName = "";
            objEntidadIp.UserName = "";
            objEntidadIp.DeptArea = "";
            objEntidadIp.Planta = "";
            objEntidadIp.GLPI = "";
            objEntidadIp.STATUS = "";
            if (dtpAssigned.Text != "")
                objEntidadIp.ASSIGNED = DateTime.Parse(dtpAssigned.Text);
           
            objEntidadIp.TYPE = "";
            objEntidadIp.notas = "";

            tbxIP.Text = string.Empty;
            tbxDeviceName.Text = string.Empty;
            tbxUserName.Text = string.Empty;
            tbxDeptArea.Text = string.Empty;
            tbxPlanta.Text = string.Empty;
            tbxGLPI.Text = string.Empty;
            tbxStatus.Text = string.Empty;

            if (dtpAssigned.Text != "")
                objEntidadIp.ASSIGNED = DateTime.Parse(dtpAssigned.Text);

          

            tbxType.Text = string.Empty;
            tbxNotas.Text = string.Empty;


        }

        private void LimpiarEntidadIPRango()
        {
            tbxipHostIDto.Text = string.Empty;
          tbxipto.Text=string.Empty;
          tbxipfrom.Text = string.Empty;
          tbxipHostIDfrom.Text = string.Empty;

          lblResultRangeIp.Content = "Result";


        }




        private void llnearEntidadIP()
        {
            objEntidadIp.IP = tbxIP.Text;
            objEntidadIp.DeviceName = tbxDeviceName.Text;
            objEntidadIp.UserName = tbxUserName.Text;
            objEntidadIp.DeptArea = tbxDeptArea.Text;
            
            objEntidadIp.Planta = tbxPlanta.Text;

            objEntidadIp.GLPI = tbxGLPI.Text;
            objEntidadIp.STATUS = tbxStatus.Text;

            if (dtpAssigned.Text != "")
                objEntidadIp.ASSIGNED = DateTime.Parse(dtpAssigned.Text);
            else
                objEntidadIp.ASSIGNED = DateTime.Today;

          

            objEntidadIp.TYPE = tbxType.Text;
            objEntidadIp.notas = tbxNotas.Text;



        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            
            closepanel();
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender == movingObject)
            {
                double newLeft = e.GetPosition(canvas).X - firstXPos - canvas.Margin.Left;

                StackPanelFormulario.SetValue(Canvas.LeftProperty, newLeft);

                double newTop = e.GetPosition(canvas).Y - firstYPos - canvas.Margin.Top;

                StackPanelFormulario.SetValue(Canvas.TopProperty, newTop);
            }
        }

        private void MoveMouseIP(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender == movingObject)
            {
                double newLeft = e.GetPosition(canvasRango).X - firstXPosIP - canvasRango.Margin.Left;

                StackPanelFormularioRAngo.SetValue(Canvas.LeftProperty, newLeft);

                double newTop = e.GetPosition(canvasRango).Y - firstYPosIP - canvasRango.Margin.Top;

                StackPanelFormularioRAngo.SetValue(Canvas.TopProperty, newTop);
            }
        }

        private object movingObject; private object movingObjectIP;

        private double firstXPos, firstYPos;
        private double firstXPosIP, firstYPosIP;

        private void PreviewDown(object sender, MouseButtonEventArgs e)
        {
            firstXPos = e.GetPosition(StackPanelFormulario).X + 510;
            firstYPos = e.GetPosition(StackPanelFormulario).Y - 90;

            movingObject = sender;

        }

             private void PreviewDownIP(object sender, MouseButtonEventArgs e)
        {
            firstXPosIP = e.GetPosition(StackPanelFormularioRAngo).X + 510;
            firstYPosIP = e.GetPosition(StackPanelFormularioRAngo).Y - 90;

            movingObject = sender;

        }

        private void PreviewUp(object sender, MouseButtonEventArgs e)
        {
            movingObject = null;
        }
        private void PreviewUpIP(object sender, MouseButtonEventArgs e)
        {
            movingObjectIP = null;
        }

      

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                DataTable tempDt = dt.Copy();
                tempDt.Clear();
                if (tbxSearch.Text != "") // Note: txt_Search is the TextBox..
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //tempDts = dr[2].ToString();
                        if (dr[1].ToString().Contains(tbxSearch.Text))
                        {
                            tempDt.ImportRow(dr);
                        }
                    }

                    myDataGrid.ItemsSource = tempDt.DefaultView;
                }
                else
                {
                    myDataGrid.ItemsSource = dt.DefaultView;
                }

            }

        }
        private void closepanel()
        {
            StackPanelFormulario.Visibility = Visibility.Hidden;
            LimpiarEntidadIP();
        }


        private void closepanelRango()
        {
            StackPanelFormularioRAngo.Visibility = Visibility.Hidden;
            LimpiarEntidadIPRango();
            
        }

        private void tbxIP_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((TextBox)sender).MoveFocus(request);
            }

            if (e.Key == Key.Escape)
            {
                closepanel();
            }
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            StackPanelFormulario.Visibility = Visibility.Visible;
            DataTable dtopen = new DataTable();
            tbxIP.IsEnabled = true;
            btnHistorico.IsEnabled = false;
            UpdaterRegistro.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            tbxIP.Focus();

            LimpiarEntidadIP();




        }





      
        private void btnAgregarRegistroRango_Click(object sender, RoutedEventArgs e)
        {
            string generarip = ""; ResultadoOperacion agregardirecciones = ResultadoOperacion.Error;

            for (int i = int.Parse(tbxipHostIDfrom.Text); i <= int.Parse(tbxipHostIDto.Text); i++)
            {
                generarip = tbxipfrom.Text + i.ToString();

              //   agregardirecciones= Fuentedatos.CrearDireccionesIP(generarip);
                
               
            }

            LimpiarEntidadIP();

                MessageBox.Show("Direcciones Agregadas"); StackPanelFormularioRAngo.Visibility = Visibility.Hidden;
                 
                llenargrid();
            

        }



        private void tbxipfrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbxipto.Text = tbxipfrom.Text;

            if (tbxipHostIDto.Text==string.Empty)
          
            lblResultRangeIp.Content = tbxipfrom.Text + tbxipHostIDfrom.Text + " hasta " + tbxipto.Text + tbxipHostIDto.Text;


        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxipHostIDfrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxipHostIDto.Text == string.Empty)
                lblResultRangeIp.Content = tbxipfrom.Text + tbxipHostIDfrom.Text + " hasta " + tbxipto.Text + tbxipHostIDfrom.Text;
            else
                lblResultRangeIp.Content = tbxipfrom.Text + tbxipHostIDfrom.Text + " hasta " + tbxipto.Text + tbxipHostIDto.Text;
        }

        private void CloseRango_Click(object sender, RoutedEventArgs e)
        {
            closepanelRango();
        }

        private void ButtonRango_Click(object sender, RoutedEventArgs e)
        {

            StackPanelFormularioRAngo.Visibility = Visibility.Visible;
             tbxipfrom.Focus();
            LimpiarEntidadIP();



        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Esta seguro de Eliminar la direccion IP y sus dependencias?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                llnearEntidadIP();
                Fuentedatos.BorrarDireccionesIP(objEntidadIp);

                MessageBox.Show("Registro Eliminado");
                LimpiarEntidadIP();
                llenargrid();
                StackPanelFormulario.Visibility = Visibility.Hidden;
            }
            else
            {
            }


         
        }


        private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            myDataGrid.SelectAllCells();
            myDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, myDataGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            myDataGrid.UnselectAllCells();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File|*.xls";
            if (saveFileDialog.ShowDialog() == true)
                System.IO.File.WriteAllText(saveFileDialog.FileName, "a.txt");


            string destino = saveFileDialog.FileName;


            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@destino);
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();

            MessageBox.Show("Excel File created");




        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            WPFProgressBar NEWoBJ = new WPFProgressBar();
            NEWoBJ.Show();

         

            List<Thread> threads = new List<Thread>();

            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range rng = null;

            // collection of DataGrid Items

            DataTable dtExcelDataTable = new DataTable();
            dtExcelDataTable = ((DataView)myDataGrid.ItemsSource).ToTable();  

           // var dtExcelDataTable = ExcelTimeReport(txtFrmDte.Text, txtToDte.Text, strCondition);

            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
            ws.Columns.AutoFit();
            ws.Columns.EntireColumn.ColumnWidth = 25;
          

         
          

            for (int Idx = 0; Idx < dtExcelDataTable.Columns.Count; Idx++)
            {
                
                ws.Range["A1"].Offset[0, Idx].Value = dtExcelDataTable.Columns[Idx].ColumnName;
                
                 ws.Range["A1"].Offset[0, Idx].Cells.Interior.Color=Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;

               //  ws.Range["A1"].Offset[0, Idx].Cells.AutoFilter();            
                 ws.Range["A1"].Offset[0, Idx].Cells.HorizontalAlignment = HorizontalAlignment.Center;

                 ws.Range["A1"].Offset[0, Idx].Cells.Font.Color= Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;

               


            }

            // Data Rows
            for (int Idx =0; Idx < dtExcelDataTable.Rows.Count; Idx++)
            {
                  ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;
           //     ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;

                 

            }

            excel.Visible = true;
            wb.Activate();

            NEWoBJ.Close();
        }

        private void tbxPlanta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

    }
       
    
        
    
}
