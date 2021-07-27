using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using FluentValidation;

namespace Core.Validation
{
    public class MotionToHostValidator:AbstractValidator<MotionToHost>
    {
        public MotionToHostValidator()
        {
            RuleFor(motionTohost => motionTohost.MotorCurrent.Motor1).NotNull().GreaterThan(0);
            RuleFor(motionTohost => motionTohost.MotorCurrent.Motor2).NotNull().GreaterThan(0);
            RuleFor(motionTohost => motionTohost.SystemTempe.Panel).NotNull().GreaterThan(0);
            RuleFor(motionTohost => motionTohost.SystemTempe.Bellows).NotNull().GreaterThan(0);
        }
    }
}
