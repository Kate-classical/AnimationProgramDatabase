using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Sprites.Controls
{
    class AddControl : Data.BaseVM
    {
        private Data.SqareVM sqareVM;
        private int selectedItem;
        private Point position;

        public AddControl(Data.SqareVM sqareVM,int n, Point point)
        {
            this.sqareVM = sqareVM;
            this.selectedItem = n;
            this.position = point;
            Adapter();
        }
        
        private void Adapter()
        {
            db.MainSqares.Add(
                new Data.VMDataName.MainSqare()
                {
                    Id = sqareVM.Id,
                    Id_Item = selectedItem,
                    Id_User = Cash.id,
                    Text=sqareVM.Text,
                    X = position.X,
                    Y = position.Y,
                    Color = sqareVM.Color.ToString()
                });
            db.SaveChanges();

        }
    }
}
