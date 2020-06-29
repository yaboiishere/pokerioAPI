using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokerioAPI.Models {
    public class DataContext : IdentityDbContext<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> {
        public DataContext() : base("ConnectionStringLocal") { }
    }
}
