namespace battleships_state_tracker.IoC
{
	using System.Reflection;

	using Autofac;

	using battleships_state_tracker.Domain;
	using battleships_state_tracker.Interfaces;

	using log4net;

	public class AppRegistration
	{
		public IContainer Register()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<Player>().As<IPlayer>().InstancePerLifetimeScope();
			builder.RegisterType<Board>().As<IBoard>().InstancePerLifetimeScope();
			builder.Register(logger => LogManager.GetLogger(MethodBase.GetCurrentMethod().ReflectedType)).As<ILog>();

			IContainer container = builder.Build();
			return container;
		}
	}
}
