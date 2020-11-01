using appMySqlTurmaA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMySqlTurmaA.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Cliente
        public ActionResult Index() {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Produto produto) {
            return View(produto);
        }

        public ActionResult List() {
            var produto = new Produto();
            List<Produto> reg = produto.SelectProduto();
            return View(reg);
        }

        // GET: Cliente/Create
        public ActionResult Create() {
            var objCat = new Produto();
            var listaCat = objCat.SelectCategoria();
            SelectList lista = new SelectList(listaCat, "idCategoria", "nome");
            ViewBag.Lista = lista;
            return View(objCat);
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Produto produto) {
            if (ModelState.IsValid) {
                var objProduto = new Produto();
                objProduto.InsertProduto(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Produto produto) {
            return View(produto);
        }

        // POST: Cliente/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirma(Produto produto) {
            if (ModelState.IsValid) {
                var updProduto = new Produto();
                updProduto.UpdateProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Produto produto) {
            return View(produto);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int idProduto) {
            if (ModelState.IsValid) {
                var produto = new Produto();
                produto.DeleteProduto(idProduto);
                return RedirectToAction("Index");
            }
            return View(idProduto);
        }

        public ActionResult DetailsBusca() {
            var objProduto = new Produto();
            var listaProduto = objProduto.SelectProduto();
            SelectList lista = new SelectList(listaProduto, "idProduto", "nome");
            ViewBag.Lista = lista;
            return View(objProduto);
        }

        [HttpPost]
        public ActionResult DetailsBusca(Produto produto) {
            if (produto.idProduto > 0) {
                var objProduto = produto.SelectIdProduto(produto);
                return RedirectToAction("Details", new { objProduto.idProduto, objProduto.nome, objProduto.precoUnitario, objProduto.idCategoria });
            }
            return View(produto);
        }

        public ActionResult DeleteBusca()
        {
            var objPro = new Produto();
            var listaProd = objPro.SelectProduto();
            SelectList lista = new SelectList(listaProd, "idCliente", "nome");
            ViewBag.Lista = lista;
            return View(objPro);
        }

        [HttpPost]
        public ActionResult DeleteBusca(Produto produto)
        {
            if (produto.idProduto > 0)
            {
                var objProd = produto.SelectIdProduto(produto);
                return RedirectToAction("Delete", new { objProd.idProduto, objProd.nome, objProd.precoUnitario, objProd.idCategoria });
            }
            return View(produto);
        }
    }
}