using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario45
{
	public class UsuarioAdministrador : Usuario
	{
		protected List<Alumno> _alumno;

		public List<Alumno> Alumno
		{
			get { return this._alumno; }
			set { this._alumno = value; }
		}

		public UsuarioAdministrador(string nombre, List<Alumno> alumno) : base(nombre)
		{
			this._alumno = alumno;
		}

		public void MenuAdministrador(List<Alumno> alumno)
		{
			Alumno = alumno; /* Se reciben los productos del sistema */
			int opcion;
			do
			{

				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menu del Sistema" +
									   "\n [1] Crear Alumno." +
									   "\n [2] Ver Alumno(s)." +
									   "\n [3] Volver al menu Principal.", 1, 3);

				switch (opcion)
				{
					case 1:
						CrearAlumno();
						break;
					case 2:
						VerAlumno();
						Validador.VolverMenu();
						break;
				
				}
			} while (opcion != 3);
		}
		

		protected override void CrearAlumno()
		{
			
			
			string registro;
			string nombre;
			string opcion;

			do
			{
				VerAlumno();
				
				registro = ValidarStringNoVacioAlumno("\n Ingrese el registro del Alumno a agregar ");
				/* Mientras que a buscarAlumno pasandole el registro como parámetro retorne -1 indicar */
				if (registro == "0")
                {
					break;
                }
				if (BuscarAlumnoRegistro(registro) == -1)
				{

					VerAlumno();
					Console.WriteLine("\n ¡En hora buena! Puede utilizar este Registro para crear un Alumno Nuevo");
					nombre = ValidarStringNoVacioAlumno("\n Ingrese el nombre del Alumno a Crear");

					VerAlumno();
					Console.WriteLine("\n Código de Alumno a Crear: " + registro +
										"\n Nombre de Alumno Crear: " + nombre);

					opcion = ValidarSioNoAlumno("\n Está seguro que desea crear este Alumno? ", registro);
					if (opcion == "SI")
					{
						/* Como la clase Alumno esta en el namespace podemos usarlo y creo el objeto con el constructor */
						Alumno p = new Alumno(registro, nombre);
						/* Agrego el objeto a la lista */
						AddAlumno(p);
						VerAlumno();
						Console.WriteLine("\nAlumno *" + nombre + "* con Registro *" + registro + "* agregado exitósamente");
						Validador.VolverMenu();
					}
					else
					{
						VerAlumno();
						Console.WriteLine("\n Como puede verificar no se creo ningún Alumno");
						Validador.VolverMenu();

					}

				}
				else
				{
					VerAlumno();
					Console.WriteLine("\n Usted digitó el Registro *" + registro + "*");
					Console.WriteLine("\n Ya existe un Alumno con ese Registro");
					Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
					Validador.VolverMenu();
				}
			} while (registro != "0");
			
		}

		public void AddAlumno(Alumno alumno)
		{
			this._alumno.Add(alumno);
		}

		protected string ValidarStringNoVacioAlumno(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Recuerde que no puede ingresar un Registro de Alumno existente"+
			                          "\n Por favor ingrese el valor solicitado y que no sea vacio." +
									  "\n Si desea salir de agregar Alumnos escriba *0*";


			do
			{
				VerAlumno();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoAlumno(string mensaje, string codigo)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerAlumno();
				if (BuscarAlumnoRegistro(codigo) != -1)
				{
					Console.WriteLine("\n Código de Producto : " + Alumno[BuscarAlumnoRegistro(codigo)].Registro +
									  "\n Nombre de Producto : " + Alumno[BuscarAlumnoRegistro(codigo)].Nombre);
				}
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}


		public int BuscarAlumnoRegistro(string registro)
		{
			for (int i = 0; i < this._alumno.Count; i++)
			{
				if (this._alumno[i].Registro == registro)
				{
					return i;
				}
			}
			/* si no encuentro el alumno retorno una posición invalida */
			return -1;
		}

		public void VerAlumno()
		{
			Console.Clear();
			Console.WriteLine("\n Número de Alumnos");
			Console.WriteLine(" #\tRegistro\tNombre");
			for (int i = 0; i < Alumno.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t");
				Console.Write(Alumno[i].Registro);
				Console.Write("\t\t");
				Console.Write(Alumno[i].Nombre);
				Console.Write("\n");
				
			}

		}

	}
}
