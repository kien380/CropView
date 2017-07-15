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
        #region VARIABLE DECLARATION
        private static CropFrame _current;
        private readonly Color WhiteTransparent = Color.FromRgba(255, 255, 255, 0.5);
        private readonly double SkipFlag = 6969d;
        private readonly double CornerPointSize = 10d;

        public readonly double CropWidth = 100d;
        public readonly double CropHeight = 100d;

        public static CropFrame Current
        {
            get
            {
                if (_current == null)
                    return new CropFrame();
                return _current;
            }
            private set
            {
                _current = value;
            }
        }
        #endregion 

        public CropFrame()
        {
            InitializeComponent();
            Init();
        }

        #region Init
        private void Init()
        {
            CropFrame.Current = this;
            SetCropViewValue();
            SetPansBackgroundColor();
            SetPansAndPointsPosition();
        }

        private void SetCropViewValue()
        {
            //CropView.WidthRequest = CropWidth;
            //CropView.HeightRequest = CropHeight;
        }

        private void SetPansBackgroundColor()
        {
            TopLeftPan.BackgroundColor = WhiteTransparent;
            TopRightPan.BackgroundColor = WhiteTransparent;
            BottomLeftPan.BackgroundColor = WhiteTransparent;
            BottomRightPan.BackgroundColor = WhiteTransparent;
        }

        private void SetPansAndPointsPosition()
        {
            double x = CropWidth / 2;
            double y = CropHeight / 2;

            // Set pan coordinate
            TopLeftPan.CoordinateX = -x;
            TopLeftPan.CoordinateY = -y;
            TopRightPan.CoordinateX = x;
            TopRightPan.CoordinateY = -y;
            BottomLeftPan.CoordinateX = -x;
            BottomLeftPan.CoordinateY = y;
            BottomRightPan.CoordinateX = x;
            BottomRightPan.CoordinateY = y;

            // Translate pans & points
            TopLeftPan.TranslateTo(-x, -y, 0);
            TopLeftPoint.TranslateTo(-x, -y, 0);
            TopRightPan.TranslateTo(x, -y, 0);
            TopRightPoint.TranslateTo(x, -y, 0);
            BottomLeftPan.TranslateTo(-x, y, 0);
            BottomLeftPoint.TranslateTo(-x, y, 0);
            BottomRightPan.TranslateTo(x, y, 0);
            BottomRightPoint.TranslateTo(x, y, 0);

            // Set pans position type
            TopLeftPan.CornerPosition = Corner.TopLeft;
            TopRightPan.CornerPosition = Corner.TopRight;
            BottomLeftPan.CornerPosition = Corner.BottomLeft;
            BottomRightPan.CornerPosition = Corner.BottomRight;
        }
        #endregion

        #region MOVING CORNERS
        public void MoveCorners(double x, double y, Corner cornerPosition)
        {
            switch (cornerPosition)
            {
                case Corner.TopLeft:
                    MoveTopLeftPoint(x, y);
                    MoveTopRightPan(SkipFlag, y);
                    MoveTopRightPoint(SkipFlag, y);
                    MoveBottomLeftPan(x, SkipFlag);
                    MoveBottomLeftPoint(x, SkipFlag);
                    break;

                case Corner.TopRight:
                    MoveTopRightPoint(x, y);
                    MoveTopLeftPan(SkipFlag, y);
                    MoveTopLeftPoint(SkipFlag, y);
                    MoveBottomRightPan(x, SkipFlag);
                    MoveBottomRightPoint(x, SkipFlag);
                    break;

                case Corner.BottomLeft:
                    MoveBottomLeftPoint(x, y);
                    MoveBottomRightPan(SkipFlag, y);
                    MoveBottomRightPoint(SkipFlag, y);
                    MoveTopLeftPan(x, SkipFlag);
                    MoveTopLeftPoint(x, SkipFlag);
                    break;

                case Corner.BottomRight:
                    MoveBottomRightPoint(x, y);
                    MoveBottomLeftPan(SkipFlag, y);
                    MoveBottomLeftPoint(SkipFlag, y);
                    MoveTopRightPan(x, SkipFlag);
                    MoveTopRightPoint(x, SkipFlag);
                    break;
            }
        }

        private void MoveTopLeftPoint(double x, double y)
        {
            if (x != SkipFlag) TopLeftPoint.TranslationX = x;
            if (y != SkipFlag) TopLeftPoint.TranslationY = y;
            if(x != SkipFlag && y != SkipFlag)
            {
                double posX = -(CropWidth / 2);
                double posY = -(CropHeight / 2);

                CropView.WidthRequest = CropWidth + (posX - x);
                CropView.HeightRequest = CropHeight + (posY - y);
                CropView.TranslationX = (x - posX)/2;
                CropView.TranslationY = (y - posY)/2;
            }
        }
        private void MoveTopLeftPan(double x, double y)
        {
            if (x != SkipFlag)
            {
                TopLeftPan.TranslationX = x;
                TopLeftPan.CoordinateX = x;
            }
            if (y != SkipFlag)
            {
                TopLeftPan.TranslationY = y;
                TopLeftPan.CoordinateY = y;
            }
        }
        private void MoveTopRightPoint(double x, double y)
        {
            if (x != SkipFlag) TopRightPoint.TranslationX = x;
            if (y != SkipFlag) TopRightPoint.TranslationY = y;
        }
        private void MoveTopRightPan(double x, double y)
        {
            if (x != SkipFlag)
            {
                TopRightPan.TranslationX = x;
                TopRightPan.CoordinateX = x;
            }
            if (y != SkipFlag)
            {
                TopRightPan.TranslationY = y;
                TopRightPan.CoordinateY = y;
            }
        }
        private void MoveBottomLeftPoint(double x, double y)
        {
            if (x != SkipFlag) BottomLeftPoint.TranslationX = x;
            if (y != SkipFlag) BottomLeftPoint.TranslationY = y;
        }
        private void MoveBottomLeftPan(double x, double y)
        {
            if (x != SkipFlag)
            {
                BottomLeftPan.TranslationX = x;
                BottomLeftPan.CoordinateX = x;
            }
            if (y != SkipFlag)
            {
                BottomLeftPan.TranslationY = y;
                BottomLeftPan.CoordinateY = y;
            }
        }
        private void MoveBottomRightPoint(double x, double y)
        {
            if (x != SkipFlag) BottomRightPoint.TranslationX = x;
            if (y != SkipFlag) BottomRightPoint.TranslationY = y;
        }
        private void MoveBottomRightPan(double x, double y)
        {
            if (x != SkipFlag)
            {
                BottomRightPan.TranslationX = x;
                BottomRightPan.CoordinateX = x;
            }
            if (y != SkipFlag)
            {
                BottomRightPan.TranslationY = y;
                BottomRightPan.CoordinateY = y;
            }
        }
        #endregion

        #region GetCoordinate
        public void GetCoordinate(Corner cornerPosition, out double coordinateX, out double coordinateY)
        {
            switch(cornerPosition)
            {
                case Corner.TopLeft:
                    coordinateX = TopLeftPan.CoordinateX;
                    coordinateY = TopLeftPan.CoordinateY;
                    break;

                case Corner.TopRight:
                    coordinateX = TopRightPan.CoordinateX;
                    coordinateY = TopRightPan.CoordinateY;
                    break;

                case Corner.BottomLeft:
                    coordinateX = BottomLeftPan.CoordinateX;
                    coordinateY = BottomLeftPan.CoordinateY;
                    break;

                case Corner.BottomRight:
                    coordinateX = BottomRightPan.CoordinateX;
                    coordinateY = BottomRightPan.CoordinateY;
                    break;

                default:
                    coordinateX = 0d;
                    coordinateY = 0d;
                    break;
            }
        }
        #endregion

        public string getCropViewPosition()
        {
            return CropView.X + " : " + CropView.Y;
        }
    }
}