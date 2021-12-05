using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Security.Claims;
using Login.Context;

namespace Login.Custom
{
    public class CustomClaimPrincipal : ClaimsPrincipal
    {
        private readonly usersContext _context;

        public CustomClaimPrincipal(usersContext context)
        {
            _context = context;
        }

    }
}
