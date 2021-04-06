using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using Com.OneSignal;
using Com.OneSignal.Abstractions;

namespace OneSignalXamarinTest.Droid
{
   [Activity(Label = "OneSignalXamarinTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
   {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);

         Xamarin.Essentials.Platform.Init(this, savedInstanceState);
         global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
         LoadApplication(new App());
         
         // Remove this method to stop OneSignal Debugging  
         OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);

         OneSignal.Current.StartInit("YOUR_APP_ID_HERE")
            .InFocusDisplaying(OSInFocusDisplayOption.Notification)
            .EndInit();
      }

      public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
      {
         Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

         base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      }
   }
}