using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Data.VMDataName
{
    public class ItemHeader : BaseVM
    {
        public int Id { get; set; }
        string header;
        public string Header
        {
            get { return header; }
            set { header = value; NotifyPropertyChanged("Header"); }
        }

        int id_User;
        public int Id_User
        {
            get { return id_User; }
            set { id_User = value; NotifyPropertyChanged("Id_User"); }
        }
    }
}
