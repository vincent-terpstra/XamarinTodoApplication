using System;
using SQLitePCL;
using TODO.Models;
using Xamarin.Forms;

namespace TODO.ViewModels;

public class EditProjectViewModel : BaseViewModel
{
    public EditProjectViewModel()
    {
        SaveCommand = new Command(SaveProjectAction);
        CancelOrDeleteCommand = new Command(CancelOrDeleteAction);

    }

    private async void CancelOrDeleteAction()
    {
        if(_id != 0)
            await ProjectDataService.DeleteItemAsync(
                new ProjectModel(){ ID = _id }
            );
            
        await Shell.Current.GoToAsync("//AllProjects");
    }

    private async void SaveProjectAction()
    {
         ProjectModel save = new ProjectModel()
        {
            ID =_id,
            Description = Description,
            Title  = _title,
            CreateDate = CreateDate
        };
        await ProjectDataService.UpdateItemAsync(save);
            
        await Shell.Current.GoToAsync("..");
    }

    
    
    private DateTime CreateDate
    {
        get => _createDate;
        set => SetPropertyValue(ref _createDate, value);
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => SetPropertyValue(ref _description, value);
    }

    private string _title;

    public string Title
    {
        get => _title;
        set => SetPropertyValue(ref _title, value);
    }

    private long _id = 0;
    public Command SaveCommand { get; }
    public Command CancelOrDeleteCommand { get; }
    
    private string _cancelText = "Cancel";
    private DateTime _createDate = DateTime.Now;

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
            var result = await ProjectDataService.GetItemAsync(id);
            Description = result.Description;
            _id = result.ID;
            Title = result.Title;
            CreateDate = _createDate;
        }
        catch
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}