using System;

namespace TODO.ViewModels
{
    public class EditTasksViewModel : BaseViewModel
    {
        
        private string _description = string.Empty;
        private string _guid = string.Empty;
        private DateTime _createDate = DateTime.Now;
        
        public string Description { 
            get => _description;
            set => SetPropertyValue(ref _description, value);
        }

        
        public DateTime CreateDate { 
            get=>_createDate;
            set => SetPropertyValue(ref _createDate, value);
        }
        
        
        
    }
}