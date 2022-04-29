using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using TODO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllProjectsView : ContentPage
    {
        private readonly AllProjectsViewModel _allProjectsViewModel;
        public AllProjectsView()
        {
            InitializeComponent();
            BindingContext = _allProjectsViewModel = new AllProjectsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _allProjectsViewModel.OnAppearing();
            CollectionView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EditProjectView));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CollectionView.SelectedItem == null) return;
            var id = ((ProjectModel)CollectionView.SelectedItem).ID.ToString();
            await Shell.Current.GoToAsync($"{nameof(ProjectView)}?{nameof(ProjectView.ItemGuid)}={id}");

        }
    }
}