using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Data;

namespace WpfApp2.Sprites.Models
{
    public class WhileModel : SqareVM
    {
        double increase;
        public double Increase
        {
            get { return increase; }
            set { if (increase != value) { increase = value; NotifyPropertyChanged(); } }
        }
    }
}
