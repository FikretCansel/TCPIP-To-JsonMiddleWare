using Core.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMotionToHostService
    {
        MotionToHost Get();

        Result Send(MotionToHost motionToHost);
    }
}
