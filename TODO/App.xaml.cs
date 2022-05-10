using System;
using System.IO;
using SQLite;
using TODO.Models;
using TODO.Services;
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

        protected override void OnStart()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TODOProjectDB.db3");
        
            var database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<ProjectModel>().Wait();
            database.CreateTableAsync<TaskModel>().Wait();
            DependencyService.RegisterSingleton(database);
            // Handle when your app starts
            DependencyService.Register<TaskServiceSQLite>();
            DependencyService.Register<ProjectServiceSQLite>();
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