namespace ExampleService.Core
{
	using System.Collections.Generic;
	using System.Web.Http;

	public class TestController : ApiController
	{
		[HttpGet]
		[Route("api/hello")]
        public IEnumerable<string> HelloWorld()
        {
            return new string[] { "Hello", "World!" };
        }
	}
}
