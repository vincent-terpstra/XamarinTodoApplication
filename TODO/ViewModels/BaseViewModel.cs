using System.ComponentModel;
using System.Runtime.CompilerServices;
using TODO.Annotations;

namespace TODO.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
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