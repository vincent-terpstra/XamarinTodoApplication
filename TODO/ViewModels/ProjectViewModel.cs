﻿using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;
using TODO.Views;
using Xamarin.Forms;

namespace TODO.ViewModels;

public class ProjectViewModel : BaseViewModel
{
    public ProjectViewModel()
    {
        OnAddTaskClicked = new Command(OnAddTaskAction);
        Items = new ObservableCollection<TaskModel>();
        
    }

    public ObservableCollection<TaskModel> Items { get;  }
    private async void OnAddTaskAction()
    {
        await Shell.Current.GoToAsync($"{nameof(EditTaskView)}?{nameof(EditTaskView.ProjectId)}={ID}");
    }

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
    
    public long ID { get; private set; }

    public Command OnAddTaskClicked { get; }

    private string _title;
    public string Title
    {
        get => _title;
        set => SetPropertyValue(ref _title, value);
    }


    public async void Set(long id)
    {
        CancelOrDeleteText = "Delete";
        try
        {
            var result = await ProjectDataService.GetItemAsync(id);
            Description = result.Description;
            ID = result.ID;
            Title = result.Title;

            Expression<Func<TaskModel, bool>> filter = task => task.ProjectId == result.ID;
            var relatedTasks = await TaskDataService.GetFilteredItemsAsync(filter);

            Items.Clear();
            foreach (var task in relatedTasks)
            {
                Items.Add(task);
            }
        }
        catch
        {
            await Shell.Current.GoToAsync("..");
        }
    }
    
    public async Task CompleteTask()
    {
        
    }
}