using System.Windows;
using System.Windows.Controls;
using ConferenceManagementSystem.Models;

namespace ConferenceManagementSystem
{
    public partial class MainWindow : Window
    {
        private string _userRole; // Роль пользователя

        public MainWindow(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
            ConfigureNavigation(); // Настраиваем навигацию в зависимости от роли
        }

        // Настройка навигации в зависимости от роли
        private void ConfigureNavigation()
        {
            switch (_userRole)
            {
                case "Организатор":
                    MainFrame.Navigate(new OrganizerWindow()); // Загружаем окно организатора
                    break;
                case "Техник":
                    MainFrame.Navigate(new TechnicianWindow()); // Загружаем окно техника
                    break;
                case "Зав. секции":
                    MainFrame.Navigate(new HeadWindow()); // Загружаем окно зав. секции
                    break;
                default:
                    MessageBox.Show("Неизвестная роль пользователя");
                    break;
            }
        }

        // Обработчик нажатия кнопки "Выйти"
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Возвращаемся к окну авторизации
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close(); // Закрываем текущее окно
        }
    }
}