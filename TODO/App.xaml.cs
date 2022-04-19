using System;
using TODO.Models;
using TODO.Services;
using TODO.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TODO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            DependencyService.Register<TaskServiceList>();
            var taskService = DependencyService.Get<IDataService<TaskModel>>();
            await taskService.LoadItemsAsync();
            MainPage = new AppShell();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}