using BookManagementSystem.Core.IRepostories;
using BookManagementSystem.Core.IService;
using BookManagementSystem.Resource.Repostories;
using BookManagementSystem.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.utility.DIResolver
{
   public class DIResolver
    {
        public static void ConfgurationServices(IServiceCollection service)
        {
            service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<IServiceBookManagement, BookDetailsService>();
            service.AddScoped<IRepostoriesBookManagement, BookManagemtRepostories>();
        }
    }
}
