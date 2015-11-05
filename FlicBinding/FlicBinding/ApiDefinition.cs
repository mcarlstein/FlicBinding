using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace FlicBinding
{
	// @interface SCLFlicButton : NSObject
	[BaseType (typeof(NSObject))]
	interface SCLFlicButton
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		SCLFlicButtonDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SCLFlicButtonDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSUUID * _Nonnull buttonIdentifier;
		[Export ("buttonIdentifier", ArgumentSemantic.Strong)]
		NSUuid ButtonIdentifier { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull buttonPublicKey;
		[Export ("buttonPublicKey", ArgumentSemantic.Strong)]
		string ButtonPublicKey { get; }

		// @property (readonly, atomic, strong) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// @property (readonly, atomic) SCLFlicButtonConnectionState connectionState;
		[Export ("connectionState")]
		SCLFlicButtonConnectionState ConnectionState { get; }

		// @property (readwrite, nonatomic) SCLFlicButtonMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		SCLFlicButtonMode Mode { get; set; }

		// @property (readwrite, nonatomic) SCLFlicButtonTriggerBehavior triggerBehavior;
		[Export ("triggerBehavior", ArgumentSemantic.Assign)]
		SCLFlicButtonTriggerBehavior TriggerBehavior { get; set; }

		// @property (readonly, nonatomic) int pressCount;
		[Export ("pressCount")]
		int PressCount { get; }

		// -(void)connect;
		[Export ("connect")]
		void Connect ();

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)indicateLED:(SCLFlicButtonLEDIndicateCount)count;
		[Export ("indicateLED:")]
		void IndicateLED (SCLFlicButtonLEDIndicateCount count);

		// -(void)readRSSI;
		[Export ("readRSSI")]
		void ReadRSSI ();
	}

	// @protocol SCLFlicButtonDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface SCLFlicButtonDelegate
	{
		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonDown:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonDown:age:")]
		void FlicButton (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonUp:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonUp:age:")]
		void FlicButtonDidReceiveButtonUp (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonClick:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonClick:age:")]
		void FlicButtonDidReceiveButtonClick (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonDoubleClick:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonDoubleClick:age:")]
		void FlicButtonDidReceiveButtonDoubleClick (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonHold:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonHold:age:")]
		void FlicButtonDidReceiveButtonHold (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButtonDidConnect:(SCLFlicButton * _Nonnull)button;
		[Export ("flicButtonDidConnect:")]
		void FlicButtonDidConnect (SCLFlicButton button);

		// @optional -(void)flicButtonIsReady:(SCLFlicButton * _Nonnull)button;
		[Export ("flicButtonIsReady:")]
		void FlicButtonIsReady (SCLFlicButton button);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didDisconnectWithError:(NSError * _Nullable)error;
		[Export ("flicButton:didDisconnectWithError:")]
		void FlicButton (SCLFlicButton button, [NullAllowed] NSError error);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didFailToConnectWithError:(NSError * _Nullable)error;
		[Export ("flicButton:didFailToConnectWithError:")]
		void FlicButtonDidFailToConnectWithError (SCLFlicButton button, [NullAllowed] NSError error);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didUpdateRSSI:(NSNumber * _Nonnull)RSSI error:(NSError * _Nullable)error;
		[Export ("flicButton:didUpdateRSSI:error:")]
		void FlicButtonDidUpdateRSSI (SCLFlicButton button, NSNumber RSSI, [NullAllowed] NSError error);
	}

	// @interface SCLFlicManager : NSObject
	[BaseType (typeof(NSObject))]
	interface SCLFlicManager
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		SCLFlicManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SCLFlicManagerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) SCLFlicManagerBluetoothState bluetoothState;
		[Export ("bluetoothState")]
		SCLFlicManagerBluetoothState BluetoothState { get; }

		// @property (readonly, getter = isEnabled) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// -(instancetype _Nullable)initWithDelegate:(id<SCLFlicManagerDelegate> _Nonnull)delegate appID:(NSString * _Nonnull)appID appSecret:(NSString * _Nonnull)appSecret backgroundExecution:(BOOL)bExecution andRestoreState:(BOOL)restore;
		[Export ("initWithDelegate:appID:appSecret:backgroundExecution:andRestoreState:")]
		IntPtr Constructor (SCLFlicManagerDelegate @delegate, string appID, string appSecret, bool bExecution, bool restore);

		// -(NSDictionary * _Nonnull)knownButtons;
		[Export ("knownButtons")]
		//[Verify (MethodToProperty)]
		NSDictionary KnownButtons { get; }

		// -(void)forgetButton:(SCLFlicButton * _Nonnull)button;
		[Export ("forgetButton:")]
		void ForgetButton (SCLFlicButton button);

		// -(void)disable;
		[Export ("disable")]
		void Disable ();

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(void)requestButtonFromFlicAppWithCallback:(NSString * _Nonnull)callback;
		[Export ("requestButtonFromFlicAppWithCallback:")]
		void RequestButtonFromFlicAppWithCallback (string callback);

		// -(SCLFlicButton * _Nullable)generateButtonFromURL:(NSURL * _Nonnull)url;
		[Export ("generateButtonFromURL:")]
		[return: NullAllowed]
		SCLFlicButton GenerateButtonFromURL (NSUrl url);
	}

	// @protocol SCLFlicManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface SCLFlicManagerDelegate
	{
		// @optional -(void)flicManager:(SCLFlicManager * _Nonnull)manager didChangeBluetoothState:(SCLFlicManagerBluetoothState)state;
		[Export ("flicManager:didChangeBluetoothState:")]
		void FlicManager (SCLFlicManager manager, SCLFlicManagerBluetoothState state);

		// @optional -(void)flicManagerDidRestoreState:(SCLFlicManager * _Nonnull)manager;
		[Export ("flicManagerDidRestoreState:")]
		void FlicManagerDidRestoreState (SCLFlicManager manager);

		// @optional -(void)flicManager:(SCLFlicManager * _Nonnull)manager didForgetButton:(NSUUID * _Nonnull)buttonIdentifier error:(NSError * _Nullable)error;
		[Export ("flicManager:didForgetButton:error:")]
		void FlicManager (SCLFlicManager manager, NSUuid buttonIdentifier, [NullAllowed] NSError error);
	}
}

