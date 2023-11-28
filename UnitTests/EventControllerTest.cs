using lesson4_createApi;
using lesson4_createApi.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace UnitTests
{
    public class EventControllerTest
    {
         private readonly EventController _controllersTest ;
        public EventControllerTest()
        {
            var context=new DataContextFake();
            _controllersTest = new EventController(context);
        }
        [Fact]
        public void Get_OkObj()
        {
          //  var id = 20;
            var result = _controllersTest.Get();
          Assert.IsType<OkObjectResult>(result);
        
        }

        [Fact]
        public void Get_OkObjId()
        {
             var id = 20;
            var result = _controllersTest.Get(id);
            Assert.IsType<NotFoundResult>(result);
            
        }
        [Fact]
        public void Pos_isNotEmptyOrNull()
        {
            
            var result = _controllersTest.Post(new Event());
            // Assert
            Assert.IsType<BadRequestResult>(result);

        }
        [Fact]
        public void delete_NotNull()
        {
            var id = 1;
            var result = _controllersTest.Delete(id);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Put_NotNull()
        {
            var id = 1;
            Event ev = new Event();
            var result = _controllersTest.Put(id,ev);
            //תוצאה לא מורשית
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}