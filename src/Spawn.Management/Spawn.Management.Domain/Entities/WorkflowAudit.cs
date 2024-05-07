using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spawn.Common.Domain.Entities;

namespace Spawn.Management.Domain.Entities
{
    public class WorkflowAudit : BaseAuditEntity<int>
    {
        public WorkflowAudit() { }
        
        public WorkflowAudit(Workflow workflow)
        {
            this.workflow = workflow;
        }

        public Workflow workflow { get; set; }
    }
}
