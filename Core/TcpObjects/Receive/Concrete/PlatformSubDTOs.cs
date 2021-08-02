using Core.TcpObjects.Send;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Core.TcpObjects.Receive.Concrete
{
	// PLATFORM SUB DTOs
	public interface IPlatform { }
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class SettedLimit : IPlatform
	{
		//AxisType axisType;
		public double positionLimitMin { get; set; }
		public double positionLimitMax { get; set; }
		public double velocityLimitMin { get; set; }
		public double velocityLimitMax { get; set; }
	};

	public class SettedSweepPosition : IPlatform
	{
		AxisType axisType;
		double posStart;
		double posStop;
		double velocityValue;
		double standbyTime;
	};

	public class SettedFixedPosition
	{
		AxisType axisType;
		double positionValue;
		double velocityValue;
	};

	public class SettedPidParam
	{
		double Kp;
		double Ki;
		double Kd;
		double Tant;
	};


	public class AxisValues
	{
		SettedPidParam pid_parameters;
		MotionValue Motor;
		double Temperature;
		double Torque;
		double Current;
		double Curent;
		double encoderAbsolute;
		float [] power = new float[4];
		byte states;
		byte error;
		byte reserved;
		byte reserved2;

	}
	public class MotionValue
	{
		double Pos;
		double Vel;
	};

	
}
