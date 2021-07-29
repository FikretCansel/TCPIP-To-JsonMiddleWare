using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTO.Receive
{

	public interface IPlatformSubDTO { }

	public interface IPlatformDTO { }
	// PLATFORM SUB DTOS
	public class SettedLimit : IPlatformSubDTO
	{
		AxisType axisType;
		double positionLimitMin;
		double positionLimitMax;
		double velocityLimitMin;
		double velocityLimitMax;
	};

	public class SettedSweepPosition : IPlatformSubDTO
	{
		AxisType axisType;
		double posStart;
		double posStop;
		double velocityValue;
		double standbyTime;
	};

	public class SettedFixedPosition : IPlatformSubDTO
	{
		AxisType axisType;
		double positionValue;
		double velocityValue;
	};

	public class SettedPidParam : IPlatformSubDTO
	{
		double Kp;
		double Ki;
		double Kd;
		double Tant;
	};


	public class AxisValues : IPlatformSubDTO
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
	public class MotionValue : IPlatformSubDTO
	{
		double Pos;
		double Vel;
	};

	// PLATFORM DTOS
	public class PlatformState : IPlatformDTO
	{
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.State;
		SystemState systemState;
	};

	public class Limit : IPlatformDTO
	{
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.Limit;
		SettedLimit settedLimit;
	};

	public class FixedPosition : IPlatformDTO
	{ //Constant speed sweeping
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.GoToPos;
		SettedFixedPosition FixPosition;
	};

	/// <summary>
	/// Fixed Position DTO
	/// </summary>
	public class SweepPosition : IPlatformDTO
	{ //Goes to position
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.SweepPos;
		SettedSweepPosition SettedSweepPosition;
	};

	public class PlatformControllerTuning : IPlatformDTO
	{
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.PIDTuning;
		//PIDParameters pidParameters;
	};

	public class InsecureTrigger : IPlatformDTO
	{
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.notSecureTrigger;
		byte Trigger;
		byte reserved;
	}

	public class ErrorReset : IPlatformDTO
	{
		const SecurityId securityId = SecurityId.State;
		const SettingObjectType settingObjectType = SettingObjectType.errorReset;
		byte Trigger;
		byte reserved;
	}
	public class MotionToHost : IPlatformDTO
	{
		byte SecurityID;
		byte State_Motion;
		byte reserved;
		byte reserved1;
		AxisValues AzimuthAxis;
		AxisValues ElevationAxis;
		int [] Time_System = new int[3];
		int [] Time_Working= new int[3] ;
		byte errorSystem;
	}

#pragma pack(push, r1, 1)
	public class PlatformData : IPlatformDTO
	{
		char securityId;
		float position;
		float velocity;
		float acceleration;
		float temperature;
		float current;
		float torque;
		char driver;
		float voltage;
		float encoder;
		char limitSensor1;
		char limitSensor2;
	};
}
