using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario45
{
    public class Alumno
    {
        private string _registro;
        private string _nombre;

		public string Registro
		{
			get { return this._registro; }
			set { this._registro = value; }
		}
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		public Alumno(string registro, string nombre)
		{
			this._registro = registro;
			this._nombre = nombre;

		}


	}

	

}
