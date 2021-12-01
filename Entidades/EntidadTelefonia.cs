using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class EntidadTelefonia
   {
       #region atributos
       private int _ID;
       private int _idHistorico;

      
        private string _Planta;
        private string _Cuenta;
        private string _NoEmpleado;
        private string _Puesto;
        private string _Nombre;
        private string _Area;
        private string _Linea;
        private string _Plan;
        private string _MinMEXEUACAN;
        private string _MNSMEXEUACAN;
        private string _DatosMEXEUACAN;
        private string _DatosTotCONPROMOD;
        private string _RedesSocialesMex;
        private string _Renta;
        private string _MesesRestantes;
        private string _Marca;
        private string _Modelo;
        private string _NumParte;
        private string _Precio;
        private string _NSerie;
        private string _IMEI;
        private string _Notas;
        private DateTime _ASSIGNED;
        private DateTime _UNASSIGNED;

       #endregion


        #region encapsulamiento


        public DateTime UNASSIGNED
        {
            get { return _UNASSIGNED; }
            set { _UNASSIGNED = value; }
        }


        public DateTime ASSIGNED
        {
            get { return _ASSIGNED; }
            set { _ASSIGNED = value; }
        }

        public int IdHistorico
        {
            get { return _idHistorico; }
            set { _idHistorico = value; }
        }
        public int ID 
        { 
            get { return _ID; } 
            set { _ID = value; } 
        
        }
            public string Planta { get { return _Planta; } set { _Planta = value; } }
            public string Cuenta { get { return _Cuenta; } set { _Cuenta = value; } }
            public string NoEmpleado { get { return _NoEmpleado; } set { _NoEmpleado = value; } }
            public string Puesto { get { return _Puesto; } set { _Puesto = value; } }
            public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
            public string Area { get { return _Area; } set { _Area = value; } }
            public string Linea { get { return _Linea; } set { _Linea = value; } }
            public string Plan { get { return _Plan; } set { _Plan = value; } }
            public string MinMEXEUACAN { get { return _MinMEXEUACAN; } set { _MinMEXEUACAN = value; } }
            public string MNSMEXEUACAN { get { return _MNSMEXEUACAN; } set { _MNSMEXEUACAN = value; } }
            public string DatosMEXEUACAN { get { return _DatosMEXEUACAN; } set { _DatosMEXEUACAN = value; } }
            public string DatosTotCONPROMOD { get { return _DatosTotCONPROMOD; } set { _DatosTotCONPROMOD = value; } }
            public string RedesSocialesMex { get { return _RedesSocialesMex; } set { _RedesSocialesMex = value; } }
            public string Renta { get { return _Renta; } set { _Renta = value; } }
            public string MesesRestantes { get { return _MesesRestantes; } set { _MesesRestantes = value; } }
            public string Marca { get { return _Marca; } set { _Marca = value; } }
            public string Modelo { get { return _Modelo; } set { _Modelo = value; } }
            public string NumParte { get { return _NumParte; } set { _NumParte = value; } }
            public string Precio { get { return _Precio; } set { _Precio = value; } }
            public string NSerie { get { return _NSerie; } set { _NSerie = value; } }
            public string IMEI { get { return _IMEI; } set { _IMEI = value; } }
            public string Notas { get { return _Notas; } set { _Notas = value; } }
        #endregion
            public EntidadTelefonia()
           {

            _ID=0;
            _Planta=String.Empty;
            _Cuenta=String.Empty;
            _NoEmpleado=String.Empty;
            _Puesto=String.Empty;
            _Nombre=String.Empty;
            _Area=String.Empty;
            _Linea  =String.Empty;
            _Plan =String.Empty;
            _MinMEXEUACAN=String.Empty;
            _MNSMEXEUACAN=String.Empty;
            _DatosMEXEUACAN=String.Empty;
            _DatosTotCONPROMOD=String.Empty;
            _RedesSocialesMex=String.Empty;
            _Renta =String.Empty;
            _MesesRestantes=String.Empty;
            _Marca=String.Empty;
            _Modelo=String.Empty;
            _NumParte=String.Empty;
            _Precio=String.Empty;
            _NSerie=String.Empty;
            _IMEI=String.Empty;
            _Notas=String.Empty;
            _idHistorico = 0;


   }


    }
}
