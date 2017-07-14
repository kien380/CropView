using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CropView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ScreenSizeLabel.Text = "Screen Size = " + App.ScreenWidth + " x " + App.ScreenHeight;
            ImageSizeLabel.Text = "Image Size = " + MainCropFrame.Width + " x " + MainCropFrame.Height;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Label1.Text = MainCropFrame.GetCoordinateX().ToString();
            Label3.Text = MainCropFrame.GetCoordinateY().ToString();
        }

        //private void GreenBoxView_Tapped(object sender, EventArgs e)
        //{
        //    Label1.Text = MainCropFrame.GetCoordinateX().ToString();
        //    Label3.Text = MainCropFrame.GetCoordinateY().ToString();
        //}
    }
}
