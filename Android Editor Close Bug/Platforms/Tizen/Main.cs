using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Android_Editor_Close_Bug {
    internal class Program : MauiApplication {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args) {
            var app = new Program();
            app.Run(args);
        }
    }
}
