# Xamarin Forms - UI Components

This repository contains some Xamarin.Forms UI components.

# Summary

1. [How to use](#how-to-use)
2. [GradientView Component](#gradientview-component)
3. [Author](#author)

# GradientView Component

GradientView is a gradient render for iOS and Android.
A specific implementation is required on both platforms.

### How it looks

### Associated Model

Model class : __GradientViewModel.cs__

### Bindable Properties

* __GradientColors__ (Color[]) : array of colors used by gradient
* __ViewWidth__ (double) : width of the component layout
* __ViewHeight__ (double) : height of the component layout
* __RoundCorners__ (bool) : true if the component layout has round corners, false otherwise
* __CornerRadius__ (double) : radius of component layout's corners
* __LeftToRight__ (bool) : gradient is done from left to right if true, from top to bottom otherwise
* __OnTap__ (ICommand) : command executed on tap

### XAML Sample

```xml
<local:GradientView 
    GradientColors="{Binding gradientColors}" 
    ViewWidth="500" ViewHeight="30"
    RoundCorners="True" CornerRadius="10"
    LeftToRight="True"
    OnTap="{Binding onTap}">
</local:GradientView>
```

### C# Sample

```csharp

    var gradientModel = new GradientViewModel()
    {
        ViewWidth = 300,
        ViewHeight = 50,
        RoundCorners = true,
        CornerRadius = 10,
        LeftToRight = true,
        OnTap = new Command(OnTapCommand)
    };

    var gradientView = new GradientView();

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

    gradientView.BindingContext = gradientModel;

```


# How To Use

1. Copy-paste the __component from PCL (shared) project__ (and its specific implemetation from iOS and Android if it exists).
2. Make sure to __change the name the namespace__ of the component to match your project & namespace

# Author

Denis Allard