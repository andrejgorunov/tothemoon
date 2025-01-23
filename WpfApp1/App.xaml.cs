using System;
using System.IO;
using System.Windows;

namespace ConferenceManagementSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Логирование ошибок
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = (Exception)args.ExceptionObject;
                File.WriteAllText("error.log", $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            };
        }
    }
}