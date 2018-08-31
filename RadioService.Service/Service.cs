namespace ExampleService.Service
{
	using System;
	using System.Diagnostics;
	using System.ServiceProcess;
	using Core;
	using Microsoft.Practices.Unity;

	public partial class Service : ServiceBase
	{
		private IUnityContainer unity;

		public Service()
		{
			InitializeComponent();
		}

		public void RunAsConsole(string[] args)
		{
			Trace.Listeners.Add(new ConsoleTraceListener());

			OnStart(args);
			Console.WriteLine("Running RadioService as console. Esc to exit.");
			Console.WriteLine($"Listening at {Settings.BaseAddress}");
			MainLoop();
			OnStop();
		}

		protected override void OnStart(string[] args)
		{
			this.unity = new UnityContainer();
			this.unity.RegisterType<Bootstrapper>(new ContainerControlledLifetimeManager());
			var bootstrapper = this.unity.Resolve<Bootstrapper>();
			bootstrapper.Initialise();
		}

		protected override void OnStop()
		{
			if (this.unity != null)
			{
				this.unity.Dispose();
				this.unity = null;
			}
		}

		private static void MainLoop()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape || key == ConsoleKey.Q)
                    {
                        return;
                    }
                }
            }
        }
	}
}
