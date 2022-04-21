using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class AllTasksViewModel : BaseViewModel
    {
        public AllTasksViewModel()
        {
            Items = new();
        }

        public ObservableCollection<TaskModel> Items { get;  }
       


        public async Task OnAppearing()
        {
            var result = await _taskDataService.GetAllItemsAsync();

            if (result.IsSuccess)
            {
                Items.Clear();
                foreach (var task in result.Value)
                {
                    Items.Add(task);
                }
            }
        }
    }
}