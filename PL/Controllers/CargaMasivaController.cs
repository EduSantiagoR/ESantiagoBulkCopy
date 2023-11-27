using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult CargaMasiva()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CargaMasiva(ML.Result result)
        {
            HttpPostedFileBase file = Request.Files["Archivo"];
            if(file != null)
            {
                string rutaArchivo = Path.GetFullPath(file.FileName);
                BL.CargaMasiva.ReadExcel(rutaArchivo);
            }
            return View();
        }
    }
}