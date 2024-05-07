using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Spawn.Management.Domain.Entities;


namespace Spawn.Management.Infrastructure.Persistance
{
        public sealed class WorkflowContext :DbContext
        {
            public const string PartitionKey = nameof(PartitionKey);

            private const string Meta = nameof(Meta);

            public WorkflowContext(DbContextOptions<WorkflowContext> options)
                : base(options) =>
                    SavingChanges += WorkflowContext_SavingChanges;
            public DbSet<Workflow> Workflow { get; set; }
            public override void Dispose()
            {
                SavingChanges -= WorkflowContext_SavingChanges;
                base.Dispose();
            }
            public override ValueTask DisposeAsync()
            {
                SavingChanges -= WorkflowContext_SavingChanges;
                return base.DisposeAsync();
            }

            /// <summary>
            /// Configure the model that maps the domain to the backend.
            /// </summary>
            /// <param name="modelBuilder">The API for model configuration.</param>
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("Store");
            #endregion

            #region Container
            modelBuilder.Entity<Workflow>()
                .ToContainer("Workflows");
            #endregion

            #region NoDiscriminator
            modelBuilder.Entity<Workflow>()
                .HasNoDiscriminator();
            #endregion

            #region PartitionKey
            modelBuilder.Entity<Workflow>()
                .HasPartitionKey(o => o.Id);
            #endregion

            #region ETag
            modelBuilder.Entity<Workflow>()
                .UseETagConcurrency();
            #endregion

            #region PropertyNames
            //modelBuilder.Entity<Order>().OwnsOne(
            //    o => o.ShippingAddress,
            //    sa =>
            //    {
            //        sa.ToJsonProperty("Address");
            //        sa.Property(p => p.Street).ToJsonProperty("ShipsToStreet");
            //        sa.Property(p => p.City).ToJsonProperty("ShipsToCity");
            //    });
            #endregion

        }



        /// <summary>
        /// Intercepts saving changes to store audits.
        /// </summary>
        /// <param name="sender">The sending context.</param>
        /// <param name="e">The change arguments.</param>
        private void WorkflowContext_SavingChanges(
                object sender,
                SavingChangesEventArgs e)
            {
                var entries = ChangeTracker.Entries<Workflow>()
                    .Where(
                        e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified)
                    .Select(e => e.Entity)
                    .ToList();
            }
        }
}
