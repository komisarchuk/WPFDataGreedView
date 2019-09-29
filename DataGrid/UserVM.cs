using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class UserVM : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private string image;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public string ImageUrl
        {
            get { return this.image; }
            set
            {
                if (this.image != value)
                {
                    this.image = value;
                    this.NotifyPropertyChanged("ImageUrl");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            //if (this.PropertyChanged != null)
            //    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
