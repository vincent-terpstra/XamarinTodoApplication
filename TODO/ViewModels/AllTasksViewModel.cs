using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class AllTasksViewModel
    {
        public List<TaskModel> Items { get; set; }


        public async Task OnAppearing()
        {
            var taskService = DependencyService.Get<IDataService<TaskModel>>();
            var result = await taskService.GetAllItemsAsync();

            if (result.IsSuccess)
                Items = result.Value;
        }
    }
}