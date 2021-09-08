using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaSxo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaSxo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private PruebaTecnicaSxoContext db = new PruebaTecnicaSxoContext();


        /***** FACTURAS *****/
        //Retorna la lista de facturas que se encuentran en la tabla factuas
        [HttpGet]
        [Route("getFacturas")]
        public ActionResult<IEnumerable<Factura>> GetFacturas()
        {
            var listaFacturas = db.Facturas.ToList();
            try
            {
                return listaFacturas;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        //Agregar una nueva factura
        [HttpPost]
        [Route("postNuevaFactura")]
        public ActionResult<Factura> postNuevaFactura([FromBody] Factura factura)
        {
            try
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
