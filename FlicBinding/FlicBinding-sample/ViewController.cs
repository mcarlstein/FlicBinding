using System;
using FlicBinding;
using UIKit;
using Foundation;

namespace FlicBindingsample
{
	public partial class ViewController : UIViewController
	{
		SCLFlicButton flicButton;
		SCLFlicManager flicManager;

		UIButton clickButton;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public bool HandleUrl (NSUrl url)
		{
			this.flicButton = this.flicManager.GenerateButtonFromURL (url);
			this.flicButton.Delegate = new FlicButtonDelegate ();
			this.flicButton.Connect ();
			return true;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			clickButton = new UIButton (UIButtonType.Custom);
			clickButton.Frame = new CoreGraphics.CGRect (50, 50, 100, 50);
			clickButton.BackgroundColor = UIColor.Black;
			clickButton.SetTitleColor (UIColor.White, UIControlState.Normal);
			clickButton.SetTitle ("Add flic", UIControlState.Normal);
			this.View.Add (clickButton);

			this.flicManager = new SCLFlicManager (new FlicManagerDelegate (), "e5a87c01-6f2b-451a-86b0-8994f239d14f", "8861f5b0-6eab-49ba-bab4-699cc3f6b368", false, false);

			clickButton.TouchUpInside += (object sender, EventArgs e) => {
				this.flicManager.RequestButtonFromFlicAppWithCallback ("flicsampleapp://button");
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public class FlicButtonDelegate : SCLFlicButtonDelegate
		{
			public override void FlicButtonDidReceiveButtonClick (SCLFlicButton button, bool queued, nint age)
			{
				System.Diagnostics.Debug.WriteLine ("Clickclick");
			}
		}

		public class FlicManagerDelegate : SCLFlicManagerDelegate
		{

		}
	}
}

