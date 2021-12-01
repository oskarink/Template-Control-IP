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
using Microsoft.Win32;
using System.Threading;

namespace ControlIT.Pages
{
    /// <summary>
    /// Interaction logic for ControlIP.xaml
    /// </summary>
    public partial class ControlTel : Page
    {
        DatosSQL Fuentedatos = new DatosSQL();
        public EntidadTelefonia objEntidadTel = new EntidadTelefonia();
        Entidades.ResultadoOperacion valorderetorno = new ResultadoOperacion();
        DataTable dt = new DataTable();

        public ControlTel()
        {
            InitializeComponent();

            tbxPlanta.Items.Add("P1");
            tbxPlanta.Items.Add("P2");
            tbxPlanta.Items.Add("Mixing");
            tbxPlanta.Items.Add("ADI");
        }

        private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            StackPanelFormulario.Visibility = Visibility.Visible; tbxLinea.Focus();
            DataTable dtopen = new DataTable();

            btnHistorico.IsEnabled = true;
            UpdaterRegistro.IsEnabled = true;
            tbxLinea.IsEnabled = false;

            try
            {
                if (myDataGrid.SelectedItem == null)
                    return;
                DataRowView dr = myDataGrid.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                objEntidadTel.ID = int.Parse(Convert.ToString(dr1.ItemArray[0]));

                dtopen = Fuentedatos.ObtenerDireccionIPporID2(objEntidadTel).Tables[0];

                      //  tbxLinea.Text= dtopen.Rows[0]["ID"].ToString();;
                        tbxPlanta.Text= dtopen.Rows[0]["Planta"].ToString();;
                        tbxCuenta.Text= dtopen.Rows[0]["Cuenta"].ToString();
                        tbxNoempleado.Text= dtopen.Rows[0]["NoEmpleado"].ToString();
                        tbxPuesto.Text= dtopen.Rows[0]["Puesto"].ToString();
                        tbxNombre.Text= dtopen.Rows[0]["Nombre"].ToString();
                        tbxArea.Text= dtopen.Rows[0]["Area"].ToString();
                        tbxPlan.Text= dtopen.Rows[0]["Plan"].ToString();
                        tbxMinmexeuacan.Text= dtopen.Rows[0]["MinMEXEUACAN"].ToString();
                        tbxminsmexeucan.Text= dtopen.Rows[0]["MNSMEXEUACAN"].ToString();
                        tbxLinea.Text = dtopen.Rows[0]["Linea"].ToString();

                        tbxDatosMeeucan.Text= dtopen.Rows[0]["DatosMEXEUACAN"].ToString();
                        tbxDatosTotconpromo.Text= dtopen.Rows[0]["DatosTotCONPROMOD"].ToString();
                        tbxRedessocialesmex.Text= dtopen.Rows[0]["RedesSocialesMex"].ToString();
                        tbxRenta.Text= dtopen.Rows[0]["Renta"].ToString();
                        tbxMesesRestantes.Text= dtopen.Rows[0]["MesesRestantes"].ToString();
                        tbxMarca.Text= dtopen.Rows[0]["Marca"].ToString();
                        tbxModelo.Text= dtopen.Rows[0]["Modelo"].ToString();
                        tbxNumParte.Text= dtopen.Rows[0]["NumParte"].ToString();
                        tbxPrecio.Text= dtopen.Rows[0]["Precio"].ToString();
                        tbxNserie.Text= dtopen.Rows[0]["Nserie"].ToString();
                        tbxImei.Text= dtopen.Rows[0]["IMEI"].ToString();
                        tbxNotas.Text = dtopen.Rows[0]["Expr1"].ToString();
                                 
                objEntidadTel.IdHistorico = int.Parse(dtopen.Rows[0]["IDHISTORY"].ToString());





              
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            llnearEntidadLinea();
            HistoricoTel Obj = new HistoricoTel(objEntidadTel);

            Obj.Show();
        }

        private void UpdaterRegistro_Click(object sender, RoutedEventArgs e)
        {

            llnearEntidadLinea();

            valorderetorno = Fuentedatos.UPdateRegistroLineas(objEntidadTel);

            if (valorderetorno == ResultadoOperacion.ElementoAgregado)
            {

                LimpiarEntidadIP();
                StackPanelFormulario.Visibility = Visibility.Hidden;
                llenargrid();
            }
            else
                //ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;

                if (valorderetorno == ResultadoOperacion.Error)
                {
                    Fuentedatos.InsertRegistroLinea(objEntidadTel);
                    LimpiarEntidadIP();
                    StackPanelFormulario.Visibility = Visibility.Hidden;
                    llenargrid();
                }

        }

        private void btnAgregarRegistro_Click(object sender, RoutedEventArgs e)
        {
            llnearEntidadLinea();
           
            if (btnHistorico.IsEnabled == true)
                valorderetorno = Fuentedatos.InsertRegistroLinea(objEntidadTel);
            else
                valorderetorno = Fuentedatos.InsertRegistroLineaMain(objEntidadTel);


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
            dt = Fuentedatos.ObtenerListaDireccionesIP2().Tables[0];
            myDataGrid.ItemsSource = dt.DefaultView;

           
        }

