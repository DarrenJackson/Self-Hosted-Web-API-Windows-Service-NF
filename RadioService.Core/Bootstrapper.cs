namespace ExampleService.Core
{
	using Microsoft.Owin.Hosting;
	using Microsoft.Practices.Unity;

	public class Bootstrapper
    {
	    private readonly IUnityContainer container;

	    public Bootstrapper(IUnityContainer container)
	    {
		    this.container = container;
	    }

	    public void Initialise()
	    {
		    WebApp.Start<Startup>(url: Settings.BaseAddress);
	    }
    }
}
