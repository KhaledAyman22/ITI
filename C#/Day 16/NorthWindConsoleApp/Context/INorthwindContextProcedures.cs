﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWindConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWindConsoleApp.Context
{
    public partial interface INorthwindContextProcedures
    {
        Task<List<CustOrderHistResult>> CustOrderHistAsync(string CustomerID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateProductNameByProductIDAsync(int? ProductID, string ProductName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}