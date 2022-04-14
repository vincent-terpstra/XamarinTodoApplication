using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemGuid), nameof(ItemGuid))]
    public partial class EditTaskView : ContentPage
    {
        public EditTaskView()
        {
            InitializeComponent();
            BindingContext = new TaskModel();
            TaskService = DependencyService.Get<IDataService<TaskModel>>();
        }
        
        private IDataService<TaskModel> TaskService { get; }
        private string _description = string.Empty;
        private string _guid = string.Empty;
        private DateTime _createDate = DateTime.Now;
        
        public string Description { 
            get => _description;
            set => _description = value;
        }

        
        public DateTime CreateDate { 
            get=>_createDate;
            set => _createDate = value;
        }


        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await TaskService.UpdateItemAsync(new TaskModel()
                {
                    guid = _guid,
                    description = Description,
                    createTime = CreateDate
                }
            );
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await TaskService.DeleteItemAsync(_guid);
            await Shell.Current.GoToAsync("..");
        }

        private string ItemGuid
        {
            set => LoadTask(value);
        }

        private async void LoadTask(string guid)
        {
            var tasks = DependencyService.Get<IDataService<TaskModel>>();
            var result = await tasks.GetItemAsync(guid);
            if (result.IsFailure)
                await Shell.Current.GoToAsync("..");

            TaskModel val = result.Value;
            Description = val.description;
            _guid = val.guid;
            CreateDate = val.createTime;

        }
    }
}