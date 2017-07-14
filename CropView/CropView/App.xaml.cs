using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CropView
{
    public partial class App : Application
    {

        public static CropFrame CropFrame;

        public static float ScreenWidth;
        public static float ScreenHeight;

        public App()
        {
            InitializeComponent();

            MainPage = new CropView.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
