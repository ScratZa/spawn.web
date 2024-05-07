using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spawn.Common.Domain.Entities;
using Spawn.Management.Domain.Entities;

namespace Spawn.Management.Domain.Events
{
    public class WorkflowCreatedEvent :BaseEvent
    {
        public WorkflowCreatedEvent(Workflow workflow)
        {
            Workflow = workflow;
        }

        public Workflow Workflow { get; }
    }
}
