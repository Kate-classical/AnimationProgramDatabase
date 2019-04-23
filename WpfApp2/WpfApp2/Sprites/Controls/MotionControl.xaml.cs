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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Sprites.Controls
{
    /// <summary>
    /// Логика взаимодействия для MotionControl.xaml
    /// </summary>
    public partial class MotionControl : BaseControl 
    {
        int selectedItem;

        public MotionControl()
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

            Data.SqareVM sqare = this.DataContext as Data.SqareVM;
          
            foreach (Canvas canvas in Helpers.Helper.FindVisualChildren<Canvas>(Helpers.Helper.GetWindow()))
            {
                if(canvas.Name == "CompilarPanel")
                {
                    Data.VM.ItemModel compilarVM = canvas.DataContext as Data.VM.ItemModel;

                    selectedItem = Convert.ToInt32(compilarVM.Header)-1;          
                    compilarVM.Data.Add(new Data.SqareVM() {
                        Color = sqare.Color,                       
                        Position = new Point(e.GetPosition(this).X-200, e.GetPosition(this).Y),
                        Text = sqare.Text
                    });
                }
            }

            AddControl addControl = new AddControl(sqare,selectedItem, new Point(e.GetPosition(this).X - 200, e.GetPosition(this).Y));
           
         
        }
    }
}
