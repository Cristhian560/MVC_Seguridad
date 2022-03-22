using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Models;

namespace Seguridad.Controllers
{
    public class ClientesController : Controller
    {
        //public mvc_clientesContext ctx { get; set; }
        //public ClientesController(mvc_clientesContext ctx)
        //{
        //    this.ctx = ctx;
        //}
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            using (var db = new Models.mvc_clientesContext())
            {
                if (cliente.IdCliente == 0)
                {
                    db.Clientes.Add(cliente);
                }
                else
                {
                    db.Attach(cliente);
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Listado");



            //    //if (cliente.IdCliente == 0)
            //    //{
            //    //    this.ctx.Clientes.Add(cliente);
            //    //}
            //    //else
            //    //{
            //    //    this.ctx.Attach(cliente);
            //    //    this.ctx.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    //}
            //    //this.ctx.SaveChanges();
            //    //return RedirectToAction("Listado");
        }
        public IActionResult Borrar(string id)
        {
            using (var db = new mvc_clientesContext())
            {
                Cliente c = db.Clientes.Find(Convert.ToInt32(id));
                db.Remove(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }

            return RedirectToAction("Listado");

            //var model = this.ctx.Clientes.Find(Convert.ToInt32(id));
            //this.ctx.Remove(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //this.ctx.SaveChanges();
            //return RedirectToAction("Listado");
        }
        public IActionResult Editar(string id)
        {
            Cliente c = new Cliente();
            using (var db = new mvc_clientesContext())
            {
                c = db.Clientes.Find(Convert.ToInt32(id));
            }
            return View(c);
            //var model = this.ctx.Clientes.Find(Convert.ToInt32(id));
            //return View(model);
        }
        public ActionResult Listado()
        {
            //var model = new PersonajeListadoModel();
            //model.Listado = this.ctx.Personajes.ToList();
            //List<Cliente> lista_clientes = new List<Cliente>();
            //lista_clientes = this.ctx.Clientes.ToList();
            //return View(lista_clientes);



            List<Cliente> lista = new List<Cliente>();
            using (var db = new mvc_clientesContext())
            {
                lista = db.Clientes.ToList();
                //lista = (from d in db.Clientes
                //         select new Cliente
                //         {
                //             IdCliente = d.IdCliente,
                //             Nombre = d.Nombre,
                //             Apellido = d.Apellido,
                //             Direccion = d.Direccion,
                //             Telefono = (long)d.Telefono
                //         }).ToList();
            }
            return View(lista);
        }
    }
}
