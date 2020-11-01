using appMySqlTurmaA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMySqlTurmaA.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Cliente cliente)
        {
            return View(cliente);
        }

        public ActionResult DetailsBusca()
        {
            var objCliente = new Cliente();
            var listaCliente = objCliente.SelectCliente();
            SelectList lista = new SelectList(listaCliente, "idCliente", "nome");
            ViewBag.Lista = lista;
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult DetailsBusca(Cliente cliente)
        {
            if (cliente.idCliente > 0)
            {
                var objCli = cliente.SelectIdCliente(cliente);
                return RedirectToAction("Details", new { objCli.idCliente, objCli.nome, objCli.endereco, objCli.telefone, objCli.cpf });
            }
            return View(cliente);
        }

        public ActionResult List()
        {
            var cliente = new Cliente();
            List<Cliente> reg = cliente.SelectCliente();
            return View(reg);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var objCliente = new Cliente();
                objCliente.InsertCliente(cliente);
                return RedirectToAction("Index");
            }            

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Cliente cliente)
        {
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirma(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var updCliente = new Cliente();
                updCliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult EditBusca()
        {
            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Cliente cliente)
        {
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int idCliente)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente();
                cliente.DeleteCliente(idCliente);
                return RedirectToAction("Index");
            }
            return View(idCliente);
        }

        public ActionResult DeleteBusca()
        {
            var objCliente = new Cliente();
            var listaCliente = objCliente.SelectCliente();
            SelectList lista = new SelectList(listaCliente, "idCliente", "nome");
            ViewBag.Lista = lista;
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult DeleteBusca(Cliente cliente)
        {
            if (cliente.idCliente > 0)
            {
                var objCli = cliente.SelectIdCliente(cliente);
                return RedirectToAction("Delete", new { objCli.idCliente, objCli.nome, objCli.endereco, objCli.telefone, objCli.cpf });
            }
            return View(cliente);
        }

        public JsonResult IsCpfExist(string cpf)
        {
            var cliente = new Cliente();
            var validateName = cliente.SelectCpfCliente(cpf);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
