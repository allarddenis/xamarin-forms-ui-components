using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dalcomponents.Gradient
{
    public class GradientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Color[] gradientColors;
        private double viewWidth;
        private double viewHeight;
        private bool roundCorners;
        private double cornerRadius;
        private bool leftToRight;
        private ICommand onTap;

        public Color[] GradientColors 
        {
            get
            {
                return gradientColors;
            }
            set
            {
                if (gradientColors != value)
                {
                    gradientColors = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("GradientColors"));
                    }
                }
            }
        }

        public double ViewWidth
        {
            get { return viewWidth; }
            set
            {
                if (viewWidth != value)
                {
                    viewWidth = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ViewWidth"));
                    }
                }
            }
        }

        public double ViewHeight
        {
            get { return viewHeight; }
            set
            {
                if (viewHeight != value)
                {
                    viewHeight = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ViewHeight"));
                    }
                }
            }
        }

        public bool RoundCorners
        {
            get { return roundCorners; }
            set
            {
                if (roundCorners != value)
                {
                    roundCorners = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("RoundCorners"));
                    }
                }
            }
        }

        public double CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                if (cornerRadius != value)
                {
                    cornerRadius = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CornerRadius"));
                    }
                }
            }
        }

        public bool LeftToRight 
        {
            get { return leftToRight; }
            set
            {
                if (leftToRight != value)
                {
                    leftToRight = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("LeftToRight"));
                    }
                }
            }
        }

        public ICommand OnTap
        {
            get { return onTap; }
            set
            {
                if (onTap != value)
                {
                    onTap = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("OnTap"));
                    }
                }
            }
        }
    }
}