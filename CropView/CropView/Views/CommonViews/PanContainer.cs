using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CropView
{
    public class PanContainer : ContentView
    {
        double x, y;

        public Corner CornerPosition { get; set; }
        public double CoordinateX
        {
            get { return x; }
            set { x = value; }
        }
        public double CoordinateY
        {
            get { return y; }
            set { y = value; }
        }

        public PanContainer()
        {
            x = this.X;
            y = this.Y;

            // Set PanGestureRecognizer.TouchPoints to control the 
            // number of touch points needed to pan
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            try
            {
                switch (e.StatusType)
                {
                    case GestureStatus.Running:
                        // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                        var translationX = e.TotalX;
                        var translationY = e.TotalY;
                        if (this.CanMove())
                        {
                            Content.TranslationX = translationX;
                            Content.TranslationY = translationY;
                            CropFrame.Current.MoveCorners(this.x + translationX,
                                                      this.y + translationY, 
                                                      this.CornerPosition);
                            App.MainPagePage.SetLabelsCoordinate();
                        }

                        break;

                    case GestureStatus.Completed:
                        // Store the translation applied during the pan
                        x += Content.TranslationX;
                        y += Content.TranslationY;

                        // Moving PanContainer
                        this.TranslationX = x;
                        this.TranslationY = y;

                        // Reset Content location
                        Content.TranslationX = 0;
                        Content.TranslationY = 0;

                        App.MainPagePage.SetLabelsCoordinate();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private bool CanMove()
        {
            return true;
        }
    }
}
