using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spawn.Management.Domain.Abstractions;
using Spawn.Management.Domain.Entities;
using Spawn.Management.Domain.Events;
using Spawn.Management.Infrastructure.Persistance;

namespace Spawn.Management.Application.Commands
{
    public class CreateWorkflowCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Command { get; set; }
    }

    public class CreateWorkflowCommandHandler : IRequestHandler<CreateWorkflowCommand, int>
    {
        private readonly IWorkflowService _service;

        public CreateWorkflowCommandHandler(IWorkflowService service)
        {
            _service = service;
        }

        public async Task<int> Handle(CreateWorkflowCommand request, CancellationToken cancellationToken)
        {
            var entity = new Workflow(request.Name, request.Command);

            entity.AddDomainEvent(new WorkflowCreatedEvent(entity));

            await _service.CreateWorkflowAsync(entity);

            return entity.Id;
        }
    }
}
