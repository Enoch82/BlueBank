using CarroDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Controllers
{
    [Route("[controller]")]
    public class CuentaController : Controller
    {
        private readonly MyDbContext _context;

        public CuentaController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public CustomeResponse ListaMovimientoPorCuentaId(int cuentaId)
        {
            CustomeResponse cr = new();
            try
            {
                if (cuentaId > 0)
                {
                    cr.Data = _context.MoviemientoProductosModel
                                .Where(m => m.CuentaId == cuentaId)
                                .OrderByDescending(m => m.FechaOperacion)
                                .ToList();
                    cr.Sucess = 1;
                }
                else
                {
                    cr.Message = "El identificador del usuario no se encontra";
                    cr.Sucess = 0;
                }

            }
            catch (Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;

        }

        [HttpGet("[action]")]
        public CustomeResponse ObtenerCuentaPorClienteId(int clienteId)
        {
            CustomeResponse cr = new();
            try
            {
                if(clienteId != null)
                {
                    cr.Data = _context.CuentaModel.Where(x => x.ClienteId == clienteId).ToList();
                    cr.Sucess = 1; 
                }else
                {
                    cr.Message = "El identificador del usuario no se encontra";
                    cr.Sucess = 0;
                }

            }catch(Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0; 
            }
            return cr;
            
        }
        
        [HttpPost("[action]")]
        public CustomeResponse CrearCuenta([FromBody] Cuenta cuenta)
        {
            CustomeResponse cr = new();
            try
            {
                if (cuenta is not null)
                {
                    _context.CuentaModel.Add(cuenta);
                    _context.SaveChanges();
                    RegistrarMovimiento(cuenta);
                    
                    cr.Sucess = 1;
                    cr.Message = "Cuenta Creada correctamente";
                }
                else
                {
                    cr.Message = "La informacion no llego correctamente!";
                    cr.Sucess = 0;
                }

            }
            catch (Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;

        }
        
        [HttpPost("[action]")]
        public CustomeResponse ConsignacionCuenta([FromBody] MoviemientoProducto moviemiento)
        {
            CustomeResponse cr = new();
            try
            {
                if (moviemiento is not null)
                {
                    MoviemientoProducto  res = _context.MoviemientoProductosModel
                                        .Where(mp => mp.CuentaId == moviemiento.CuentaId)
                                        .OrderByDescending(mp => mp.FechaOperacion)
                                        .First();
                    float saldoActual = res.Saldo;
                    moviemiento.Saldo = moviemiento.Abonos + saldoActual;
                    moviemiento.Concepto = "Consignacion en linea"; 
                    _context.MoviemientoProductosModel.Add(moviemiento);
                    _context.SaveChanges();

                    cr.Sucess = 1;
                    cr.Message = "Se realizo la cosignacion correctamente";


                }
                else
                {
                    cr.Message = "La informacion no llego correctamente!";
                    cr.Sucess = 0;
                }

            }
            catch (Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;

        }


        [HttpPost("[action]")]
        public CustomeResponse RetirarCuenta([FromBody] MoviemientoProducto moviemiento)
        {
            CustomeResponse cr = new();
            try
            {
                if (moviemiento is not null)
                {
                    MoviemientoProducto res = _context.MoviemientoProductosModel
                                        .Where(mp => mp.CuentaId == moviemiento.CuentaId)
                                        .OrderByDescending(mp => mp.FechaOperacion)
                                        .First();
                    float saldoActual = res.Saldo;
                    moviemiento.Saldo = saldoActual- moviemiento.Cargos  ;
                    moviemiento.Concepto = "Retiro en linea";
                    _context.MoviemientoProductosModel.Add(moviemiento);
                    _context.SaveChanges();

                    cr.Sucess = 1;
                    cr.Message = "Se realizo la cosignacion correctamente";


                }
                else
                {
                    cr.Message = "La informacion no llego correctamente!";
                    cr.Sucess = 0;
                }

            }
            catch (Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;

        }

        private void RegistrarMovimiento(Cuenta cuenta)
        {
            MoviemientoProducto mp = new MoviemientoProducto();
            mp.CuentaId = cuenta.CuentaId;
            mp.Concepto = "Creacion Cuenta ahorros";
            mp.Abonos = cuenta.SaldoInicial;
            mp.Saldo = cuenta.SaldoInicial;
            mp.FechaOperacion = cuenta.FechaCreacion;
            _context.MoviemientoProductosModel.Add(mp);
            _context.SaveChanges();

        }


    }
}
