using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Spawn.Management.Application.Commands
{
    internal class CreateWorkflowValidator : AbstractValidator<CreateWorkflowCommand>
    {
        public CreateWorkflowValidator()
        {
            RuleFor(v => v.Name)
                        .MaximumLength(200)
                        .NotEmpty();

            RuleFor(v => v.Command)
                .NotEmpty();
        }
    }
}
