using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace HDI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HDIController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly Context_HDI _context;

        public HDIController(IJwtAuthenticationManager jwtAuthenticationManager, Context_HDI context)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }



        //public HDIController(Context_HDI context)
        //{
        //    _context = context;
        //}

        // GET: api/<HDIController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpPost]
        //[Route("Paso_1")]
        //public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_Paso_1(Flujo_in_paso_1 flujo_In)
        //{
        //    string stored = "exec sp_QA_ingreso_1  @Simulacion='" + flujo_In.Simulacion +
        //  "',@PasoWeb = '" + flujo_In.PasoWeb +
        //  "',@MarcaModeloAnioTipoVehiculo = '" + flujo_In.MarcaModeloAnioTipoVehiculo +
        //  "',@Rut = '" + flujo_In.Rut +
        //  "',@DV = '" + flujo_In.DV +
        //  "',@DuenoVehiculo = '" + flujo_In.DuenoVehiculo +
        //  "',@RutDueno = '" + flujo_In.RutDueno +
        //  "',@DVDueno = '" + flujo_In.DVDueno +
        //  "',@Campana = '" + flujo_In.Campana +
        //  "',@Telefono = '" + flujo_In.Telefono +
        //  "',@CorreoElectronico = '" + flujo_In.CorreoElectronico + "'";

        //    try
        //    {
        //        return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail:stored );
        //    }
          

          

        //}
        
        //[HttpPost]
        //[Route("Paso_2")]
        //public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_Paso_2(Flujo_in_paso_2 flujo_In)
        //{

        //    string stored = "exec sp_QA_ingreso_2  @Simulacion='" + flujo_In.Simulacion +
        //        "',@PasoWeb = '" + flujo_In.PasoWeb +
        //        "',@Deducuble = '" + flujo_In.Deducuble +
        //        "',@ResponsabilidadCivil = '" + flujo_In.ResponsabilidadCivil +
        //        "',@AutoReemplazo = '" + flujo_In.AutoReemplazo + "'";

        //    try
        //    {
        //        return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail: stored);
        //    }


        //}

        //[HttpPost]
        //[Route("Paso_3")]
        //public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_Paso_3(Flujo_in_paso_3 flujo_In)
        //{

        //    string stored = "exec sp_QA_ingreso_3  @Simulacion='" + flujo_In.Simulacion +
        //        "',@PasoWeb = '" + flujo_In.PasoWeb +
        //        "',@VehiculoNuevo   = '" + flujo_In.VehiculoNuevo +
        //        "',@Patente		 = '" + flujo_In.Patente +
        //        "',@Nombres		 = '" + flujo_In.Nombres +
        //        "',@ApellidoPaterno = '" + flujo_In.ApellidoPaterno +
        //        "',@ApellidoMaterno = '" + flujo_In.ApellidoMaterno +
        //        "',@fechaCotizacion = '" + flujo_In.fechaCotizacion + "'";

        //    try
        //    {
        //        return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail: stored);
        //    }


        //}

        [HttpPost]
        [Route("Ingreso")]
        public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_Ingreso(Flujo_in flujo_In)
        {

            string stored = "exec sp_QA_Ingreso   @Simulacion='" + flujo_In.Simulacion +
          "',@PasoWeb = '" + flujo_In.PasoWeb +
          "',@MarcaModeloAnioTipoVehiculo = '" + flujo_In.MarcaModeloAnioTipoVehiculo +
          "',@Rut = '" + flujo_In.Rut +
          "',@DV = '" + flujo_In.DV +
          "',@DuenoVehiculo = '" + flujo_In.DuenoVehiculo +
          "',@RutDueno = '" + flujo_In.RutDueno +
          "',@DVDueno = '" + flujo_In.DVDueno +
          "',@Deducible = '" + flujo_In.Deducible +
          "',@ResponsabilidadCivil = '" + flujo_In.ResponsabilidadCivil +
          "',@AutoReemplazo = '" + flujo_In.AutoReemplazo +
          "',@VehiculoNuevo   = '" + flujo_In.VehiculoNuevo +
          "',@Patente		 = '" + flujo_In.Patente +
          "',@Nombres		 = '" + flujo_In.Nombres +
          "',@ApellidoPaterno = '" + flujo_In.ApellidoPaterno +
          "',@ApellidoMaterno = '" + flujo_In.ApellidoMaterno +
          "',@Campana = '" + flujo_In.Campana +
          "',@Telefono = '" + flujo_In.Telefono +
          "',@CorreoElectronico = '" + flujo_In.CorreoElectronico +
           "',@Prioridad = '" + flujo_In.Prioridad +
          "',@fechaCotizacion = '" + flujo_In.fechaCotizacion + "'";

            try
            {
                return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail: stored);
            }


        }

        [HttpPost]
        [Route("IngresoProd")]
        public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_IngresoProd(Flujo_in flujo_In)
        {

            string stored = "exec sp_Prod_Ingreso   @Simulacion='" + flujo_In.Simulacion +
          "',@PasoWeb = '" + flujo_In.PasoWeb +
          "',@MarcaModeloAnioTipoVehiculo = '" + flujo_In.MarcaModeloAnioTipoVehiculo +
          "',@Rut = '" + flujo_In.Rut +
          "',@DV = '" + flujo_In.DV +
          "',@DuenoVehiculo = '" + flujo_In.DuenoVehiculo +
          "',@RutDueno = '" + flujo_In.RutDueno +
          "',@DVDueno = '" + flujo_In.DVDueno +
          "',@Deducible = '" + flujo_In.Deducible +
          "',@ResponsabilidadCivil = '" + flujo_In.ResponsabilidadCivil +
          "',@AutoReemplazo = '" + flujo_In.AutoReemplazo +
          "',@VehiculoNuevo   = '" + flujo_In.VehiculoNuevo +
          "',@Patente		 = '" + flujo_In.Patente +
          "',@Nombres		 = '" + flujo_In.Nombres +
          "',@ApellidoPaterno = '" + flujo_In.ApellidoPaterno +
          "',@ApellidoMaterno = '" + flujo_In.ApellidoMaterno +
          "',@Campana = '" + flujo_In.Campana +
          "',@Telefono = '" + flujo_In.Telefono +
          "',@CorreoElectronico = '" + flujo_In.CorreoElectronico +
           "',@Prioridad = '" + flujo_In.Prioridad +
          "',@fechaCotizacion = '" + flujo_In.fechaCotizacion + "'";

            try
            {
                return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail: stored);
            }


        }
        //[HttpPost]
        //[Route("Paso_4")]
        //public async Task<ActionResult<IEnumerable<Flujo_Out_respuesta>>> Get_Paso_4(Flujo_in_paso_4 flujo_In)
        //{

        //    string stored = "exec sp_QA_ingreso_4  @Simulacion='" + flujo_In.Simulacion +
        //        "',@PasoWeb = '" + flujo_In.PasoWeb +
        //        "',@Campana = '" + flujo_In.Campana  + "'";

        //    try
        //    {
        //        return await _context.flujo_Out_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        return Problem(title: "No se ha podido Guardar la Gestion, debido a un error del Servicio", detail: stored);
        //    }


        //}


        [HttpPost]
        [Route("QA_Datos")]
        public async Task<ActionResult<IEnumerable<Flujo_Out>>> Get_QA_Datos()
        {

            string stored = "exec sp_view_registros ";

            try
            {
                return await _context.flujo_Outs.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido listar los registros, debido a un error del Servicio", detail: stored);
            }


        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {

            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized(new {status=true, statusCode=401, message="Usuario/Password Incorrecto" });
            return Ok(new { status = true, statusCode = 200, message = "Ingreso Correcto" ,token = token});

        }

        public class UserCred
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }
}
