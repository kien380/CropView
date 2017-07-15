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
            App.MainPagePage = this;

            ScreenSizeLabel.Text = "Screen Size = " + 
                                   Math.Round(App.ScreenWidth) + 
                                   " x " +
                                   Math.Round(App.ScreenHeight);
            ImageSizeLabel.Text = "Image Size = " +
                                  Math.Round(MainCropFrame.Width) + 
                                  " x " +
                                  Math.Round(MainCropFrame.Height);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SetLabelsCoordinate();
        }

        public void SetLabelsCoordinate()
        {
            double x = 0;
            double y = 0;

            MainCropFrame.GetCoordinate(Corner.TopLeft, out x, out y);
            TopLeftPointLabel.Text = "1. Top Left = " + Math.Round(x) + " : " + Math.Round(y);

            MainCropFrame.GetCoordinate(Corner.TopRight, out x, out y);
            TopRightPointLabel.Text = "2. Top Right = " + Math.Round(x) + " : " + Math.Round(y);

            MainCropFrame.GetCoordinate(Corner.BottomLeft, out x, out y);
            BottomLeftPointLabel.Text = "3. Bottom Left = " + Math.Round(x) + " : " + Math.Round(y);

            MainCropFrame.GetCoordinate(Corner.BottomRight, out x, out y);
            BottomRightPointLabel.Text = "4. Bottom Right = " + Math.Round(x) + " : " + Math.Round(y);
        }
    }
}
