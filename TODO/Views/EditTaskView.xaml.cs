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
    [QueryProperty(nameof(ItemGuid), nameof(ItemGuid))]
    public partial class EditTaskView : ContentPage
    {
        private readonly EditTasksViewModel _editTasksViewModel;
        public EditTaskView()
        {
            InitializeComponent();
            BindingContext = _editTasksViewModel = new EditTasksViewModel();
        }
        
        public long ItemGuid
        {
            set => _editTasksViewModel.Set(value);
        }
    }
}