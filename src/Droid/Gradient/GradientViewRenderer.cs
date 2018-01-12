using System.Linq;
using System.Windows.Input;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Dalcomponents.Droid.Gradient;
using Dalcomponents.Gradient;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientView), typeof(GradientButtonRenderer))]
namespace Dalcomponents.Droid.Gradient
{
    public class GradientButtonRenderer : ViewRenderer<GradientView, Android.Views.View>
    {
        LinearLayout layout;
        Color[] gradientColors;
        float cornerRadius;
        double viewHeight;
        double viewWidth;
        bool roundCorners;
        ICommand onTap;

        public GradientButtonRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GradientView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                layout = new LinearLayout(Android.App.Application.Context);
                layout.SetBackgroundColor(Android.Graphics.Color.White);

                gradientColors = e.NewElement.GradientColors;
                cornerRadius = (float)e.NewElement.CornerRadius;
                viewWidth = e.NewElement.ViewWidth;
                viewHeight = e.NewElement.ViewHeight;
                roundCorners = e.NewElement.RoundCorners;

                CreateLayout();
            }

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null)
            {
                // Configure the control and subscribe to event handlers
                gradientColors = e.NewElement.GradientColors;
                cornerRadius = (float)e.NewElement.CornerRadius;
                viewWidth = (double)e.NewElement.ViewWidth;
                viewHeight = (double)e.NewElement.ViewHeight;
                roundCorners = (bool)e.NewElement.RoundCorners;
                onTap = (ICommand)e.NewElement.OnTap;

                CreateLayout();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == GradientView.ViewHeightProperty.PropertyName)
            {
                this.viewHeight = ((GradientView)this.Element).ViewHeight;
                CreateLayout();
            }
            else if (e.PropertyName == GradientView.ViewWidthProperty.PropertyName)
            {
                this.viewWidth = ((GradientView)this.Element).ViewWidth;
                CreateLayout();
            }
            else if (e.PropertyName == GradientView.GradientColorsProperty.PropertyName)
            {
                this.gradientColors = ((GradientView)this.Element).GradientColors;
                CreateLayout();
            }
            else if (e.PropertyName == GradientView.CornerRadiusProperty.PropertyName)
            {
                this.cornerRadius = (float)((GradientView)this.Element).CornerRadius;
                CreateLayout();
            }
            else if (e.PropertyName == GradientView.RoundCornersProperty.PropertyName)
            {
                this.roundCorners = ((GradientView)this.Element).RoundCorners;
                CreateLayout();
            }
            else if (e.PropertyName == GradientView.OnTapProperty.PropertyName)
            {
                this.onTap = ((GradientView)this.Element).OnTap;
                CreateLayout();
            }
        }

        private void CreateLayout()
        {
            layout.SetMinimumWidth((int)viewWidth);
            layout.SetMinimumHeight((int)viewHeight);

            CreateGradient();

            layout.Click += delegate { this.onTap.Execute(0); };

            SetNativeControl(layout);
        }

        public void CreateGradient()
        {
            //Need to convert the colors to Android Color objects
            int[] androidColors = new int[gradientColors.Count()];

            for (int i = 0; i < gradientColors.Count(); i++)
            {
                Color temp = gradientColors[i];
                androidColors[i] = temp.ToAndroid();
            }

            GradientDrawable gradient = new GradientDrawable(GradientDrawable.Orientation.LeftRight, androidColors);

            if (roundCorners)
                gradient.SetCornerRadii(new float[] { cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius });

            layout.SetBackground(gradient);
        }
    }
}