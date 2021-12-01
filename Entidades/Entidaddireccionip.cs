using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidaddireccionip
    {

        #region atributos

        private int _ID;
        private string _Notas;
        private int _idHistorico;
        private string _IP;

        private string _DeviceName;
        private string _DeptArea;
        private string _Planta;
        private string _GLPI;
        private string _STATUS;
        private DateTime _ASSIGNED;
        private DateTime _UNASSIGNED;
        private string _TYPE;
        private string _notas;
        private string _UserName;
      private string _nota2;
      private string _segmento;

      public string Segmento
      {
          get { return _segmento; }
          set { _segmento = value; }
      }














        #endregion

        #region encapsulamiento



      public string UserName
      {
          get { return _UserName; }
          set { _UserName = value; }
      }




        public int idHistorico
        {
            get { return _idHistorico; }
            set { _idHistorico = value; }
        }




        public string nota2
        {
            get { return _nota2; }
            set { _nota2 = value; }
        }

        public string notas
        {
            get { return _notas; }
            set { _notas = value; }
        }

    



        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }



        public string Planta
        {
            get { return _Planta; }
            set { _Planta = value; }
        }

        public string DeptArea
        {
            get { return _DeptArea; }
            set { _DeptArea = value; }
        }

        public string DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }

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

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }

        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        public string GLPI
        {
            get { return _GLPI; }
            set { _GLPI = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public string nombre
        {
            get { return _Notas; }
            set { _Notas = value; }
        }




        #endregion


        #region constructor

        public Entidaddireccionip()
        {

            _ID = 0;

            _Notas = String.Empty;
            _IP = String.Empty;
            _GLPI = String.Empty;
            _STATUS = String.Empty;
            _TYPE = String.Empty;
            _DeviceName = String.Empty;
            _DeptArea = String.Empty;
            _Planta = String.Empty;
            _UserName = string.Empty;
            _idHistorico = 0;
            _segmento = string.Empty;


        }

        #endregion


    }
}
