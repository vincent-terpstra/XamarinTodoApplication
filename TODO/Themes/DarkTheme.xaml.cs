﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Themes;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class DarkTheme : ResourceDictionary
{
    public DarkTheme()
    {
        InitializeComponent();
    }
}