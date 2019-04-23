using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp2.Sprites.Models;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp2.Data.VMPages
{
    public class CompilarVM : BaseVM
    {
        private CompilarVM CompilarVM_ { get; set; }
        //  private int idUser = 0;

        public void SetCompilar(int idUser)
        {
            foreach (UserControl userControl in Helpers.Helper.FindVisualChildren<UserControl>(Helpers.Helper.GetWindow()))
            {
                if (userControl.Name == "compilar")
                    CompilarVM_ = userControl.DataContext as CompilarVM;
            }

            CompilarVM_.ListHeader = null;
            CompilarVM_.MainSqares = null;
            CompilarVM_.Data = null;

            //  db.ItemsHeader.Where(t => t.Id_User == idUser).Load();

            CompilarVM_.ListHeader = db.ItemsHeader.Where(t => t.Id_User == idUser);

            // db.MainSqares.Where(t => t.Id_User == idUser).Load();
            CompilarVM_.MainSqares = db.MainSqares.Where(t => t.Id_User == idUser);

            while (CompilarVM_.Items.Count != 0)
            {
                CompilarVM_.Items.RemoveAt(0);
            }

            foreach (var it in CompilarVM_.ListHeader)
            {
                CompilarVM_.Data = new ObservableCollection<Data.SqareVM>();
                foreach (var dd in CompilarVM_.MainSqares.Where(w => w.Id_Item == Convert.ToInt32(it.Header) - 1))
                {
                    CompilarVM_.Data.Add(Adapter(dd));
                }
                CompilarVM_.Items.Add(new WpfApp2.Data.VM.ItemModel(it.Header, CompilarVM_.Data));
            }
        }


        public CompilarVM()
        {
            Items = new ObservableCollection<Data.VM.ItemModel>();
        }

        public ObservableCollection<WpfApp2.Data.VM.ItemModel> Items { get; set; }
        public IEnumerable<WpfApp2.Data.VMDataName.ItemHeader> ListHeader { get; set; }
        public IEnumerable<WpfApp2.Data.VMDataName.MainSqare> MainSqares { get; set; }

        private Data.SqareVM Adapter(Data.VMDataName.MainSqare mainSqare)
        {
            Data.SqareVM sqare = new Data.SqareVM()
            {
                Color = (SolidColorBrush)new BrushConverter().ConvertFromString(mainSqare.Color),
                Position = new System.Windows.Point(mainSqare.X, mainSqare.Y),
                Text = mainSqare.Text
            };
            return sqare;
        }

        public ObservableCollection<Data.SqareVM> Data { get; set; } =
         new ObservableCollection<Data.SqareVM>()
         {
             //   new Data.SqareVM(){Position = new System.Windows.Point(30,0), Color= Brushes.Blue, Text="Вперед на"},
             //   new Data.SqareVM(){Position = new System.Windows.Point(30,70), Color= Brushes.Blue, Text="Вперед на"}
         };
        public ObservableCollection<WhileModel> While { get; set; } =
         new ObservableCollection<WhileModel>()
         {
                new WhileModel(){Position = new System.Windows.Point(30,110)},
                new WhileModel(){Position = new System.Windows.Point(30,180)},

         };
    }
}
