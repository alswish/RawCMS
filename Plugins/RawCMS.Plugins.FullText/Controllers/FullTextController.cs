﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RawCMS.Library.Core.Attributes;
using RawCMS.Plugins.Core.Model;
using RawCMS.Plugins.FullText.Core;
using System;
using System.Collections.Generic;

namespace RawCMS.Plugins.FullText.Controllers
{
    public class LocalError
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    //TO BE FIXED ON PLUGIN LOADING
    public class LocalRestMessage<T>
    {
        public List<LocalError> Errors { get; set; } = new List<LocalError>();
        public List<LocalError> Warnings { get; set; } = new List<LocalError>();
        public List<LocalError> Infos { get; set; } = new List<LocalError>();

        public RestStatus Status { get; set; }

        public T Data { get; set; }

        public LocalRestMessage(T item)
        {
            Data = item;
        }
    }

    [AllowAnonymous]
    [RawAuthentication]
    [Route("api/[controller]")]
    public class FullTextController : Controller
    {
        protected FullTextService service;

        public FullTextController(FullTextService service)
        {
            this.service = service;
        }

        [HttpGet()]
        [Route("index/{index}")]
        public LocalRestMessage<bool> CreateIndex(string index)
        {
            var result = new LocalRestMessage<bool>(true);
            try
            {
                this.service.CreateIndex(index);
            }
            catch (Exception err)
            {
                result.Data = false;
                result.Errors.Add(new LocalError()
                {
                    Code = "001",
                    Title = "Unknow issue",
                    Description = err.Message
                });
            }
            return result;
        }

        [HttpPost()]
        [Route("doc/{index}")]
        public LocalRestMessage<bool> IndexDocument([FromRoute]string index, [FromBody] JObject item)
        {
            var result = new LocalRestMessage<bool>(true);
            try
            {
                this.service.AddDocumentRaw(index, item);
            }
            catch (Exception err)
            {
                result.Data = false;
                result.Errors.Add(new LocalError()
                {
                    Code = "001",
                    Title = "Unknow issue",
                    Description = err.Message
                });
            }
            return result;
        }

        [HttpGet()]
        [Route("doc/{index}/{id}")]
        public LocalRestMessage<JObject> GetDocument([FromRoute]string index, [FromRoute]string id)
        {
            var result = new LocalRestMessage<JObject>(null);
            try
            {
                result.Data = this.service.GetDocumentRaw(index, id);
            }
            catch (Exception err)
            {
                result.Errors.Add(new LocalError()
                {
                    Code = "001",
                    Title = "Unknow issue",
                    Description = err.Message
                });
            }
            return result;
        }

        [HttpGet]
        [Route("doc/search/{index}")]
        public LocalRestMessage<List<JObject>> Search([FromRoute] string index, string searchQuery, int start = 0, int size = 20)
        {
            var result = new LocalRestMessage<List<JObject>>(null);
            try
            {
                result.Data = this.service.SearchDocumentsRaw(index, searchQuery, start, size);
            }
            catch (Exception err)
            {
                result.Errors.Add(new LocalError()
                {
                    Code = "001",
                    Title = "Unknow issue",
                    Description = err.Message
                });
            }
            return result;
        }

        [HttpDelete]
        [Route("doc/{index}/{id}")]
        public LocalRestMessage<bool> DeleteDocument(string index, string id)
        {
            var result = new LocalRestMessage<bool>(true);
            try
            {
                this.service.DeleteDocument(index, id);
            }
            catch (Exception err)
            {
                result.Data = false;
                result.Errors.Add(new LocalError()
                {
                    Code = "001",
                    Title = "Unknow issue",
                    Description = err.Message
                });
            }
            return result;
        }
    }
}