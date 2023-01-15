# 🛠 Teste Unitário

Implementando Testes unitários com .NET Core: Mocking com NSubstitute

### Recursos utilizados

- ASP.NET Core 6 WebApi
- Biblioteca .NET Core 6 
- Entity Framework Core
- Operações CRUD 
- FluentValidation
- Swagger
- NSubstitute
- Inversão de Dependência
- XUnit.

Um dos desafios comuns quando escrevemos testes de unidade é isolar as dependências para conseguir testar apenas a unidade que desejamos. Para tal, utilizamos uma estratégia de criar objetos "falsos" ou Mock Objects para essas dependências.

Neste projeto você vai encontrar implementação utilizando a biblioteca NSubstitute. Para entender como tudo funciona precisamos entender alguns conceitos. São eles:

#### Princípio de Inversão de Dependência: 
Princípio do SOLID que diz respeito a que um módulo de alto nível não deve depender de um módulo de baixo nível. Na prática, classes não devem depender de implementações, e sim de interfaces. Quando a implementação for alterada, considerando que as classes dependam de interfaces dessas classes concretas, alterações não seriam necessárias.

#### Mocks: 
São objetos que simulam o comportamento de objetos reais. Podem definir retornos específicos em seus métodos, de maneira que a classe a consumir eles nem note que algo foi alterado.

Assim como o Moq, o NSubstitute permite criar objetos baseados em interfaces, e definir contratos de retorno determinísticos. Por exemplo, consigo definir que um método de uma interface de Repositório retorne uma lista fixa, ou que retorne uma exceção quando invocado.

### 🔨 Veja os métodos principais do NSubstitute 
Segue a lista dos métodos principais do NSubstitute.

##### Substitute.For<T>: 
Permite a criação de um objeto substituto de tipo T, onde T ou deve ser uma interface, ou com classes e seus membros que permitam override.
##### Método(a, b).Returns(c): 
define o comportamento de método Método, com os parâmetros a e b, que retornaria o valor c.
##### Received().Método(a, b): 
verifica se o objeto substituto recebeu uma chamada do método Método com os parâmetros passados a e b.
##### DidNotReceive().Método(a, b): 
Verifica se o objeto substituto não recebeu uma chamada do método Método com os parâmetros passados a e b.

### Escrevendo o teste unitário
Com o código a ser testado devidamente implementado, é criada uma classe de teste, no projeto. Seguindo o padrão AAA (Arrange, Act, Assert).

#### Construtor
```
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;

        public ProdutoServiceTest()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productService = new ProductService(_productRepository);
        }
```
#### Teste
```
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
```



### 📒 Documentação do NSubstitute
https://nsubstitute.github.io/help/getting-started/
  
💡 Não esqueça de rodar os script de migração no PowerShell

Update-Datase -Verbose


