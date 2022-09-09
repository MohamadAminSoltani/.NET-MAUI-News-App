#if __IOS__
using UIKit;
using Foundation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
#endif


using NewsApp.Services;

namespace NewsApp;

public partial class App : Application
{
    public static NewsRepository NewsRepository { get; private set; }  
	public App(NewsRepository newsRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

        NewsRepository = newsRepository;
    }

#if __IOS__


    private DisplayOrientation _lastOrientation;

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);


        window.Created += (s, e) =>
        {
            UpdateStatusBarColor();
        };

        window.Destroying += (s, e) =>
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver(new NSString("UIDeviceOrientationDidChangeNotification"));
        };

        return window;
    }

    private void UpdateStatusBarColor()
    {
        UIView statusBar;
        if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        {
            int tag = 4567890;

            UIWindow window = UIApplication.SharedApplication.Delegate.GetWindow();
            statusBar = window.ViewWithTag(tag);

            if (statusBar == null || statusBar.Frame != UIApplication.SharedApplication.StatusBarFrame)
            {
                statusBar = statusBar ?? new(UIApplication.SharedApplication.StatusBarFrame);
                statusBar.Frame = UIApplication.SharedApplication.StatusBarFrame;
                statusBar.Tag = tag;

                window.AddSubview(statusBar);
            }
        }
        else
        {
            statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
        }

        if (statusBar != null)
        {
            // TODO Make this color come from somewhere shared
            statusBar.BackgroundColor = Color.FromArgb("#0E1014").ToUIColor();

        }

        NSNotificationCenter.DefaultCenter.AddObserver(new NSString("UIDeviceOrientationDidChangeNotification"), NotificationCenter =>
        {
            // This gets called multiple times on iOS, let's optimize a little bit
            if (_lastOrientation != DeviceDisplay.MainDisplayInfo.Orientation)
            {
                UpdateStatusBarColor();
                _lastOrientation = DeviceDisplay.MainDisplayInfo.Orientation;
            }
        });
    }
#endif
}
