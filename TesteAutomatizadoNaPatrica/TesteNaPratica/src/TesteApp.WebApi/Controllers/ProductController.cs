using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Entities;


namespace TesteApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductService _produtoService;

        public ProductController(IProductService produtoService)
        {            
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _produtoService.GetAll();
        }
    }
}
