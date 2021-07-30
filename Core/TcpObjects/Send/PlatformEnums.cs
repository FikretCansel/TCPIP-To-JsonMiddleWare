using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TcpObjects.Send
{
    enum SystemState
    {
        none = 0,
        SYSTEM_NOT_CONNECTED = 1,
        SYSTEM_PASSIVE = 2,
        SYSTEM_ENERGIZED= 3,
        SYSTEM_READY_FOR_INITIALIZING = 4,
        SYSTEM_INITIALIZING = 5,
        SYSTEM_GO_TO_ZERO = 6,
        SYSTEM_GETTING_DATA = 7,
        SYSTEM_READY_FOR_TRAINING = 8,
        SYSTEM_ON_TRAINING = 9,
        SYSTEM_ON_STOP_TRAINING = 10,
        SYSTEM_SERVICE = 11,
        SYSTEM_ON_ERROR = 12,
        SYSTEM_ON_EMERGENCY = 13,
    };

    enum AxisType
    {
        Elevation = 1,
        Azimuth = 0
    };

    enum ErrorState
    {
        NoError = 0,
        LimitSensor = 1,
        SmokeSensor = 2,
        MotorEncoder = 3,
        HighTemperature = 4,
        HighTorque = 5
    };

    enum SecurityId
    {
        State = 201
    };

    enum SettingObjectType
    {
        State = 0,
        Limit = 1,
        GoToPos = 2,
        SweepPos = 3,
        PIDTuning = 4,
		notSecureTrigger = 5,
		errorReset = 6
    };
}
