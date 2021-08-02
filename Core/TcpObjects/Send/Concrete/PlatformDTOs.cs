using Core.TcpObjects.Receive.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TcpObjects.Send.Concrete
{
    public class PlatformDTOs
    {
		// PLATFORM DTOs

		public class PlatformState
		{
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.State;
			SystemState systemState;
		};

		public class Limit
		{
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.Limit;
			SettedLimit settedLimit;
		};

		public class FixedPosition
		{ //Constant speed sweeping
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.GoToPos;
			SettedFixedPosition FixPosition;
		};

		/// <summary>
		/// Fixed Position DTO
		/// </summary>
		public class SweepPosition
		{ //Goes to position
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.SweepPos;
			//SettedSweepPosition SweepPosition;
		};

		public class PlatformControllerTuning
		{
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.PIDTuning;
			//PIDParameters pidParameters;
		};

		public class InsecureTrigger
		{
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.notSecureTrigger;
			byte Trigger;
			byte reserved;
		}

		public class ErrorReset
		{
			const SecurityId securityId = SecurityId.State;
			const SettingObjectType settingObjectType = SettingObjectType.errorReset;
			byte Trigger;
			byte reserved;
		}
		public class MotionToHost
		{
			byte SecurityID;
			byte State_Motion;
			byte reserved;
			byte reserved1;
			AxisValues AzimuthAxis;
			AxisValues ElevationAxis;
			int[] Time_System = new int[3];
			int[] Time_Working = new int[3];
			byte errorSystem;
		}

#pragma pack(push, r1, 1)
		public class PlatformData
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
#pragma pack(pop, r1)
	}
}
