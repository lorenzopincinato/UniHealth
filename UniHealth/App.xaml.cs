using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using UniHealth.Application;
using UniHealth.Application.Applications;
using UniHealth.Application.Repositories;

namespace UniHealth
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow(ServiceProvider.GetService<IUsuarioApplication>());
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => new DbUniHealthContext());

            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IStatusUsuarioRepository, StatusUsuarioRepository>();
            services.AddSingleton<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddSingleton<IIMCRepository, IMCRepository>();

            services.AddSingleton<IUsuarioApplication, UsuarioApplication>();
            services.AddSingleton<IAlimentoApplication, AlimentoApplication>();
        }
    }
}
