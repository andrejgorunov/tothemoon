using System.Data.Entity;
using System;
using System.Linq;
using System.Windows;
using ConferenceManagementSystem.Models;

namespace ConferenceManagementSystem
{
    public partial class HeadWindow : Window
    {
        public HeadWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ConferenceContext())
            {
                SpeakersDataGrid.ItemsSource = context.Speakers.ToList();
                ReportsDataGrid.ItemsSource = context.Reports.ToList();
            }
        }

        // Создание докладчика
        private void CreateSpeaker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newSpeaker = new Speaker
                {
                    Name = "Новый докладчик",
                    Specialization = "Специализация",
                    ContactInfo = "contact@example.com"
                };

                using (var context = new ConferenceContext())
                {
                    context.Speakers.Add(newSpeaker);
                    context.SaveChanges();
                    LoadData(); // Обновляем данные
                }

                MessageBox.Show("Докладчик успешно создан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Создание доклада
        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newReport = new Report
                {
                    Title = "Новый доклад",
                    Description = "Описание доклада",
                    SpeakerId = 1, // Пример ID докладчика
                    Status = "В ожидании"
                };

                using (var context = new ConferenceContext())
                {
                    context.Reports.Add(newReport);
                    context.SaveChanges();
                    LoadData(); // Обновляем данные
                }

                MessageBox.Show("Доклад успешно создан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
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