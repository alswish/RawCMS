using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System.Linq;
using RawCMS.Library.Service;
using RawCMS.Plugins.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RawCMS.Library.DataModel;

namespace RawCMS.Plugins.Core.Services
{
    public class StatsService
    {
        private ApiCallStats _Stats;
        private DateTime _ExpiresOn;
        public int ExpirationMinutes = 5;
        private readonly MongoService _mongoService;

        public StatsService(MongoService mongoService)
        {
            this._mongoService = mongoService;
        }

        public bool IsExpired()
        {
            return _ExpiresOn < DateTime.Now;
        }

        private void ExecuteQuery()
        {
            _ExpiresOn = DateTime.Now.AddMinutes(ExpirationMinutes);

            //query
            var t = this._mongoService.GetClient();
        }


        private void BeforeCall()
        {
            if (IsExpired())
                ExecuteQuery();
        }

        public ApiCallStats GetCount()
        {
            BeforeCall();
            return this._Stats;
        }
    }
}
