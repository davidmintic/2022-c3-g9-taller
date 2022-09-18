using System;
using Taller.App.Persistencia;
using Taller.App.Dominio;

namespace Taller.App.Consola
{

    class Program
    {

        private static RepositorioMecanico respositorio = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );

        static void Main(string[] arg)
        {
            // BuscarMecanico("2");

            AgregarMecanico();
            // EliminarMecanico("1");
            // EditarMecanico();
            // ObtenerMecanicos();
        }


        static void AgregarMecanico()
        {
            var mecanico = new Mecanico
            {
                MecanicoId = "4",
                Nombre = "David",
                Telefono = "111",
                FechaNacimiento = "111",
                Contrasenia = "111",
                Direccion = "calle 111",
                NivelEstudio = "Colegial"
            };

            respositorio.AgregarMecanico(mecanico);
        }


        static void ObtenerMecanicos()
        {

            foreach (var m in respositorio.ObtenerMecanicos())
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Nombre: " + m.Nombre + "\nTel: " + m.Telefono);
                Console.WriteLine("--------------------");
            }
        }

        static void BuscarMecanico(string id)
        {

            var m = respositorio.BuscarMecanico(id);

            if (m != null)
            {
                Console.WriteLine("Se encontró: " + m.Nombre);
            }
            else
            {
                Console.WriteLine("NO se encontró");
            }

        }

        static void EliminarMecanico(string id)
        {

            respositorio.EliminarMecanico(id);
        }

        static void EditarMecanico()
        {
            var mecanico = new Mecanico
            {
                MecanicoId = "3",
                Nombre = "Pedro",
                Telefono = "333",
                FechaNacimiento = "333",
                Contrasenia = "333",
                Direccion = "calle 111",
                NivelEstudio = "Colegial"
            };

            respositorio.EditarMecanico(mecanico);
        }


    }
}