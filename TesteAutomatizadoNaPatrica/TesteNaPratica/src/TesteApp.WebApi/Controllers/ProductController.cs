using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteApp.Application.Interfaces;
using TesteApp.Application.Validation;
using TesteApp.Domain.Entities;


namespace TesteApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IValidatoService _validatoService;
        private readonly IProductService _produtoService;

        public ProductController(IProductService produtoService, IValidatoService validatoService)
        {            
            _produtoService = produtoService;
            _validatoService = validatoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _produtoService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product) {

            List<string> result = await _validatoService.RunValidation(new ProductValidation(), product);

            if (_validatoService.ExistsError()) {
                return BadRequest(result); //StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return StatusCode(StatusCodes.Status200OK, "Model is valid for update!");
        }

    }
}
