using CallSouth.Ventas.Peru.Call.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CallSouth.Ventas.Peru.Call.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly Context_Ventas _context;

        public VentasController(IJwtAuthenticationManager jwtAuthenticationManager, Context_Ventas context)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }



        [HttpPost]
        [Route("Call/Conecta")]
        public async Task<ActionResult<IEnumerable<TblOpcionLlamadum>>> Get(Flujo_ingreso flujo_In)
        {

            string stored = "exec ddl_llamada  @company='" + flujo_In.dato + "';";
            //return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            try
            {
                return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido ejecutar accion", detail: stored);
            }

        }

        [HttpPost]
        [Route("Call/ConectaDetalle")]
        public async Task<ActionResult<IEnumerable<TblOpcionLlamadum>>> Get_ConectaDetalle(Flujo_ingreso flujo_In)
        {
            string stored = "exec ddl_motivo_llamado  @id='" + flujo_In.dato + "';";

            try
            {
                return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido ejecutar accion", detail: stored);
            }

        }

        [HttpPost]
        [Route("Call/Profesiones")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_ConectaProfesiones(Flujo_ingreso flujo_In)
        {
            string stored = "exec ddl_profesion ";

            try
            {
                return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "No se ha podido ejecutar accion", detail: stored);
            }

        }

        [HttpPost]
        [Route("Call/ConectaCliente")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_ConectaCliente(Flujo_ingreso flujo_In)
        {

            string stored = "exec ddl_llamada_cliente  @company='" + flujo_In.dato + "';";
            //return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            
            return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
           
        }



        [HttpPost]
        [Route("Call/listas")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_Listas(Flujo_ingreso flujo_In)
        {

            string stored = "exec sp_call_listas  @pTYPE='" + flujo_In.dato + "', @id='" + flujo_In.dato_1 + "', @id_2='" + flujo_In.dato_2 + "', @id_3='" + flujo_In.dato_3 + "';";
            //return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

        }


        [HttpPost]
        [Route("Call/ConectaClienteInteresa")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_ConectaClienteInteresa(Flujo_ingreso flujo_In)
        {

            string stored = "exec ddl_llamada_cliente_interesa  @company='" + flujo_In.dato + "';";
            //return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

        }
        
        [HttpPost]
        [Route("Call/ConectaClienteNoInteresa")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_ConectaClienteNoInteresa(Flujo_ingreso flujo_In)
        {

            string stored = "exec ddl_llamada_cliente_nointeresa  @company='" + flujo_In.dato + "';";
            //return await _context.TblOpcionLlamada.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

        }

        [HttpPost]
        [Authorize(Roles = "CRM_Supervisor")]
        [Route("CRM/Gestion/Regrabaciones")]
        public async Task<List<Flujo_Respuesta>> Get_GestionRegrabacion(Flujo_ingreso flujo_In)
        {
            string stored = "exec sp_listar_regrabaciones  @fecha='" + flujo_In.dato + "', @company='" + flujo_In.dato_1 + "';";

            return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

        }


        [HttpPost]
        [Route("Call/SaveURl")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_SaveUrl(Flujo_ingreso flujo_In)
        {
            string stored = "exec sp_guarda_url  @agent='" + flujo_In.dato + "', @url='" + flujo_In.dato_2 + "';";


            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }



        [HttpPost]
        [Route("Call/Comuna")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_Comuna(Flujo_ingreso flujo_In)
        {
            string stored = "exec sp_comuna  @company='" + flujo_In.dato + "';";


            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }



        [HttpPost]
        [Route("Call/Ciudad")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_Ciudad(Flujo_ingreso flujo_In)
        {
            string stored = "exec sp_ciudad  @comuna='" + flujo_In.dato + "', @company='" + flujo_In.dato_2 + "';";


            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }


        [HttpPost]
        [Route("Call/DatosCliente")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_CallIntroDatosCliente(Flujo_ingreso flujo_In)
        {

            string stored = "exec sp_datos_cliente  @id='" + flujo_In.dato + "'";

            //   return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            try
            {
                return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "Error al traer datos Cliente", detail: stored);
            }


        }

        [HttpPost]
        [Route("Call/GuardaGestion")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_GuardarVenta(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            Input = Input.Replace("{", "{{").Replace("}", "}}");

            string stored = "exec sp_inserta_gestion @objeto='" + Input.ToString() + "';";

            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }

        [HttpPost]
        [Route("Call/GuardaGestion/Inchape")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_GuardarVentaInchape(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            Input = Input.Replace("{", "{{").Replace("}", "}}");

            string stored = "exec sp_inserta_gestion_inchape @objeto='" + Input.ToString() + "';";

            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }



        [HttpPost]
        [Route("Call/DatosCliente/Regrabacion")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_CallIntroDatosClienteRegrabacion(Flujo_ingreso flujo_In)
        {

            string stored = "exec sp_datos_cliente_regrabacion  @id='" + flujo_In.dato + "'";

            //   return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            try
            {
                return await _context.flujo_Respuestas.FromSqlRaw(stored).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                return Problem(title: "Error al traer datos Cliente", detail: stored);
            }


        }

        [HttpPost]
        [Route("Call/GuardaGestion/Regrabacion")]
        public async Task<ActionResult<IEnumerable<Flujo_Respuesta>>> Get_GuardarVentaLaPolar(dynamic DynamicClass)
        {

            string Input = JsonConvert.SerializeObject(DynamicClass);

            Input = Input.Replace("{", "{{").Replace("}", "}}");

            string stored = "exec sp_inserta_gestion_santander_regrabacion @objeto='" + Input.ToString() + "';";

            return await _context.flujo_Respuestas.FromSqlRaw(stored).ToListAsync();


        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Validacall")]
        public async Task<ActionResult<IEnumerable<Login_out>>> GetValidacall(Login login)
        {

            string stored = "exec sp_verifica_callintro @agente='" + login.UserName + "';";
            List<Login_out> list = await _context.Login_out.FromSqlRaw(stored).AsNoTracking().ToListAsync();

            var resultado = from s in list select s;

            List<Login_out_result> log_resul = new List<Login_out_result>();


            var id = 0;


            foreach (var lista in resultado)
                id = lista.id;


            if (id > 0)
            {
                var tokens = jwtAuthenticationManager.Authenticate(login.UserName, login.Password);

                if (tokens == null)
                {

                    return Unauthorized(new { status = true, statusCode = 401, message = "Usuario/Password Incorrecto" });

                }
                else
                {


                    foreach (var lista in resultado)
                    {
                        log_resul.Add(new Login_out_result
                        {
                            cliente = lista.cliente,
                            id_usuario = lista.id_usuario,
                            id = lista.id,
                            gui = lista.gui,
                            ruta = lista.ruta,
                            token = tokens
                        });


                    }



                    return Ok(log_resul);
                }

            }
            else

            {

                return Ok(list);
            }




        }




    }
}
