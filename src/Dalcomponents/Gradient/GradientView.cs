using System.Windows.Input;
using Xamarin.Forms;

namespace Dalcomponents.Gradient
{
    public class GradientView : View
    {
        public static readonly BindableProperty GradientColorsProperty
            = BindableProperty.Create(nameof(GradientColors), typeof(Color[]), typeof(GradientView), new Color[] { Color.White });

        public Color[] GradientColors
        {
            get { return (Color[])base.GetValue(GradientColorsProperty); }
            set
            {
                base.SetValue(GradientColorsProperty, value);
            }
        }

        public static readonly BindableProperty CornerRadiusProperty
            = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(GradientView), 0.0);

        public double CornerRadius
        {
            get { return (double)base.GetValue(CornerRadiusProperty); }
            set { base.SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty ViewHeightProperty
            = BindableProperty.Create(nameof(ViewHeight), typeof(double), typeof(GradientView), 0.0);

        public double ViewHeight
        {
            get { return (double)base.GetValue(ViewHeightProperty); }
            set { base.SetValue(ViewHeightProperty, value); }
        }

        public static readonly BindableProperty ViewWidthProperty
            = BindableProperty.Create(nameof(ViewWidth), typeof(double), typeof(GradientView), 0.0);

        public double ViewWidth
        {
            get { return (double)base.GetValue(ViewWidthProperty); }
            set { base.SetValue(ViewWidthProperty, value); }
        }

        public static readonly BindableProperty RoundCornersProperty
            = BindableProperty.Create(nameof(RoundCorners), typeof(bool), typeof(GradientView), false);

        public bool RoundCorners
        {
            get { return (bool)base.GetValue(RoundCornersProperty); }
            set { base.SetValue(RoundCornersProperty, value); }
        }

        public static readonly BindableProperty LeftToRightProperty
            = BindableProperty.Create(nameof(LeftToRight), typeof(bool), typeof(GradientView), true);

        public bool LeftToRight
        {
            get { return (bool)base.GetValue(LeftToRightProperty); }
            set { base.SetValue(LeftToRightProperty, value); }
        }

        public static readonly BindableProperty OnTapProperty
            = BindableProperty.Create(nameof(OnTap), typeof(ICommand), typeof(GradientView), new Command(() => { }));

        public ICommand OnTap
        {
            get
            {
                return (ICommand)base.GetValue(OnTapProperty);
            }
            set
            {
                base.SetValue(OnTapProperty, value);
                GestureRecognizers.Clear();
                var tap = new TapGestureRecognizer();
                tap.Command = value;
                GestureRecognizers.Add(tap);
            }
        }
    }
}
