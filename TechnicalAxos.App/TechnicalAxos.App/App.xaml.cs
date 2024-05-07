﻿using Xamarin.Forms;

namespace TechnicalAxos.App
{
    public partial class App : Application
    {
        public static Page ContextApp { get; set; }
        public App()
        {
            InitializeComponent();

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
