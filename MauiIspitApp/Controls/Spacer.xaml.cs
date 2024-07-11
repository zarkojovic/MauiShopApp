using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIspitApp.Controls;

public partial class Spacer : ContentView
{
    public Spacer()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SpaceProperty =
        BindableProperty.Create(nameof(Space), typeof(int), typeof(Spacer), defaultValue: 10);

    public int Space
    {
        get => (int)GetValue(SpaceProperty);
        set => SetValue(SpaceProperty, value);
    }
}