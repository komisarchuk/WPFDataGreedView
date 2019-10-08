using DataGrid.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioButton = System.Windows.Controls.RadioButton;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        EFContext _context = new EFContext();
        public RadioButton rbMale = new RadioButton();
        public RadioButton rbFemale = new RadioButton();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgSimple.SelectedItem != null)
            {
                if (dgSimple.SelectedItem is UserVM)
                {
                    var userView = (dgSimple.SelectedItem as UserVM);
                    userView.Name = "Kate";
                    userView.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/71/Katherine_Schwarzenegger_World_Dog_Awards_2015_%28cropped%29.jpg/653px-Katherine_Schwarzenegger_World_Dog_Awards_2015_%28cropped%29.jpg";
                }
            }
        }
        private void DgSimple_Loaded(object sender, RoutedEventArgs e)
        {
            var _people = from p in _context.People
                          select new 
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Photo = p.Photo,
                              Sex = p.Sex
                          };
            dgSimple.ItemsSource = _people.ToList();
  
            foreach (var _person in _people)
            {
                if (_person.Sex)
                {
                    rbMale.IsChecked = true;
                    rbFemale.IsChecked = false;
                }
                else
                {
                    rbFemale.IsChecked = true;
                    rbMale.IsChecked = false;
                }
            }

        }

   
       
    }


    public class User : INotifyPropertyChanged
    {
        private string _name;
        private bool _sex;
      
        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public bool Sex
        {
            get { return this._sex; }
            set
            {
                if (this._sex != value)
                {
                    this._sex = value;
                    this.NotifyPropertyChanged("Sex");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                if (propName == "Name" || propName == "Sex")
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}