using TODO.Services;
using Xamarin.Forms;

namespace TODO.ViewModels;

public class ProjectViewModel : BaseViewModel
{
    private string _cancelText = "Cancel";
    public string CancelOrDeleteText
    {
        get => _cancelText;
        set => SetPropertyValue(ref _cancelText, value);
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => SetPropertyValue(ref _description, value);
    }
    
    public long ID { get; set; }

    public async void Set(long id)
    {
        CancelOrDeleteText = "Delete";
        try
        {
            var result = await ProjectDataService.GetItemAsync(id);
            Description = result.Description;
            ID = result.ID;
        }
        catch
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}