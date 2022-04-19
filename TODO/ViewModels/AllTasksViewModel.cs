using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class AllTasksViewModel : BaseViewModel
    {
        private List<TaskModel> _items;

        public List<TaskModel> Items
        {
            get=> _items; 
            set=>SetPropertyValue(ref _items, value);
        }


        public async Task OnAppearing()
        {
            var taskService = DependencyService.Get<IDataService<TaskModel>>();
            var result = await taskService.GetAllItemsAsync();

            if (result.IsSuccess)
                Items = result.Value;
        }
    }
}