        private void LimpiarEntidadIP()
        {
            
      
            if (dtpAssigned.Text != "")
                objEntidadTel.ASSIGNED = DateTime.Parse(dtpAssigned.Text);
            if (dtpUnassigned.Text != "")
                objEntidadTel.UNASSIGNED = DateTime.Parse(dtpUnassigned.Text);

            tbxLinea.Text = string.Empty;
            tbxPlanta.Text = string.Empty;
            tbxCuenta.Text = string.Empty;
            tbxNoempleado.Text = string.Empty;
            tbxPuesto.Text = string.Empty;
            tbxNombre.Text = string.Empty;
            tbxArea.Text = string.Empty;
            tbxPlan.Text = string.Empty;
            tbxMinmexeuacan.Text = string.Empty;
            tbxminsmexeucan.Text = string.Empty;


            tbxDatosMeeucan.Text = string.Empty;
            tbxDatosTotconpromo.Text = string.Empty;
            tbxRedessocialesmex.Text = string.Empty;
            tbxRenta.Text = string.Empty;
            tbxMesesRestantes.Text = string.Empty;
            tbxMarca.Text = string.Empty;
            tbxModelo.Text = string.Empty;
            tbxNumParte.Text = string.Empty;
            tbxPrecio.Text = string.Empty;
            tbxNserie.Text = string.Empty;
            tbxImei.Text = string.Empty;


            if (dtpAssigned.Text != "")
                objEntidadTel.ASSIGNED = DateTime.Parse(dtpAssigned.Text);

            if (dtpUnassigned.Text != "")
                objEntidadTel.UNASSIGNED = DateTime.Parse(dtpUnassigned.Text);

        
            tbxNotas.Text = string.Empty;


        }

    
        
   

        private void llnearEntidadLinea()
        {
          

            if (dtpAssigned.Text != "")
                objEntidadTel.ASSIGNED = DateTime.Parse(dtpAssigned.Text);
            else
                objEntidadTel.ASSIGNED = DateTime.Today;

            if (dtpUnassigned.Text != "")
                objEntidadTel.UNASSIGNED = DateTime.Parse(dtpUnassigned.Text);
            else
                objEntidadTel.ASSIGNED = DateTime.Today;

     


            objEntidadTel.Linea=tbxLinea.Text;
            objEntidadTel.Planta =tbxPlanta.Text;
            objEntidadTel.Cuenta =tbxCuenta.Text;
            objEntidadTel.NoEmpleado =tbxNoempleado.Text;
            objEntidadTel.Puesto =tbxPuesto.Text;
            objEntidadTel.Nombre =tbxNombre.Text;
            objEntidadTel.Area =tbxArea.Text;
            objEntidadTel.Plan =tbxPlan.Text;
            objEntidadTel.MinMEXEUACAN =tbxMinmexeuacan.Text;
            objEntidadTel.MNSMEXEUACAN =tbxminsmexeucan.Text;


            objEntidadTel.DatosMEXEUACAN =tbxDatosMeeucan.Text;
            objEntidadTel.DatosTotCONPROMOD =tbxDatosTotconpromo.Text;
            objEntidadTel.RedesSocialesMex =tbxRedessocialesmex.Text;
            objEntidadTel.RedesSocialesMex =tbxRenta.Text;
            objEntidadTel.MesesRestantes =tbxMesesRestantes.Text;
            objEntidadTel.Marca =tbxMarca.Text;
            objEntidadTel.Modelo =tbxModelo.Text;
            objEntidadTel.NumParte =tbxNumParte.Text;
            objEntidadTel.Precio =tbxPrecio.Text;
            objEntidadTel.NSerie =tbxNserie.Text;
            objEntidadTel.IMEI =tbxImei.Text;
             objEntidadTel.Notas =tbxNotas.Text;
             objEntidadTel.Renta = tbxRenta.Text; 



        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            closepanel();
            
        }

        private void closepanel()
        {
            StackPanelFormulario.Visibility = Visibility.Hidden;
            LimpiarEntidadIP();
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

        private object movingObject;

        private double firstXPos, firstYPos;
      
        private void PreviewDown(object sender, MouseButtonEventArgs e)
        {
            firstXPos = e.GetPosition(StackPanelFormulario).X + 0;
            firstYPos = e.GetPosition(StackPanelFormulario).Y - 0;

            movingObject = sender;

        }

        private void PreviewUp(object sender, MouseButtonEventArgs e)
        {
            movingObject = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            llenargrid();
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

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbxLinea_KeyDown(object sender, KeyEventArgs e)
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

        private void StackPanelFormulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                closepanel();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StackPanelFormulario.Visibility = Visibility.Visible;
            DataTable dtopen = new DataTable();
            tbxLinea.IsEnabled = true;
            btnHistorico.IsEnabled = false;
            UpdaterRegistro.IsEnabled = false;
            tbxLinea.Focus();
            LimpiarEntidadIP();

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

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Esta seguro de Eliminar la Linea y sus dependencias?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                llnearEntidadLinea();
                Fuentedatos.BorrarLineaID(objEntidadTel);

                MessageBox.Show("Registro Eliminado");
                LimpiarEntidadIP();
                StackPanelFormulario.Visibility = Visibility.Hidden;
                llenargrid();
            }
            else
            {
            }

        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {

            WPFProgressBar NEWoBJ = new WPFProgressBar();
            NEWoBJ.Show();

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

                ws.Range["A1"].Offset[0, Idx].Cells.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;

                //  ws.Range["A1"].Offset[0, Idx].Cells.AutoFilter();            
                ws.Range["A1"].Offset[0, Idx].Cells.HorizontalAlignment = HorizontalAlignment.Center;

                ws.Range["A1"].Offset[0, Idx].Cells.Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;


               
            }

            // Data Rows
            for (int Idx = 0; Idx < dtExcelDataTable.Rows.Count; Idx++)
            {
                ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;
                ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;

               

            }

          
            excel.Visible = true;

            wb.Activate();
            NEWoBJ.Close();
        }
        
    }
}
