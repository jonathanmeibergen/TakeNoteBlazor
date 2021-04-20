using TakeNoteBlazor.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server.Models;

namespace TakeNoteBlazor.Server.Data
{
        public class TakeNoteContext : ApiAuthorizationDbContext<TakeNoteUser>
        {
            public TakeNoteContext(
                DbContextOptions options,
                IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
            {
            }
            public DbSet<Note> Notes { get; set; }
        }
}
