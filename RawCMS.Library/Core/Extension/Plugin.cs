﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawCMS.Library.Core.Interfaces;

namespace RawCMS.Library.Core.Extension
{
    /// <summary>
    /// RawCMS plugin definition
    /// </summary>
    public abstract class Plugin : IRequireApp, IInitable
    {
        public virtual int Priority { get; internal set; } = 1;
        public abstract string Name { get; }
        public abstract string Description { get; }
        public ILogger Logger { get => logger; private set => logger = value; }
        public AppEngine Engine => engine;

        private AppEngine engine;
        private ILogger logger;

        public void SetAppEngine(AppEngine manager)
        {
            engine = manager;
            Logger = Engine.GetLogger(this);
        }

        public virtual void OnPluginLoaded()
        {
            Logger.LogInformation($"Plugin {Name} is loaded!");

        }
        /// <summary>
        /// startup application event
        /// </summary>
        public virtual void OnApplicationStart()
        {
            Logger.LogInformation($"Plugin {Name} is notified about app starts");
        }

        public abstract void Init();

        /// <summary>
        /// this allow plugin to register its own services
        /// </summary>
        /// <param name="services"></param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            Logger.LogInformation(this.GetType().FullName + " hit ConfigureServices");
        }

        /// <summary>
        /// this allow the plugin to interact with appengine and application builder
        /// </summary>
        /// <param name="app"></param>
        /// <param name="appEngine"></param>
        public virtual void Configure(IApplicationBuilder app, AppEngine appEngine)
        {
            //DO NOTHING
            Logger.LogInformation(this.GetType().FullName + " hit Configure");
        }

        /// <summary>
        /// this metod receive configuration to allow plugin configure itself
        /// </summary>
        /// <param name="configuration"></param>
        public virtual void Setup(IConfigurationRoot configuration)
        {
            //DO NOTHING
            Logger.LogInformation(this.GetType().FullName + " hit Setup");
        }
    }
}