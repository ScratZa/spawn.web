using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spawn.Management.Domain.Entities;

namespace Spawn.Management.Domain.Abstractions
{
    public interface IWorkflowService
    {
        Task<int> CreateWorkflowAsync(Workflow workflow);
    }
}
