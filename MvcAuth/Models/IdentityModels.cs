using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcAuth.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser // Trainer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Photo { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        //public List<Honors> Honors { get; set; } // подтягивать в модели?
        //public List<Client> PastClients { get; set; } // подтягивать в модели?
        //public List<Client> CurrentClients { get; set; } // подтягивать в модели?
        //public List<Client> RequestsToBeClient { get; set; } // подтягивать в модели?
        //public List<Reference> ReferencesToOtherServices { get; set; } // подтягивать в модели?
        public string AboutMe { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }

        public string Town { get; set; }
        public System.DateTime? BirthDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<>

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {            
            return new ApplicationDbContext();
        }
    }
}