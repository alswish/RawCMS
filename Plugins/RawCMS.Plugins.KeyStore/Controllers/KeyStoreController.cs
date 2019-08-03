﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using RawCMS.Library.Core.Attributes;
using RawCMS.Plugins.KeyStore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RawCMS.Plugins.KeyStore.Controllers
{
    [AllowAnonymous]
    [RawAuthentication]
    [Route("api/[controller]")]
    public class KeyStoreController : Controller
    {
        KeyStoreService service;

        public KeyStoreController(KeyStoreService service)
        {
            this.service = service;
        }

        
        [HttpHead("{key}")]
        public void Get(string key)
        {
           // var content = new OkResult();
            var result = new StringValues(new string[] { this.service.Get(key) as string });
            Response.Headers.Add("r", result);
            //return content;
        }


        
        [HttpPost()]
        public void Set([FromBody]KeyStoreInsertModel insert)
        {
            
               this.service.Set(insert);
           

           // return new  OkResult();
        }
    }
}