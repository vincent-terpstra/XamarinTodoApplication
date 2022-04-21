using System.ComponentModel;
using System.Runtime.CompilerServices;
using TODO.Annotations;
using TODO.Models;
using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    protected IDataService<TaskModel> _taskDataService { get; }
    protected BaseViewModel()
    {
        _taskDataService = DependencyService.Get<IDataService<TaskModel>>();
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (value == null ? field == null : value.Equals(field)) 
            return false;
        
        field = value;
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}