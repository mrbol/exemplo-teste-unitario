using TesteApp.Application;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Validation;
using TesteApp.Domain.Entities;
using Xunit;
using NSubstitute;

namespace TestProjectNaPratica.Application
{
    public class ProdutoServiceTest
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;

        public ProdutoServiceTest()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productService = new ProductService(_productRepository);
        }

        [Fact(DisplayName = "Cadastrar um novo produto valido")]
        [Trait("Categoria", "Cadastrar - Produto")]
        public async void CriarProduto_ComSucesso_SemNotificacaoErro()
        {
            //Arrange
            Product productSucess = new Product()
            {
                Name = "Produto Teste",
                Description = "Descricao de Produto",
                Barcode = "198123654789",
                Rate = 10
            };

            IEnumerable<Product> productNull = new List<Product>();
            _productRepository.Search(p => p.Name == productSucess.Name).Returns(productNull);

            //Act
            Notifier errorNotification = await _productService.Create(productSucess);

            //Asset
            Assert.False(errorNotification.Exists());
        }

        [Fact(DisplayName = "Cadastrar um novo produto Invalido")]
        [Trait("Categoria", "Cadastrar - Produto")]
        public async void CriarProduto_Falha_ComNotificacaoErro()
        {
            //Arrange
            Product productfailure = new Product()
            {
                Name = "",
                Description = "Descricao de Produto",
                Barcode = "198123654789",
                Rate = 10
            };

            //Act
            Notifier errorNotification = await _productService.Create(productfailure);

            //Arrange
            Assert.True(errorNotification.Exists());
        }

        [Fact(DisplayName = "Atualizar um produto valido")]
        [Trait("Categoria", "Atualizar - Produto")]
        public async void AtualizarProduto_ComSucesso_SemNotificacaoErro()
        {
            //Arrange
            Product _productUpdate = new Product()
            {
                Id = 2,
                Name = "Atualizando",
                Description = "Descricao de Produto",
                Barcode = "198123654789",
                Rate = 10
            };

            IEnumerable<Product> productNull = new List<Product>();
            _productRepository.Get(_productUpdate.Id).Returns(_productUpdate);

            //Act
            Notifier errorNotification = await _productService.Update(_productUpdate.Id, _productUpdate);

            //Asset
            Assert.False(errorNotification.Exists());
        }

        [Fact(DisplayName = "Atualizar um produto invalido")]
        [Trait("Categoria", "Atualizar - Produto")]
        public async void AtualizarProduto_Falha_ComNotificacaoErro()
        {
            //Arrange
            Product productUpdate = new Product()
            {
                Id = 5,
                Name = "Atualizando",
                Description = "Descricao de Produto",
                Barcode = "198123654789",
                Rate = 10
            };

            Product productEmpty = new Product();
            _productRepository.Get(productUpdate.Id).Returns(productEmpty);

            //Act
            Notifier errorNotification = await _productService.Update(productUpdate.Id, productUpdate);

            //Asset
            Assert.True(errorNotification.Exists());
        }

        [Fact(DisplayName = "Apagar um produto valido")]
        [Trait("Categoria", "Apagar - Produto")]
        public async void ApagarrProduto_ComSucesso_RetornaTrue()
        {

            //Arrange
            Product productDelete = new Product()
            {
                Id = 2,
                Name = "Atualizando",
                Description = "Descricao de Produto",
                Barcode = "198123654789",
                Rate = 10
            };
            _productRepository.Get(productDelete.Id).Returns(productDelete);
            _productRepository.Delete(productDelete.Id).Returns(1);

            //Act
            bool sucesso = await _productService.Delete(productDelete.Id);

            //Assert
            Assert.True(sucesso);
        }

        [Fact(DisplayName = "Apagar um produto invalido")]
        [Trait("Categoria", "Apagar - Produto")]
        public async void ApagarrProduto_FalhaCom_RetornoFalse()
        {
            //Arrange
            int id = 2;
            Product productEmpty = new Product();
            _productRepository.Get(id).Returns(productEmpty);

            //Act
            bool falha = await _productService.Delete(id);

            //Assert
            Assert.False(falha);
        }
    }

}
