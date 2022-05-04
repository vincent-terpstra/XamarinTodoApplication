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
    public partial class AllTasksView : ContentPage
    {
        private readonly AllTasksViewModel _allTasksViewModel;
        public AllTasksView()
        {
            InitializeComponent();
            BindingContext = _allTasksViewModel = new AllTasksViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _allTasksViewModel.OnAppearing();
            CollectionView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EditTaskView));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CollectionView.SelectedItem == null) return;
            var id = ((TaskModel)CollectionView.SelectedItem).Id.ToString();
            await Shell.Current.GoToAsync($"{nameof(EditTaskView)}?{nameof(EditTaskView.TaskId)}={id}");

        }
    }
}