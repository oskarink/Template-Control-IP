using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadUsuario
    {
        string _password;
        int _IdUsuario;
        string _NombreUsuario;
        string _Usuario;
        int _intTipoUsuario;

        DateTime _fecha;
        int _idBitacora;
        private string _tecnicoLogin;


        Byte[] _foto = new Byte[0];

        public Byte[] foto
        {
            get { return _foto; }
            set { _foto = value; }
        }


        public string TecnicoLogin
        {
            get { return _tecnicoLogin; }
            set { _tecnicoLogin = value; }
        }
       

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public int IdBitacora
        {
            get { return _idBitacora; }
            set { _idBitacora = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public int IntTipoUsuario
        {
            get { return _intTipoUsuario; }
            set { _intTipoUsuario = value; }
        }
        string _tipoUsuario;

        public string TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }



        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public EntidadUsuario()
        {
            _password = string.Empty;
            _IdUsuario = 0;
            _NombreUsuario = string.Empty;
            _intTipoUsuario = 0;
            _Usuario = string.Empty;
            _tecnicoLogin = string.Empty;
        }
    }
}