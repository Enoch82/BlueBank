using Microsoft.AspNetCore.Mvc;
using CarroDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroDeCompras.Controllers
{

    public class LoginController : Controller
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public CustomeResponse ValidandoUsuario(string  emailUser, string password)
        {
            CustomeResponse cr = new();
            try
            {
                if (emailUser is not null && password is not null)
                {
                  
                }
                else
                {
                    cr.Message = "Informacion de usuario no recibida";
                    cr.Sucess = 0;
    
            }
            }catch(Exception ex)
            {
                cr.Message = ex.Message;
                cr.Sucess = 0;
            }
            return cr; 
        }
    }
}
