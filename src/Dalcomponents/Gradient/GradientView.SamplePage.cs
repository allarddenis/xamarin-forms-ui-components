using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Dalcomponents.Gradient
{
    public class GradientViewSamplePage : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public GradientViewModel Gradient { get; set; }

        private GradientView gradientView { get; set; }

        public GradientViewSamplePage()
        {
            SetContent();
        }

        public void SetContent()
        {
            SetGradientView();

            var stacklayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var button = new Button() { Text = "Change Colors" };
            button.Command = new Command(ChangeGradientColor);

            stacklayout.Children.Add(button);
            stacklayout.Children.Add(gradientView);

            Content = stacklayout;
        }

        public void SetModel()
        {
            Gradient = new GradientViewModel()
            {
                ViewWidth = 300,
                ViewHeight = 50,
                RoundCorners = true,
                CornerRadius = 10,
                LeftToRight = true,
                OnTap = new Command(ChangeGradientColor)
            };

            ChangeGradientColor();
        }

        public void SetGradientView()
        {
            SetModel();

            gradientView = new GradientView();

            gradientView.SetBinding(GradientView.GradientColorsProperty, "GradientColors");
            gradientView.SetBinding(GradientView.CornerRadiusProperty, "CornerRadius");
            gradientView.SetBinding(GradientView.ViewWidthProperty, "ViewWidth");
            gradientView.SetBinding(GradientView.ViewHeightProperty, "ViewHeight");
            gradientView.SetBinding(GradientView.RoundCornersProperty, "RoundCorners");
            gradientView.SetBinding(GradientView.LeftToRightProperty, "LeftToRight");
            gradientView.SetBinding(GradientView.LeftToRightProperty, "LeftToRight");
            gradientView.SetBinding(GradientView.OnTapProperty, "OnTap");

            gradientView.WidthRequest = 300;
            gradientView.HeightRequest = 50;

            gradientView.BindingContext = Gradient;
        }

        public void ChangeGradientColor()
        {
            Random rnd = new Random();
            Color randomColor1 = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color randomColor2 = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            Gradient.GradientColors = new Color[] { randomColor1, randomColor2 };
        }
    }
}
