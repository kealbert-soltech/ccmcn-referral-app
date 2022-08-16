using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReferralApp.Models;

namespace ReferralApp.Data
{
    public class ReferralAppContext : DbContext
    {
        public ReferralAppContext (DbContextOptions<ReferralAppContext> options)
            : base(options)
        {
        }

        public DbSet<ReferralApp.Models.Referral> Referral { get; set; }
    }
}
