using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.wwwroot.lib.cookie
{
    public class Cookie
    {
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        public Cookie(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /*
         * CRUD - Cadastrar/Atualizar/Consultar/Remover - RemoverTodos/Exist
         */
        public void Cadastrar(string Key, string Valor)
        {
            CookieOptions Options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7)
            };
           // Options.IsEssential = true;

            //var ValorCrypt = StringCipher.Encrypt(Valor, _configuration.GetValue<string>("KeyCrypt"));

            //_context.HttpContext.Response.Cookies.Append(Key, ValorCrypt, Options);

            _context.HttpContext.Response.Cookies.Append(Key, Valor);
        }
        public void Atualizar(string Key, string Valor)
        {
            if (Existe(Key))
            {
                Remover(Key);
            }
            Cadastrar(Key, Valor);
        }
        public void Remover(string Key)
        {
            _context.HttpContext.Response.Cookies.Delete(Key);
        }
        public string Consultar(string Key)//, bool Cript = true)
        {
            var valor = _context.HttpContext.Request.Cookies[Key];

            //if (Cript)
            //{
            //    valor = StringCipher.Decrypt(valor, _configuration.GetValue<string>("KeyCrypt"));
            //}
            return valor;
        }


        public bool Existe(string Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null)
            {
                return false;
            }

            return true;
        }
        public void RemoverTodos()
        {
            var ListaCookie = _context.HttpContext.Request.Cookies.ToList();
            foreach (var cookie in ListaCookie)
            {
                Remover(cookie.Key);
            }

        }
    }
}
