using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spawn.Management.Domain.Abstractions;
using Spawn.Management.Domain.Entities;
using Spawn.Management.Infrastructure.Persistance;

namespace Spawn.Management.Application.Services
{
    public class WorkflowService : IWorkflowService
    {

        /// <summary>
        /// Factory to generate <see cref="DocsContext"/> instances.
        /// </summary>
        private readonly IDbContextFactory<WorkflowContext> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        public WorkflowService(IDbContextFactory<WorkflowContext> factory) =>
            this.factory = factory;

        public async Task<int> CreateWorkflowAsync(Workflow workflow)
        {
            using var context = factory.CreateDbContext();

            context.Add(workflow);

            var response = await context.SaveChangesAsync();

            return response;
        }
    }
}
