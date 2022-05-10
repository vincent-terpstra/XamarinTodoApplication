using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Themes;
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
        
        setTheme(Application.Current.RequestedTheme);
    }

    private void setTheme(OSAppTheme theme)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if(mergedDictionaries == null)
            return;
        mergedDictionaries.Clear();
        Application.Current.UserAppTheme = theme;
        mergedDictionaries.Add(theme == OSAppTheme.Dark ? new DarkTheme() : new LightTheme());
        
    }
    
    private void OnSwitchTheme(object sender, EventArgs e)
    {
            OSAppTheme currentTheme = Application.Current.UserAppTheme;
            setTheme(currentTheme == OSAppTheme.Dark ? OSAppTheme.Light : OSAppTheme.Dark);
    }
}