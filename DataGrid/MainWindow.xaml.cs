using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();
        public MainWindow()
        {
            InitializeComponent();
            _users.Add(new UserVM()
            {
                Id = 1,
                Name = "John Doe",
                ImageUrl = "http://www.hawthorngroup.com/wp-content/uploads/2019/03/john-1-300x300.jpg"
            });
            dgSimple.ItemsSource = _users;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            _users.Add(new UserVM() { Name = "New user" });
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgSimple.SelectedItem != null)
            {
                if (dgSimple.SelectedItem is UserVM)
                {
                    var userView = (dgSimple.SelectedItem as UserVM);
                    userView.Name = "Kate";
                    userView.ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwallpapershome.ru%2Fimages%2Fpages%2Fpic_v%2F21488.jpg&imgrefurl=https%3A%2F%2Fwallpapershome.ru%2Ffoto%2Fkartinki-pro-lyubov-21488.html&tbnid=zsDlj02lFdxyNM&vet=12ahUKEwiskrKw4fXkAhXEcZoKHX8uAF8QMygCegQIARAa..i&docid=dIRm2TseLRMFUM&w=640&h=1138&q=image%20%D1%84%D0%BE%D1%82%D0%BE&ved=2ahUKEwiskrKw4fXkAhXEcZoKHX8uAF8QMygCegQIARAa.jpg";
                }
            }
        }
    }
}
