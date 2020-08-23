using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto {Codigo = 1, Nome = "Nokia Lumia", Categoria = "Celulares", Valor = 699.99M },
            new Produto {Codigo = 2, Nome = "Samsung Galaxy", Categoria = "Celulares", Valor = 1199.99M },
            new Produto {Codigo = 3, Nome = "Teclado", Categoria = "Informática", Valor = 139.99M },
            new Produto {Codigo = 4, Nome = "Mouse", Categoria = "Informática", Valor = 59.95M },
            new Produto {Codigo = 5, Nome = "Case GoPro", Categoria = "Acessórios", Valor = 65.00M },

        };

        //https://localhost:44349/api/v1/produto
        public IEnumerable<Produto> GetTodos()
        {
            return produtos;
        }

        //https://localhost:44349/api/v1/produto?id=1
        public IHttpActionResult Get(int Codigo)
        {
            var produto = produtos.FirstOrDefault(p => p.Codigo == Codigo);
            if(produto == null)
            {
                return NotFound();
            }
            else
            {
                //return Ok(produto); //retorna xml
                return Json<Produto>(produto); //retorna json
            }
        }

        //https://localhost:44349/api/v1/produto?categoria=celulares
        public IEnumerable<Produto> GetPorCategoria(string categoria)
        {
            return produtos.Where(p => string.Equals(p.Categoria,categoria, StringComparison.OrdinalIgnoreCase));
        }

        public IHttpActionResult Post([FromBody] Produto produto)
        {
            return Ok(produto);
        }

        public IHttpActionResult Put([FromBody] Produto produto)
        {
            return Ok(produto);
        }

        public IHttpActionResult Delete(int Codigo)
        {
            return Ok();
        }
    }
}
