using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Identity
{
    public class ApplicationUserClaimsPrincipleFactory : 
        UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipleFactory(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options) 
            : base (userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity =  await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("UserName", user.UserName));
            identity.AddClaim(new Claim("PhoneNumber", user.PhoneNumber));

            return identity;
        }
    }
}
