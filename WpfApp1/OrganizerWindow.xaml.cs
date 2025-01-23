using System.Data.Entity;
using System;
using System.Linq;
using System.Windows;
using ConferenceManagementSystem.Models;

namespace ConferenceManagementSystem
{
    public partial class OrganizerWindow : Window
    {
        public OrganizerWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных
        private void LoadData()
        {
            using (var context = new ConferenceContext())
            {
                EmployeesDataGrid.ItemsSource = context.Employees.ToList();
            }
        }

        // Добавление сотрудника
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newEmployee = new Employee
                {
                    Name = "Новый сотрудник",
                    Position = "Должность",
                    Status = "Активен",
                    WorkSchedule = "Пн-Пт, 9:00-18:00"
                };

                using (var context = new ConferenceContext())
                {
                    context.Employees.Add(newEmployee);
                    context.SaveChanges();
                    LoadData(); // Обновляем данные
                }

                MessageBox.Show("Сотрудник успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Обновление статуса сотрудника
        private void UpdateEmployeeStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedEmployee = EmployeesDataGrid.SelectedItem as Employee;
                if (selectedEmployee != null)
                {
                    selectedEmployee.Status = "Уволен";
                    using (var context = new ConferenceContext())
                    {
                        context.Entry(selectedEmployee).State = EntityState.Modified;
                        context.SaveChanges();
                        LoadData(); // Обновляем данные
                    }

                    MessageBox.Show("Статус сотрудника обновлен!");
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Удаление сотрудника
        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedEmployee = EmployeesDataGrid.SelectedItem as Employee;
                if (selectedEmployee != null)
                {
                    using (var context = new ConferenceContext())
                    {
                        context.Employees.Remove(selectedEmployee);
                        context.SaveChanges();
                        LoadData(); // Обновляем данные
                    }

                    MessageBox.Show("Сотрудник успешно удален!");
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника");
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