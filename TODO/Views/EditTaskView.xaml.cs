﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTaskView : ContentPage
    {
        public EditTaskView()
        {
            InitializeComponent();
        }
    }
}