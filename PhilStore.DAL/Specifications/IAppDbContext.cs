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
    public interface IAppDbContext: IDisposable
    {
        IDbSet<Advertisement> Advertisements { get; set; }

        #region DbContextMethods
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        
        #endregion

    }
}
