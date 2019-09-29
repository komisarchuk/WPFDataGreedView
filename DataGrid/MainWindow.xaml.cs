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
                    userView.ImageUrl = "https://wallpapershome.ru/images/pages/pic_h/14851.jpg";
                }
            }
        }
    }
}
