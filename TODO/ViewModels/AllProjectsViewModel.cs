using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class AllProjectsViewModel : BaseViewModel
    {
        public AllProjectsViewModel()
        {
            Items = new();
        }

        public ObservableCollection<ProjectModel> Items { get;  }
        
        public async Task OnAppearing()
        {
            var result = await ProjectDataService.GetAllItemsAsync();
            
            Items.Clear();
            foreach (var task in result)
            {
                Items.Add(task);
            }
            
        }
    }
}