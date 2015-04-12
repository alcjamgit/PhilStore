using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhilStore.DAL.Models;

namespace PhilStore.DAL.Specifications
{
    public interface IAppDbContext
    {
        IDbSet<Advertisement> Advertisements { get; set; }
        int SaveChanges();
        void Dispose(bool disposing);
        DbEntityEntry Entry(object entity); //used by Edit Actions
    }
}
