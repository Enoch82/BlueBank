using CarroDeCompras.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly MyDbContext _context;

        public ClienteController(MyDbContext context)
        {
            _context = context;
        }
  

        [HttpPost("[action]")]
        public CustomeResponse CrearCliente([FromBody] Cliente cliente)
        {
            CustomeResponse cr = new CustomeResponse();
            try
            {
                if(cliente is not null)
                {
                    _context.ClienteModel.Add(cliente);
                    _context.SaveChanges();
                    cr.Message = "Cliente Creado";
                    cr.Sucess = 1;
                    cr.Data = cliente;

                }
                else
                {
                    cr.Message = "Informacion del Cliente no recibida";
                    cr.Sucess = 0;
                }
                

            }
            catch(Exception ex) 
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;
        }

        [HttpGet("[action]")]
        public CustomeResponse ObtenerListaClientes()
        {
            CustomeResponse cr = new();
            try
            {
                cr.Data = _context.ClienteModel.ToList();
                cr.Sucess = 1; 
            }
            catch(Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;
        }


        [HttpPost("[action]")]
        public CustomeResponse Login([FromBody] Cliente cliente)
        {
            CustomeResponse cr = new();
            try
            {
                if(cliente.Email is not null && cliente.Password is not null)
                {

                    Cliente clienteModel =  _context.ClienteModel.Where(
                        c => (
                         c.Estado == true &&
                         c.Email == cliente.Email &&
                         c.Password == cliente.Password
                        )).FirstOrDefault();

                    if(clienteModel is not null)
                    {
                        cr.Data = clienteModel;
                        cr.Message = "Obteniendo Informacion del Cliente";
                        cr.Sucess = 1;
                    }
                    else
                    {
                        cr.Message = "La informacion es incorrecta";
                        cr.Sucess = 0;
                    }
                   
                }
                else
                {
                    cr.Message = "La informacion es incorrecta";
                    cr.Sucess = 0;
                }
                
                
            }catch(Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;
        }

        [HttpGet("[action]")]
        public CustomeResponse ListaCuentasClienteId(int clienteId)
        {
            CustomeResponse cr = new();
            try
            {
                if (clienteId != 0)
                {
                    List<Cuenta> cuentaCliente = _context.CuentaModel.Where(c => c.ClienteId == clienteId).ToList();
                    if (cuentaCliente.Count > 0)
                    {
                        cr.Data = cuentaCliente;
                        cr.Message = "Se ha encontrado la informacion del cliente";
                        cr.Sucess = 1;
                    }
                    else
                    {
                        cr.Sucess = 1;
                        cr.Message = "El usuario no tiene cuentas!";
                    }
                    
                }
                else
                {
                    cr.Sucess = 0;
                    cr.Message = "No se encontro ninguna informacion";
                }

            }
            catch (Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr;
        }
    }
}
