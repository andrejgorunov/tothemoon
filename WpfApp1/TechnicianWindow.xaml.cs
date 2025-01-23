using System.Data.Entity;
using System;
using System.Linq;
using System.Windows;
using ConferenceManagementSystem.Models;

namespace ConferenceManagementSystem
{
    public partial class TechnicianWindow : Window
    {
        public TechnicianWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ConferenceContext())
            {
                ReportsDataGrid.ItemsSource = context.Reports.ToList();
            }
        }

        // Просмотр докладов
        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        // Изменение статуса доклада
        private void ChangeReportStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedReport = ReportsDataGrid.SelectedItem as Report;
                if (selectedReport != null)
                {
                    selectedReport.Status = "Одобрен";
                    using (var context = new ConferenceContext())
                    {
                        context.Entry(selectedReport).State = EntityState.Modified;
                        context.SaveChanges();
                        LoadData(); // Обновляем данные
                    }

                    MessageBox.Show("Статус доклада обновлен!");
                }
                else
                {
                    MessageBox.Show("Выберите доклад");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Выход из системы
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}