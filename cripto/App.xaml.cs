﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace cripto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       // private ServiceProvider serviceProvider;
    
        public App()
        {
           // ServiceCollection services = new ServiceCollection();
            //ConfigureServices(services);
            //serviceProvider = services.BuildServiceProvider();
        }

       /* private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ICryptoClient, CryptoClient>();
        }*/
    }
}
