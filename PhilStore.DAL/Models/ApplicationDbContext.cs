using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhilStore.DAL.Specifications;


namespace PhilStore.DAL.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDbContext
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create() {return new ApplicationDbContext();}

        #region IdentityDbContext<ApplicationUser> Methods
        //Expose methods of IdentityDbContext<ApplicationUser> so the interface can make it required
        public new void Dispose() 
        {
            base.Dispose();
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Advertisement> Advertisements { get; set; }

    }
}