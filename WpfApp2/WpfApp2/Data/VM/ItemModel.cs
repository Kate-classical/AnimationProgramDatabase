using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Data.VM
{
    public class ItemModel : BaseVM
    {
        public ItemModel(string Header, ObservableCollection<SqareVM> Data)
        {
            this.Header = Header;
            this.Data = Data;
        }
        public string Header { get; set; }
        public ObservableCollection<SqareVM> Data { get; set; }
    }
}
