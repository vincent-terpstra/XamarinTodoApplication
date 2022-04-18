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
        private AllTasksViewModel _allTasksViewModel;
        public AllTasksView()
        {
            InitializeComponent();
            BindingContext = _allTasksViewModel = new AllTasksViewModel();
            TaskService = DependencyService.Get<IDataService<TaskModel>>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _allTasksViewModel.OnAppearing();
        }

        public IDataService<TaskModel> TaskService { get; }
    }
}