using Entity.Abstract;
using Entity.Concrete;
using System;

namespace Entity
{
    public class MotionToHost:IEntity
    {
        public SystemTempe SystemTempe { get; set; }

        public MotorCurrent MotorCurrent { get; set; }
        public MotionToHost()
        {
            SystemTempe=new SystemTempe();
            MotorCurrent = new MotorCurrent();
        }
    }
}
