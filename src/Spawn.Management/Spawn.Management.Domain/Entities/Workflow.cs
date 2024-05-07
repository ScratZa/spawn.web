using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spawn.Common.Domain.Entities;
using Spawn.Management.Domain.Events;

namespace Spawn.Management.Domain.Entities
{
    public class Workflow : BaseAuditEntity<int>
    {
        public string? Command { get; set; }

        public string? Name { get; set; }

        public Workflow(string command , string name)
        {
            Command = command;
            Name = name;

            AddDomainEvent(new WorkflowCreatedEvent(this));
        }

    }
}
