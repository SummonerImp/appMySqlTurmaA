using appMySqlTurmaA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMySqlTurmaA.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Cliente
        public ActionResult Index() {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Categoria categoria) {
            return View(categoria);
        }

        public ActionResult DetailsBusca() {
            var objCategoria = new Categoria();
            var listaCategoria = objCategoria.SelectCategoria();
            SelectList lista = new SelectList(listaCategoria, "idCategoria", "nome");
            ViewBag.Lista = lista;
            return View(objCategoria);
        }

        [HttpPost]
        public ActionResult DetailsBusca(Categoria categoria) {
            if (categoria.idCategoria > 0) {
                var objCat = categoria.SelectIdCategoria(categoria);
                return RedirectToAction("Details", new { objCat.idCategoria, objCat.nome, objCat.descricao });
            }
            return View(categoria);
        }


        public ActionResult List() {
            var categoria = new Categoria();
            List<Categoria> reg = categoria.SelectCategoria();
            return View(reg);
        }

        // GET: Cliente/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria) {
            if (ModelState.IsValid) {
                var objCategoria = new Categoria();
                objCategoria.InsertCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Categoria categoria) {
            return View(categoria);
        }

        // POST: Cliente/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirma(Categoria categoria) {
            if (ModelState.IsValid) {
                var updCategoria = new Categoria();
                updCategoria.UpdateCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Categoria categoria) {
            return View(categoria);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int idCategoria) {
            if (ModelState.IsValid) {
                var categoria = new Categoria();
                categoria.DeleteCategoria(idCategoria);
                return RedirectToAction("Index");
            }
            return View(idCategoria);
        }
    }
}