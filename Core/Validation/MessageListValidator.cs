using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation
{
    public class MessageListValidator : AbstractValidator<MessageList>
    {
        public MessageListValidator()
        {
            RuleFor(motionTohost => motionTohost.Id).NotNull().GreaterThan(0);
            RuleFor(motionTohost => motionTohost.Date).NotNull();
            RuleFor(motionTohost => motionTohost.Type).NotNull().GreaterThan(0);
            RuleFor(motionTohost => motionTohost.Description).NotNull().MaximumLength(50).NotEmpty();
        }
    }
}
