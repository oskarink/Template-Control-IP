using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosSQL : Conexion
    {
        public Entidaddireccionip ObjEntidadadIP = new Entidaddireccionip();
        public EntidadTelefonia ObjEntidadadLinea = new EntidadTelefonia();

        #region IPS

        public DataSet spDistinctSegmentoRED()
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();
            }
            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.Text;
                commSQL.CommandText = "SELECT * from View_DistinctSegmentoRED";


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener Direcciones Rel. IP & Asignaciones", ex);
            }
            finally
            {
                theConnection.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet spView_ConsultaIPporSegmento(string segmento)
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();
            }
            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spView_ConsultaIPporSegmento]";

                SqlParameter param2 = new SqlParameter("@segmento", SqlDbType.VarChar);
                param2.Value = segmento;
                commSQL.Parameters.Add(param2);

                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener Direcciones Rel. IP & Asignaciones", ex);
            }
            finally
            {
                theConnection.Close();
                commSQL.Dispose();
            }

            return ds;

        }


        public DataSet ObtenerListaDireccionesIP()
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();
            }
            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.Text;
                commSQL.CommandText = "SELECT * from [dbo].[view_ConsultaPrincipalIP]";


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener Direcciones Rel. IP & Asignaciones", ex);
            }
            finally
            {
                theConnection.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet ObtenerListaDireccionesIP2()
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();
            }
            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.Text;
                commSQL.CommandText = "SELECT * from [dbo].[view_ConsultaPrincipaltel]";


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener Direcciones Rel. IP & Asignaciones", ex);
            }
            finally
            {
                theConnection2.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet ObtenerDireccionIPporID(Entidaddireccionip parametroEntidad)
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();
            }
            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[sp_ConsultaPrincipalporID]";

                SqlParameter param2 = new SqlParameter("@ID", SqlDbType.Int);
                param2.Value = parametroEntidad.ID;
                commSQL.Parameters.Add(param2);


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener DireccionporID", ex);
            }
            finally
            {
                theConnection.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet ObteneronsultaTBHistoricoporIP(Entidaddireccionip parametroEntidad)
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();
            }
            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[sp_ConsultaTBHistorico]";

                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener DireccionporID", ex);
            }
            finally
            {
                theConnection.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public ResultadoOperacion InsertRegistroIP(Entidaddireccionip parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spCrearRegistroIP]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);


                SqlParameter param3 = new SqlParameter("@DeviceName", SqlDbType.VarChar);
                param3.Value = parametroEntidad.DeviceName;
                commSQL.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@UserName", SqlDbType.VarChar);
                param4.Value = parametroEntidad.UserName;
                commSQL.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@DeptArea", SqlDbType.VarChar);
                param5.Value = parametroEntidad.DeptArea;
                commSQL.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Planta", SqlDbType.VarChar);
                param6.Value = parametroEntidad.Planta;
                commSQL.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@GLPI", SqlDbType.VarChar);
                param7.Value = parametroEntidad.GLPI;
                commSQL.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@STATUS", SqlDbType.VarChar);
                param8.Value = parametroEntidad.STATUS;
                commSQL.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@ASSIGNED", SqlDbType.Date);
                param9.Value = parametroEntidad.ASSIGNED;
                commSQL.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@UNASSIGNED", SqlDbType.Date);
                param10.Value = parametroEntidad.UNASSIGNED;
                commSQL.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@TYPE", SqlDbType.VarChar);
                param11.Value = parametroEntidad.TYPE;
                commSQL.Parameters.Add(param11);


                SqlParameter param12 = new SqlParameter("@notas", SqlDbType.VarChar);
                param12.Value = parametroEntidad.notas;
                commSQL.Parameters.Add(param12);



                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion CrearDireccionesIP(string parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spCrearDireccionesIP]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad;
                commSQL.Parameters.Add(param2);

          
             



                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion BorrarDireccionesIP(Entidaddireccionip parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spBorrarDireccionesIP]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);






                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }


        public ResultadoOperacion InsertRegistroIPMain(Entidaddireccionip parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spCrearRegistroIPMain]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);


                SqlParameter param3 = new SqlParameter("@DeviceName", SqlDbType.VarChar);
                param3.Value = parametroEntidad.DeviceName;
                commSQL.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@UserName", SqlDbType.VarChar);
                param4.Value = parametroEntidad.UserName;
                commSQL.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@DeptArea", SqlDbType.VarChar);
                param5.Value = parametroEntidad.DeptArea;
                commSQL.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Planta", SqlDbType.VarChar);
                param6.Value = parametroEntidad.Planta;
                commSQL.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@GLPI", SqlDbType.VarChar);
                param7.Value = parametroEntidad.GLPI;
                commSQL.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@STATUS", SqlDbType.VarChar);
                param8.Value = parametroEntidad.STATUS;
                commSQL.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@ASSIGNED", SqlDbType.Date);
                param9.Value = parametroEntidad.ASSIGNED;
                commSQL.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@UNASSIGNED", SqlDbType.Date);
                param10.Value = parametroEntidad.UNASSIGNED;
                commSQL.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@TYPE", SqlDbType.VarChar);
                param11.Value = parametroEntidad.TYPE;
                commSQL.Parameters.Add(param11);


                SqlParameter param12 = new SqlParameter("@notas", SqlDbType.VarChar);
                param12.Value = parametroEntidad.notas;
                commSQL.Parameters.Add(param12);



                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion UPdateRegistroIP(Entidaddireccionip parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spUpdateRegistroIP]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);


                SqlParameter param3 = new SqlParameter("@DeviceName", SqlDbType.VarChar);
                param3.Value = parametroEntidad.DeviceName;
                commSQL.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@UserName", SqlDbType.VarChar);
                param4.Value = parametroEntidad.UserName;
                commSQL.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@DeptArea", SqlDbType.VarChar);
                param5.Value = parametroEntidad.DeptArea;
                commSQL.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Planta", SqlDbType.VarChar);
                param6.Value = parametroEntidad.Planta;
                commSQL.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@GLPI", SqlDbType.VarChar);
                param7.Value = parametroEntidad.GLPI;
                commSQL.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@STATUS", SqlDbType.VarChar);
                param8.Value = parametroEntidad.STATUS;
                commSQL.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@ASSIGNED", SqlDbType.Date);
                param9.Value = parametroEntidad.ASSIGNED;
                commSQL.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@UNASSIGNED", SqlDbType.Date);
                param10.Value = parametroEntidad.UNASSIGNED;
                commSQL.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@TYPE", SqlDbType.VarChar);
                param11.Value = parametroEntidad.TYPE;
                commSQL.Parameters.Add(param11);


                SqlParameter param12 = new SqlParameter("@notas", SqlDbType.VarChar);
                param12.Value = parametroEntidad.notas;
                commSQL.Parameters.Add(param12);


                SqlParameter param13 = new SqlParameter("@Idhistory", SqlDbType.Int);
                param13.Value = parametroEntidad.idHistorico;
                commSQL.Parameters.Add(param13);



                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion spUpdatePingIP(Entidaddireccionip parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection.State == ConnectionState.Broken || theConnection.State == ConnectionState.Closed)
            {
                theConnection.Open();

            }

            try
            {
                commSQL.Connection = theConnection;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spUpdatePingIP]";


                SqlParameter param2 = new SqlParameter("@IP", SqlDbType.VarChar);
                param2.Value = parametroEntidad.IP;
                commSQL.Parameters.Add(param2);

                SqlParameter param2notas = new SqlParameter("@notas", SqlDbType.VarChar);
                param2notas.Value = parametroEntidad.notas;
                commSQL.Parameters.Add(param2notas);

                SqlParameter paramFecha = new SqlParameter("@fecha", SqlDbType.VarChar);
                paramFecha.Value = "on "+ DateTime.Now.ToShortDateString();
                commSQL.Parameters.Add(paramFecha);



                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection.Close();
            }

            return ValordeRetorno;

        }


        #endregion


        #region controltelefonia

        public DataSet ObtenerListaDireccionesLineas()
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();
            }
            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.Text;
                commSQL.CommandText = "SELECT * from [dbo].[view_ConsultaPrincipaltel]";


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener Direcciones Rel. IP & Asignaciones", ex);
            }
            finally
            {
                theConnection2.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet ObtenerDireccionIPporID2(EntidadTelefonia ObjEntidadadLinea)
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();
            }
            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[sp_ConsultaPrincipalporIDtel]";

                SqlParameter param2 = new SqlParameter("@ID", SqlDbType.Int);
                param2.Value = ObjEntidadadLinea.ID;
                commSQL.Parameters.Add(param2);


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener DireccionporID", ex);
            }
            finally
            {
                theConnection2.Close();
                commSQL.Dispose();
            }

            return ds;

        }

        public DataSet ObteneronsultaTBHistoricoporLineas(EntidadTelefonia parametroEntidad)
        {

            SqlCommand commSQL = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();
            }
            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[sp_ConsultaTBHistoricotel]";

                SqlParameter param2 = new SqlParameter("@Linea", SqlDbType.VarChar);
                param2.Value = parametroEntidad.Linea;
                commSQL.Parameters.Add(param2);


                dap.SelectCommand = commSQL;
                dap.Fill(ds);
                if (commSQL.ExecuteNonQuery() > 0)
                    return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("QRY Obtener DireccionporID", ex);
            }
            finally
            {
                theConnection2.Close();
                commSQL.Dispose();
            }

            return ds;

        }


        public ResultadoOperacion InsertRegistroLinea(EntidadTelefonia parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();

            }

            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spCrearRegistrotel]";


              
                SqlParameter Param2 = new SqlParameter("@Planta", SqlDbType.VarChar); Param2.Value = parametroEntidad.Planta; commSQL.Parameters.Add(Param2);
                SqlParameter Param3 = new SqlParameter("@Cuenta", SqlDbType.VarChar); Param3.Value = parametroEntidad.Cuenta; commSQL.Parameters.Add(Param3);
                SqlParameter Param4 = new SqlParameter("@NoEmpleado", SqlDbType.VarChar); Param4.Value = parametroEntidad.NoEmpleado; commSQL.Parameters.Add(Param4);
                SqlParameter Param5 = new SqlParameter("@Puesto", SqlDbType.VarChar); Param5.Value = parametroEntidad.Puesto; commSQL.Parameters.Add(Param5);
                SqlParameter Param6 = new SqlParameter("@Nombre", SqlDbType.VarChar); Param6.Value = parametroEntidad.Nombre; commSQL.Parameters.Add(Param6);
                SqlParameter Param7 = new SqlParameter("@Area", SqlDbType.VarChar); Param7.Value = parametroEntidad.Area; commSQL.Parameters.Add(Param7);
                SqlParameter Param8 = new SqlParameter("@Linea", SqlDbType.VarChar); Param8.Value = parametroEntidad.Linea; commSQL.Parameters.Add(Param8);
                SqlParameter Param9 = new SqlParameter("@Plan", SqlDbType.VarChar); Param9.Value = parametroEntidad.Plan; commSQL.Parameters.Add(Param9);
                SqlParameter Param10 = new SqlParameter("@MinMEXEUACAN", SqlDbType.VarChar); Param10.Value = parametroEntidad.MinMEXEUACAN; commSQL.Parameters.Add(Param10);
                SqlParameter Param11 = new SqlParameter("@MNSMEXEUACAN", SqlDbType.VarChar); Param11.Value = parametroEntidad.MNSMEXEUACAN; commSQL.Parameters.Add(Param11);
                SqlParameter Param12 = new SqlParameter("@DatosMEXEUACAN", SqlDbType.VarChar); Param12.Value = parametroEntidad.DatosMEXEUACAN; commSQL.Parameters.Add(Param12);
                SqlParameter Param13 = new SqlParameter("@DatosTotCONPROMOD", SqlDbType.VarChar); Param13.Value = parametroEntidad.DatosTotCONPROMOD; commSQL.Parameters.Add(Param13);
                SqlParameter Param14 = new SqlParameter("@RedesSocialesMex", SqlDbType.VarChar); Param14.Value = parametroEntidad.RedesSocialesMex; commSQL.Parameters.Add(Param14);
                SqlParameter Param15 = new SqlParameter("@Renta", SqlDbType.VarChar); Param15.Value = parametroEntidad.Renta; commSQL.Parameters.Add(Param15);
                SqlParameter Param16 = new SqlParameter("@MesesRestantes", SqlDbType.VarChar); Param16.Value = parametroEntidad.MesesRestantes; commSQL.Parameters.Add(Param16);
                SqlParameter Param17 = new SqlParameter("@Marca", SqlDbType.VarChar); Param17.Value = parametroEntidad.Marca; commSQL.Parameters.Add(Param17);
                SqlParameter Param18 = new SqlParameter("@Modelo", SqlDbType.VarChar); Param18.Value = parametroEntidad.Modelo; commSQL.Parameters.Add(Param18);
                SqlParameter Param19 = new SqlParameter("@NumParte", SqlDbType.VarChar); Param19.Value = parametroEntidad.NumParte; commSQL.Parameters.Add(Param19);
                SqlParameter Param20 = new SqlParameter("@Precio", SqlDbType.VarChar); Param20.Value = parametroEntidad.Precio; commSQL.Parameters.Add(Param20);
                SqlParameter Param21 = new SqlParameter("@NSerie", SqlDbType.VarChar); Param21.Value = parametroEntidad.NSerie; commSQL.Parameters.Add(Param21);
                SqlParameter Param22 = new SqlParameter("@IMEI", SqlDbType.VarChar); Param22.Value = parametroEntidad.IMEI; commSQL.Parameters.Add(Param22);
                SqlParameter Param23 = new SqlParameter("@Notas", SqlDbType.VarChar); Param23.Value = parametroEntidad.Notas; commSQL.Parameters.Add(Param23);




                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection2.Close();
            }

            return ValordeRetorno;

        }


        public ResultadoOperacion InsertRegistroLineaMain(EntidadTelefonia parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();

            }

            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spCrearRegistrotelMAin]";



                SqlParameter Param2 = new SqlParameter("@Planta", SqlDbType.VarChar); Param2.Value = parametroEntidad.Planta; commSQL.Parameters.Add(Param2);
                SqlParameter Param3 = new SqlParameter("@Cuenta", SqlDbType.VarChar); Param3.Value = parametroEntidad.Cuenta; commSQL.Parameters.Add(Param3);
                SqlParameter Param4 = new SqlParameter("@NoEmpleado", SqlDbType.VarChar); Param4.Value = parametroEntidad.NoEmpleado; commSQL.Parameters.Add(Param4);
                SqlParameter Param5 = new SqlParameter("@Puesto", SqlDbType.VarChar); Param5.Value = parametroEntidad.Puesto; commSQL.Parameters.Add(Param5);
                SqlParameter Param6 = new SqlParameter("@Nombre", SqlDbType.VarChar); Param6.Value = parametroEntidad.Nombre; commSQL.Parameters.Add(Param6);
                SqlParameter Param7 = new SqlParameter("@Area", SqlDbType.VarChar); Param7.Value = parametroEntidad.Area; commSQL.Parameters.Add(Param7);
                SqlParameter Param8 = new SqlParameter("@Linea", SqlDbType.VarChar); Param8.Value = parametroEntidad.Linea; commSQL.Parameters.Add(Param8);
                SqlParameter Param9 = new SqlParameter("@Plan", SqlDbType.VarChar); Param9.Value = parametroEntidad.Plan; commSQL.Parameters.Add(Param9);
                SqlParameter Param10 = new SqlParameter("@MinMEXEUACAN", SqlDbType.VarChar); Param10.Value = parametroEntidad.MinMEXEUACAN; commSQL.Parameters.Add(Param10);
                SqlParameter Param11 = new SqlParameter("@MNSMEXEUACAN", SqlDbType.VarChar); Param11.Value = parametroEntidad.MNSMEXEUACAN; commSQL.Parameters.Add(Param11);
                SqlParameter Param12 = new SqlParameter("@DatosMEXEUACAN", SqlDbType.VarChar); Param12.Value = parametroEntidad.DatosMEXEUACAN; commSQL.Parameters.Add(Param12);
                SqlParameter Param13 = new SqlParameter("@DatosTotCONPROMOD", SqlDbType.VarChar); Param13.Value = parametroEntidad.DatosTotCONPROMOD; commSQL.Parameters.Add(Param13);
                SqlParameter Param14 = new SqlParameter("@RedesSocialesMex", SqlDbType.VarChar); Param14.Value = parametroEntidad.RedesSocialesMex; commSQL.Parameters.Add(Param14);
                SqlParameter Param15 = new SqlParameter("@Renta", SqlDbType.VarChar); Param15.Value = parametroEntidad.Renta; commSQL.Parameters.Add(Param15);
                SqlParameter Param16 = new SqlParameter("@MesesRestantes", SqlDbType.VarChar); Param16.Value = parametroEntidad.MesesRestantes; commSQL.Parameters.Add(Param16);
                SqlParameter Param17 = new SqlParameter("@Marca", SqlDbType.VarChar); Param17.Value = parametroEntidad.Marca; commSQL.Parameters.Add(Param17);
                SqlParameter Param18 = new SqlParameter("@Modelo", SqlDbType.VarChar); Param18.Value = parametroEntidad.Modelo; commSQL.Parameters.Add(Param18);
                SqlParameter Param19 = new SqlParameter("@NumParte", SqlDbType.VarChar); Param19.Value = parametroEntidad.NumParte; commSQL.Parameters.Add(Param19);
                SqlParameter Param20 = new SqlParameter("@Precio", SqlDbType.VarChar); Param20.Value = parametroEntidad.Precio; commSQL.Parameters.Add(Param20);
                SqlParameter Param21 = new SqlParameter("@NSerie", SqlDbType.VarChar); Param21.Value = parametroEntidad.NSerie; commSQL.Parameters.Add(Param21);
                SqlParameter Param22 = new SqlParameter("@IMEI", SqlDbType.VarChar); Param22.Value = parametroEntidad.IMEI; commSQL.Parameters.Add(Param22);
                SqlParameter Param23 = new SqlParameter("@Notas", SqlDbType.VarChar); Param23.Value = parametroEntidad.Notas; commSQL.Parameters.Add(Param23);




                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection2.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion UPdateRegistroLineas(EntidadTelefonia parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();


            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();

            }

            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spUpdateRegistrotel]";

                
                SqlParameter Param2 = new SqlParameter("@Planta", SqlDbType.VarChar); Param2.Value = parametroEntidad.Planta; commSQL.Parameters.Add(Param2);
                SqlParameter Param3 = new SqlParameter("@Cuenta", SqlDbType.VarChar); Param3.Value = parametroEntidad.Cuenta; commSQL.Parameters.Add(Param3);
                SqlParameter Param4 = new SqlParameter("@NoEmpleado", SqlDbType.VarChar); Param4.Value = parametroEntidad.NoEmpleado; commSQL.Parameters.Add(Param4);
                SqlParameter Param5 = new SqlParameter("@Puesto", SqlDbType.VarChar); Param5.Value = parametroEntidad.Puesto; commSQL.Parameters.Add(Param5);
                SqlParameter Param6 = new SqlParameter("@Nombre", SqlDbType.VarChar); Param6.Value = parametroEntidad.Nombre; commSQL.Parameters.Add(Param6);
                SqlParameter Param7 = new SqlParameter("@Area", SqlDbType.VarChar); Param7.Value = parametroEntidad.Area; commSQL.Parameters.Add(Param7);
                SqlParameter Param8 = new SqlParameter("@Linea", SqlDbType.VarChar); Param8.Value = parametroEntidad.Linea; commSQL.Parameters.Add(Param8);
                SqlParameter Param9 = new SqlParameter("@Plan", SqlDbType.VarChar); Param9.Value = parametroEntidad.Plan; commSQL.Parameters.Add(Param9);
                SqlParameter Param10 = new SqlParameter("@MinMEXEUACAN", SqlDbType.VarChar); Param10.Value = parametroEntidad.MinMEXEUACAN; commSQL.Parameters.Add(Param10);
                SqlParameter Param11 = new SqlParameter("@MNSMEXEUACAN", SqlDbType.VarChar); Param11.Value = parametroEntidad.MNSMEXEUACAN; commSQL.Parameters.Add(Param11);
                SqlParameter Param12 = new SqlParameter("@DatosMEXEUACAN", SqlDbType.VarChar); Param12.Value = parametroEntidad.DatosMEXEUACAN; commSQL.Parameters.Add(Param12);
                SqlParameter Param13 = new SqlParameter("@DatosTotCONPROMOD", SqlDbType.VarChar); Param13.Value = parametroEntidad.DatosTotCONPROMOD; commSQL.Parameters.Add(Param13);
                SqlParameter Param14 = new SqlParameter("@RedesSocialesMex", SqlDbType.VarChar); Param14.Value = parametroEntidad.RedesSocialesMex; commSQL.Parameters.Add(Param14);
                SqlParameter Param15 = new SqlParameter("@Renta", SqlDbType.VarChar); Param15.Value = parametroEntidad.Renta; commSQL.Parameters.Add(Param15);
                SqlParameter Param16 = new SqlParameter("@MesesRestantes", SqlDbType.VarChar); Param16.Value = parametroEntidad.MesesRestantes; commSQL.Parameters.Add(Param16);
                SqlParameter Param17 = new SqlParameter("@Marca", SqlDbType.VarChar); Param17.Value = parametroEntidad.Marca; commSQL.Parameters.Add(Param17);
                SqlParameter Param18 = new SqlParameter("@Modelo", SqlDbType.VarChar); Param18.Value = parametroEntidad.Modelo; commSQL.Parameters.Add(Param18);
                SqlParameter Param19 = new SqlParameter("@NumParte", SqlDbType.VarChar); Param19.Value = parametroEntidad.NumParte; commSQL.Parameters.Add(Param19);
                SqlParameter Param20 = new SqlParameter("@Precio", SqlDbType.VarChar); Param20.Value = parametroEntidad.Precio; commSQL.Parameters.Add(Param20);
                SqlParameter Param21 = new SqlParameter("@NSerie", SqlDbType.VarChar); Param21.Value = parametroEntidad.NSerie; commSQL.Parameters.Add(Param21);
                SqlParameter Param22 = new SqlParameter("@IMEI", SqlDbType.VarChar); Param22.Value = parametroEntidad.IMEI; commSQL.Parameters.Add(Param22);
                SqlParameter Param23 = new SqlParameter("@Notas", SqlDbType.VarChar); Param23.Value = parametroEntidad.Notas; commSQL.Parameters.Add(Param23);
                SqlParameter param33 = new SqlParameter("@Idhistory", SqlDbType.Int);param33.Value = parametroEntidad.IdHistorico;commSQL.Parameters.Add(param33);

        


                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;


            }
            catch (Exception ex)
            {
                throw new Exception("Insert Datos Registro IP", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection2.Close();
            }

            return ValordeRetorno;

        }

        public ResultadoOperacion BorrarLineaID(EntidadTelefonia parametroEntidad)
        {

            ResultadoOperacion ValordeRetorno = ResultadoOperacion.Error;
            SqlCommand commSQL = new SqlCommand();

            if (theConnection2.State == ConnectionState.Broken || theConnection2.State == ConnectionState.Closed)
            {
                theConnection2.Open();

            }

            try
            {
                commSQL.Connection = theConnection2;
                commSQL.CommandType = CommandType.StoredProcedure;
                commSQL.CommandText = "[dbo].[spBorrarLineaIDtel]";


                SqlParameter param2 = new SqlParameter("@linea", SqlDbType.VarChar);
                param2.Value = parametroEntidad.Linea;
                commSQL.Parameters.Add(param2);

                if (commSQL.ExecuteNonQuery() > 0)
                    ValordeRetorno = ResultadoOperacion.ElementoAgregado;

            }
            catch (Exception ex)
            {
                throw new Exception("Eliminar LInea ID", ex);
            }
            finally
            {
                commSQL.Dispose();
                theConnection2.Close();
            }

            return ValordeRetorno;

        }



        #endregion
    }
}
