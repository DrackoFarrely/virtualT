using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virtual_T.Business;
using Virtual_T.Models.Dominio;

namespace Virtual_T.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService;
        //Inyeccion de dependencias
        public UsuarioController() : this(new UsuarioService()) { }
        public UsuarioController(UsuarioService _usuarioService)
        {
            this.usuarioService = _usuarioService;
        }
        //Acciones (Métodos) de Routeo
        public ActionResult Listar()
        {
            List<Usuario> lista = usuarioService.ListarTodo();
            if (lista != null)
                return View(lista);
            ViewBag.Error = "Error al traer la lista";
            return View(new List<Usuario>());
        }
       
        public ActionResult Create()
        {
            Usuario entity = new Usuario();
            return View(entity);

        }
        [HttpPost]
        public ActionResult Create(Usuario entity)
        {
            usuarioService.Guardar(entity);
            return RedirectToAction("Listar");

        }

    }
}