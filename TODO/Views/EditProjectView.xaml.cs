using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
[QueryProperty(nameof(ItemGuid), nameof(ItemGuid))]
public partial class EditProjectView : ContentPage
{
    private readonly EditProjectViewModel _editProjectViewModel;
    
    public EditProjectView()
    {
        InitializeComponent();
        this.BindingContext = _editProjectViewModel = new EditProjectViewModel();
    }
    
    public long ItemGuid
    {
        set => _editProjectViewModel.Set(value);
    }
}