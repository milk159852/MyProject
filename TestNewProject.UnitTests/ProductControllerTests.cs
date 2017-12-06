
using NUnit.Framework;
using NewProject.Controllers.api;

namespace TestNewProject.UnitTests
{
    [TestFixture]
    public class ProductControllerTests
    {
        [Test]
        [Ignore("Because I don't want to")]
        public void GetProducts_IdIsNULL_Return_NotFound()
        {
            var controller = new ProductsController();

            var result = controller.GetProducts(0);

            //Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        [Ignore("Because I don't want to")]
        public void GetProducts_IdIsNotNULL_Return_Ok()
        {

        }
    }
}
