using FullStack.API.Controllers;
using FullStack.API.Repository;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace FullStack.Tests
{
    [TestClass]
    public class CategoryTests
    {
        private  ICategoriaRepository _categoriaRepository;
        private  CategoriaController _categoriaController;
        private IConfiguration _configuration;

        [TestInitialize]
        public void Setup()
        {

            var inMemorySettings = new Dictionary<string, string> {
                { "dbConection", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" } };
              _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
            _categoriaRepository = new CategoriaRepository(_configuration);
            _categoriaController = new CategoriaController(_categoriaRepository); 
        
        }

      
       
        [TestMethod]
        public void TestGetById()
        {
          var cat =    _categoriaRepository.ObterPorId(1);
          Assert.AreEqual(cat.Nome, "Eletronicos");
        }

        [TestMethod]
        public void TestGetAll()
        {
            var liSTA = _categoriaRepository.ObterTodos();
            Assert.IsTrue(liSTA.Count() > 0);
        }
    }
}