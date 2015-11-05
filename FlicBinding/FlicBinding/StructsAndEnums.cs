using System;
using ObjCRuntime;

[Native]
public enum SCLFlicButtonConnectionState : ulong
{
	Connected = 0,
	Connecting,
	Disconnected,
	Disconnecting
}

[Native]
public enum SCLFlicButtonMode : ulong
{
	Active = 0,
	ActiveKeepAlive = 1,
	SuperActive = 2
}

[Native]
public enum SCLFlicButtonLEDIndicateCount : ulong
{
	SCLFlicButtonLEDIndicateCount1 = 1,
	SCLFlicButtonLEDIndicateCount2,
	SCLFlicButtonLEDIndicateCount3,
	SCLFlicButtonLEDIndicateCount4,
	SCLFlicButtonLEDIndicateCount5
}

[Native]
public enum SCLFlicButtonTriggerBehavior : ulong
{
	Hold = 0,
	DoubleClick,
	DoubleClickAndHold
}

[Native]
public enum SCLFlicError : ulong
{
	Unknown = 0,
	CouldNotCompleteTask,
	ConnectionFailed,
	CouldNotUpdateRSSI,
	DatabaseError,
	UnknownDataReceived,
	VerificationTimeOut,
	BackendUnreachable,
	NoInternetConnection,
	CredentialsNotMatching,
	ButtonIsPrivate,
	CryptographicFailure,
	ButtonDisconnectedDuringVerification
}

[Native]
public enum SCLFlicManagerBluetoothState : ulong
{
	PoweredOn = 0,
	PoweredOff,
	Resetting,
	Unsupported,
	Unauthorized,
	Unknown
}
