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
    [QueryProperty(nameof(TaskId), nameof(TaskId))]
    [QueryProperty(nameof(ProjectId), nameof(ProjectId))]
    public partial class EditTaskView : ContentPage
    {
        private readonly EditTasksViewModel _editTasksViewModel;
        public EditTaskView()
        {
            InitializeComponent();
            BindingContext = _editTasksViewModel = new EditTasksViewModel();
        }
        
        public long TaskId
        {
            set => _editTasksViewModel.SetTaskId(value);
        }

        public long ProjectId
        {
            set => _editTasksViewModel.SetProjectId(value);
        }
    }
}