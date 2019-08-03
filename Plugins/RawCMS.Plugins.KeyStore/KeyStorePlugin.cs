﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Min�</author>
// <autogenerated>true</autogenerated>
//******************************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawCMS.Library.Core;
using RawCMS.Library.Core.Interfaces;
using RawCMS.Library.Service;
using RawCMS.Plugins.KeyStore;

namespace RawCMS.Plugins.GraphQL
{

    public class KeyStoreSettings
    {
    }
        public class KeyStorePlugin : RawCMS.Library.Core.Extension.Plugin, IConfigurablePlugin<KeyStoreSettings>
    {
        public override string Name => "KeyStore";

        public override string Description => "Add KeyStore capabilities";

        public override void Init()
        {
            Logger.LogInformation("KeyStore plugin loaded");
        }

        private KeyStoreService graphService = new KeyStoreService();

        public override void ConfigureServices(IServiceCollection services)
        {
          

            services.AddSingleton<KeyStoreService, KeyStoreService>();
        }

        private AppEngine appEngine;

        public override void Configure(IApplicationBuilder app, AppEngine appEngine)
        {
            this.appEngine = appEngine;

            
        }

        private IConfigurationRoot configuration;

        public override void Setup(IConfigurationRoot configuration)
        {
        
            this.configuration = configuration;
        }

        public KeyStoreSettings GetDefaultConfig()
        {
            return new KeyStoreSettings
            {
               
            };
        }

        private KeyStoreSettings config;

        public void SetActualConfig(KeyStoreSettings config)
        {
            this.config = config;
        }

        public override void ConfigureMvc(IMvcBuilder builder)
        {
          
        }
    }
}