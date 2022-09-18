using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionMecanicoModel : PageModel
    {

        private static RepositorioMecanico repositorio = new RepositorioMecanico(
             new Persistencia.ContextDb()
        );

        public List<Mecanico> listaMecanicos = new List<Mecanico>();
        public Mecanico mecanicoActual;

        public bool modeEdition = false;

        public void OnGet()
        {
            this.ObtenerMecanicos();
        }

        public void OnPostAdd(Mecanico mecanico)
        {
            // Console.WriteLine("Mecanico:" + mecanico.nivelEstudio);

            repositorio.AgregarMecanico(mecanico);
            this.ObtenerMecanicos();
        }


        public void OnPostSelectEdit(string id)
        {
            if (id != null)
            {
                this.mecanicoActual = repositorio.BuscarMecanico(id);
                Console.WriteLine("edit" + this.mecanicoActual.Nombre);
                this.modeEdition = true;
            }
            this.ObtenerMecanicos();
        }

        public void OnPostDel(string id)
        {
            if (id != null)
            {
                repositorio.EliminarMecanico(id);
                this.ObtenerMecanicos();
            }
        }

        public void OnPostEdit(Mecanico mecanico)
        {
            repositorio.EditarMecanico(mecanico);
            this.ObtenerMecanicos();
        }

        public void ObtenerMecanicos()
        {

            this.listaMecanicos.Clear();
            foreach (var m in repositorio.ObtenerMecanicos())
            {
                this.listaMecanicos.Add(
                    new Mecanico()
                    {
                        MecanicoId = m.MecanicoId,
                        Nombre = m.Nombre,
                        Telefono = m.Telefono,
                        FechaNacimiento = m.FechaNacimiento,
                        Contrasenia = m.Contrasenia,
                        Direccion = m.Direccion,
                        NivelEstudio = m.NivelEstudio
                    }
                );


            }
        }

        // public async Task<IActionResult> OnPostAsync(Mecanic m)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     if (Customer != null) _context.Customer.Add(Customer);
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./Index");
        // }
    }

}
