using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CropView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CropFrame : ContentView
    {
        private readonly Color WhiteTransparent = Color.FromRgba(255, 255, 255, 0.5);

        public CropFrame()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            App.CropFrame = this;
            
            // Set pans background color
            TopLeftPan.BackgroundColor = WhiteTransparent;
            TopRightPan.BackgroundColor = WhiteTransparent;
            BottomLeftPan.BackgroundColor = WhiteTransparent;
            BottomRightPan.BackgroundColor = WhiteTransparent;

            // Set pans position
            TopLeftPan.CornerPosition = Corner.TopLeft;
            TopRightPan.CornerPosition = Corner.TopRight;
            BottomLeftPan.CornerPosition = Corner.BottomLeft;
            BottomRightPan.CornerPosition = Corner.BottomRight;
        }

        public void MoveCornerPoint(double x, double y, Corner cornerPosition)
        {
            switch (cornerPosition)
            {
                case Corner.TopLeft:
                    TopLeftPoint.TranslationX = x;
                    TopLeftPoint.TranslationY = y;
                    break;

                case Corner.TopRight:
                    TopRightPoint.TranslationX = x;
                    TopRightPoint.TranslationY = y;
                    break;

                case Corner.BottomLeft:
                    BottomLeftPoint.TranslationX = x;
                    BottomLeftPoint.TranslationY = y;
                    break;

                case Corner.BottomRight:
                    BottomRightPoint.TranslationX = x;
                    BottomRightPoint.TranslationY = y;
                    break;
            }
        }

        public double GetCoordinateX()
        {
            return TopLeftPan.CoordinateX;
        }

        public double GetCoordinateY()
        {
            return TopLeftPan.CoordinateY;
        }
    }
}