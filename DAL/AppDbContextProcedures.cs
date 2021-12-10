﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public partial class AppDbContext
    {
        private AppDbContextProcedures _procedures;

        public virtual AppDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new AppDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public AppDbContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class AppDbContextProcedures
    {
        private readonly AppDbContext _context;

        public AppDbContextProcedures(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<usp_getproductResult>> usp_getproductAsync(int? ProductId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = ProductId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_getproductResult>("EXEC @returnValue = [dbo].[usp_getproduct] @ProductId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
