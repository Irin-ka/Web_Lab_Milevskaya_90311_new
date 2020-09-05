using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web_Lab_Milevskaya_90311.Controllers;
using Web_Lab_Milevskaya_90311.DAL.Entities;
using Xunit;

namespace Web_Lab_Milevskaya_90311.Tests
{
    public class ProductControllerTests
    {
        //[Theory]
        //[MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        //public void ControllerGetsProperPage(int page, int qty, int id)
        //{
        //    // Arrange             
        //    var controller = new ProductController();

        //    controller._dishes = TestData.GetDishesList();

        //    // Act 
        //    var result = controller.Index(pageNo: page, group: null) as ViewResult;
        //    var model = result?.Model as List<Dish>;

        //    // Assert 
        //    Assert.NotNull(model);
        //    Assert.Equal(qty, model.Count);
        //    Assert.Equal(id, model[0].DishId);
        //}

        [Fact]
        public void ControllerSelectsGroup()
        {
            // Контекст контроллера
            var controllerContext = new ControllerContext();
        // Макет HttpContext
        var moqHttpContext = new Mock<HttpContext>();
        moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;
            var controller = new ProductController()
            { ControllerContext = controllerContext };
        }

    }

    

}
