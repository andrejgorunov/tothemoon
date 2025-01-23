using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ConferenceManagementSystem.Models;

namespace ConferenceManagementSystem
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // Обработчик изменения текста в поле логина
        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernamePlaceholder.Visibility = string.IsNullOrEmpty(UsernameBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Обработчик изменения текста в поле пароля
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Обработчик нажатия кнопки "Войти"
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == UsernameBox.Text && u.Password == PasswordBox.Password);
                    if (user != null)
                    {
                        MessageBox.Show("Авторизация успешна!");
                        OpenRoleWindow(user.Employee.Position);
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Открытие окна в зависимости от роли
        private void OpenRoleWindow(string position)
        {
            Window roleWindow = null;

            switch (position)
            {
                case "Организатор":
                    roleWindow = new OrganizerWindow();
                    break;
                case "Техник":
                    roleWindow = new TechnicianWindow();
                    break;
                case "Зав. секции":
                    roleWindow = new HeadWindow();
                    break;
                default:
                    MessageBox.Show("Неизвестная роль пользователя");
                    return;
            }

            roleWindow.Show();
            this.Close();
        }
    }
}