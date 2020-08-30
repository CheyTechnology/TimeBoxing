using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeBoxingCross
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new MainPage();
            FilePath = filePath;
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

        #region static Properties

        public static string FilePath = string.Empty;

        #endregion 

    }
}
