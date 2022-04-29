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
                ID =_id,
                Description = Description,
                CreateTime = CreateTime
            };
            await TaskDataService.UpdateItemAsync(save);
            
            await Shell.Current.GoToAsync("..");
        }

        private async void CancelOrDeleteAction()
        {
            if(_id != 0)
                await TaskDataService.DeleteItemAsync(
                    new TaskModel(){ ID = _id }
                );
            
            await Shell.Current.GoToAsync("..");
        }

        private string _cancelText = "Cancel";
        public string CancelOrDeleteText
        {
            get => _cancelText;
            set => SetPropertyValue(ref _cancelText, value);
        }

        
        public async void Set(long id)
        {
            CancelOrDeleteText = "Delete";
            try
            {
                var result = await TaskDataService.GetItemAsync(id);    
                var task = result;
                Description = task.Description;
                CreateTime = task.CreateTime;
                _id = task.ID;
            }
            catch
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        
        
    
        private string _description = string.Empty;
        private long _id = 0;
        
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