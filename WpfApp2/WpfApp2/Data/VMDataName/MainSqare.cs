using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Data.VMDataName
{
    public class MainSqare : BaseVM
    {
        public int Id { get; set; }

        string color;
        public string Color
        {
            get { return color; }
            set { color = value; NotifyPropertyChanged("Color"); }
        }

        double x;
        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged("X"); }
        }

        double y;
        public double Y
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged("Y"); }
        }

        string text;
        public string Text
        {
            get { return text; }
            set { text = value; NotifyPropertyChanged("Text"); }
        }

        int id_User;
        public int Id_User
        {
            get { return id_User; }
            set { id_User = value; NotifyPropertyChanged("Id_User"); }
        }

        int id_item;
        public int Id_Item
        {
            get { return id_item; }
            set { id_item = value; NotifyPropertyChanged("Id_Item"); }
        }
    }
}
