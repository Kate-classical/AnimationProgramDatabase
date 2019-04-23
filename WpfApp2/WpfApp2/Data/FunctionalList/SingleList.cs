using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp2.Sprites.Models;

namespace WpfApp2.Data.FunctionalList
{
    public class SingleList : BaseVM
    {
        public ObservableCollection<WhileModel> Squares1 { get; } =
            new ObservableCollection<WhileModel>()
            {
                new WhileModel(){Position = new System.Windows.Point(30,190)},
                new WhileModel(){Position = new System.Windows.Point(30,250)}
            };

        public ObservableCollection<Data.SqareVM> Squares { get; } =
            new ObservableCollection<Data.SqareVM>()
            {
                new Data.SqareVM(){Position = new System.Windows.Point(30,30), Color= Brushes.Blue, Text="Вперёд на"},
                new Data.SqareVM(){Position = new System.Windows.Point(30,70), Color= Brushes.Blue, Text="Назад на"},
                new Data.SqareVM(){Position = new System.Windows.Point(30,110), Color= Brushes.Red, Text="Стой"},
                new Data.SqareVM(){Position = new System.Windows.Point(30,150), Color= Brushes.Green, Text="Элемент"}
            };
    }
}
