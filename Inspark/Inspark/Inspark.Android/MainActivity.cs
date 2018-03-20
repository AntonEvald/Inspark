using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Plugin.Media;

namespace Inspark.Droid
{
    [Activity(Label = "Inspark", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            await CrossMedia.Current.Initialize();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            XamForms.Controls.Droid.Calendar.Init();
            LoadApplication(new App());
        }

        //public static readonly int PickImageId = 1000;

        //public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);

        //    if (requestCode == PickImageId)
        //    {
        //        if ((resultCode == Result.Ok) && (data != null))
        //        {
        //            Android.Net.Uri uri = data.Data;
        //            Stream stream = ContentResolver.OpenInputStream(uri);

        //            // Set the Stream as the completion of the Task
        //            PickImageTaskCompletionSource.SetResult(stream);
        //        }
        //        else
        //        {
        //            PickImageTaskCompletionSource.SetResult(null);
        //        }
        //    }
        //}
    }
}

