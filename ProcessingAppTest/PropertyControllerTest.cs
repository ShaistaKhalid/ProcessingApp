using Microsoft.AspNetCore.Mvc;
using ProcessingApp.Controllers;
using ProcessingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProcessingAppTest
{
    public class PropertyControllerTest
    {
        [Fact]
        public async void Test1()
        {
            //Arrange
            var dbContext = MockDb.CreateMockDb();
            PropertyController propertyController = new PropertyController(dbContext);
            //Act
            var res = await propertyController.Index();
            //Assert
            var result = Assert.IsType<ViewResult>(res);
            var model = Assert.IsAssignableFrom<List<PropertyModel>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());
        }
    }
}
