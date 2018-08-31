namespace ExampleService.Core
{
	using System.Web.Http;
	using Owin;

	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			//config
			//	.EnableSwagger(c => c.SingleApiVersion("v1", "TelephonyGateway"))
			//	.EnableSwaggerUi();
			//UnityConfig.RegisterComponents(config);
			var scope = config.DependencyResolver.BeginScope();
			config.MapHttpAttributeRoutes();
			//config.Filters.Add((ExceptionFilterAttribute)scope.GetService(typeof(ExceptionFilterAttribute)));
			//config.Filters.Add(new ArgumentsNotNullFilterAttribute());
			//config.MessageHandlers.Add((MessageLoggingHandler)scope.GetService(typeof(MessageLoggingHandler)));
			app.UseWebApi(config);
			//app.MapSignalR("/api", new HubConfiguration());
		}
	
	}
}
