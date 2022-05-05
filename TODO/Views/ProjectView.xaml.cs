using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;
using TODO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
[QueryProperty(nameof(ItemGuid), nameof(ItemGuid))]
public partial class ProjectView : ContentPage
{
    private readonly ProjectViewModel _projectViewModel;
    
    public ProjectView()
    {
        InitializeComponent();
        this.BindingContext = _projectViewModel = new ProjectViewModel();
    }
    
    public long ItemGuid
    {
        set => _projectViewModel.Set(value);
    }

    private async void EditItem_Clicked(object sender, EventArgs e)
    {
        var id= _projectViewModel.ID;
        await Shell.Current.GoToAsync($"{nameof(EditProjectView)}?{nameof(EditProjectView.ItemGuid)}={id}");
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CollectionView.SelectedItem == null) return;
        var id = ((TaskModel)CollectionView.SelectedItem).Id.ToString();
        await Shell.Current.GoToAsync($"{nameof(EditTaskView)}?{nameof(EditTaskView.TaskId)}={id}");
    }
}