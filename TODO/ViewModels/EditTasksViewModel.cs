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
                Id =_id,
                Description = Description,
                CreateTime = CreateTime,
                ProjectId = _projectId
            };
            await TaskDataService.UpdateItemAsync(save);
            
            await Shell.Current.GoToAsync("..");
        }

        private async void CancelOrDeleteAction()
        {
            if(_id != 0)
                await TaskDataService.DeleteItemAsync(
                    new TaskModel(){ Id = _id }
                );
            
            await Shell.Current.GoToAsync("..");
        }

        private string _cancelText = "Cancel";
        public string CancelOrDeleteText
        {
            get => _cancelText;
            set => SetPropertyValue(ref _cancelText, value);
        }

        
        public async void SetTaskId(long id)
        {
            CancelOrDeleteText = "Delete";
            try
            {
                var task = await TaskDataService.GetItemAsync(id);    
                Description = task.Description;
                CreateTime = task.CreateTime;
                ProjectId = task.Id;
                _id = task.Id;
                
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

        private long _projectId;
        public long ProjectId
        {
            get => _projectId;
            set => SetPropertyValue(ref _projectId, value);
        }
        
        public void SetProjectId(long value)
        {
            ProjectId = value;
        }
        
        public Command CancelOrDeleteCommand { get; }
        public Command SaveCommand { get; }
    }
}