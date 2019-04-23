using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Sprites.Controls
{
    /// <summary>
    /// Логика взаимодействия для WhileControl.xaml
    /// </summary>
    public partial class WhileControl : BaseControl
    {
        private bool checkCotrol = false;
        Models.WhileModel whileModel;

        public WhileControl()
        {
            InitializeComponent();              
        }

      
        private void BaseControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseDown(sender, e);
        }

        private void BaseControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OnMouseUp2(sender, e);
           //MessageBox.Show(e.GetPosition(this).ToString());

            whileModel = this.DataContext as Models.WhileModel;
         //   Cash.TabControl.Items[0].Data.While.Add(new Models.WhileModel { Position = new Point( e.GetPosition(this).X - 200, e.GetPosition(this).Y), Color = Brushes.Orange, Text= whileModel.Text});
        }

        private void BaseControl_MouseEnter(object sender, MouseEventArgs e) //когда входит
        {
           
            checkCotrol = true;
        }
              
        private void BaseControl_MouseLeave(object sender, MouseEventArgs e) //когда выходит за пределы
        {
            checkCotrol = false;
        }
    }
}
