﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RawCMS.Library.Core.Interfaces
{
    public interface IConfigurableMiddleware<T>
    {
        string Name { get; }

        string Description { get; }

        Task InvokeAsync(HttpContext context);
    }
}
