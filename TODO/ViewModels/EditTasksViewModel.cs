using System;
using TODO.Models;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class EditTasksViewModel : BaseViewModel
    {
        
        public EditTasksViewModel()
        {
            CancelOrDeleteCommand = new Command(CancelOrDeleteAction);
            SaveCommand = new Command(SaveAction);

        }

        private async void SaveAction()
        {
            TaskModel save = new TaskModel()
            {
                Guid = _guid == String.Empty ? Guid.NewGuid().ToString() : _guid,
                Description = Description,
                CreateTime = CreateTime
            };
            await _taskDataService.UpdateItemAsync(save);
            
            await Shell.Current.GoToAsync("..");
        }

        private async void CancelOrDeleteAction()
        {
            if (_guid != String.Empty)
            {
                await _taskDataService.DeleteItemAsync(_guid);
            }
            await Shell.Current.GoToAsync("..");
        }

        private string _cancelText = "Cancel";
        public string CancelOrDeleteText
        {
            get => _cancelText;
            set => SetPropertyValue(ref _cancelText, value);
        }

        
        public async void set(string guid)
        {
            CancelOrDeleteText = "Delete";
            
            var result = await _taskDataService.GetItemAsync(guid);
            if (result.IsFailure)
            {
                await Shell.Current.GoToAsync("..");
                return;
            }

            var task = result.Value;
            Description = task.Description;
            CreateTime = task.CreateTime;
            _guid = task.Guid;
        }
        
        
    
        private string _description = string.Empty;
        private string _guid = string.Empty;
        
        public string Description { 
            get => _description;
            set => SetPropertyValue(ref _description, value);
        }
        
        private DateTime _createTime = DateTime.Now;
        
        public DateTime CreateTime { 
            get=>_createTime;
            set => SetPropertyValue(ref _createTime, value);
        }

        public Command CancelOrDeleteCommand { get; }
        public Command SaveCommand { get; }
        
    }
}