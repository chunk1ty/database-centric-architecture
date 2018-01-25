using DCA.Entities;
using DCA.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Persistence
{
    public class DCADbContext : DbContext, IUnitOfWork
    {
        public DCADbContext() 
            : base("DCAArchitecture")
        {           
        }

        public IDbSet<Product> Products { get; set; }             

        public void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
