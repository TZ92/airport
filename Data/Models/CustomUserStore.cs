using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Models
{
    public class CustomUserStore : UserStore<User, CustomRole, int,
    CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(Context context)
            : base(context)
        {
        }
    }
}
