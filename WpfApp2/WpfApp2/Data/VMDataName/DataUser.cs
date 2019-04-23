using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Data.VMDataName
{
    public class DataUser : BaseVM
    {
        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged("Id"); }
        }


        private string nameMess = "Имя";
        public string Name
        {
            get { return nameMess; }
            set { nameMess = value; NotifyPropertyChanged("Name"); }
        }

        private string passwordMess = "Пароль";
        public string Password
        {
            get { return passwordMess; }
            set { passwordMess = value; NotifyPropertyChanged("Password"); }
        }
    }
}
