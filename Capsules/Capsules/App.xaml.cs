using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Capsules.Services;
using Capsules.Views;
using System.Diagnostics;

namespace Capsules
{
    public partial class App : Application
    {
        public static Repo Repository;
        public App(string dbPath)
        {
            InitializeComponent();

            Debug.WriteLine($"Database location at: {dbPath}");

            Repository = new Repo(dbPath);

            // DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
