using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(EditTaskView),typeof(EditTaskView));
        Routing.RegisterRoute(nameof(ProjectView),typeof(ProjectView));
        Routing.RegisterRoute(nameof(EditProjectView),typeof(EditProjectView));
    }
}