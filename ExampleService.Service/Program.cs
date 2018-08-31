namespace ExampleService.Service
{
	using System;
	using System.ServiceProcess;

	internal static class Program
	{
		private static void Main(string[] args)
		{
			if (Environment.UserInteractive)
			{
				var service = new Service();
				service.RunAsConsole(args);
			}
			else
			{
				var servicesToRun = new ServiceBase[]
				{
					new Service()
				};

				ServiceBase.Run(servicesToRun);
			}
		}
	}
}
