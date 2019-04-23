using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp2.Helpers;

namespace WpfApp2.Data
{
    public class SqareVM : BaseVM
    {
        public SqareVM()
        {
            RequestMove = new SqareCommand<Point>(MoveTo);
        }
        public ICommand RequestMove { get; }

        void MoveTo(Point newPosition)
        {
            Position = newPosition;
        }

        public object Clone()
        {
            return new SqareVM
            {
                Position = this.Position
            };
        }

        public int Id { get; set; }

        Point position;
        public Point Position
        {
            get { return position; }
            set { if (position != value) { position = value; NotifyPropertyChanged(); } }
        }

        Brush color;
        public Brush Color
        {
            get { return color; }
            set { if (color != value) { color = value; NotifyPropertyChanged(); } }
        }

        String text;
        public string Text
        {
            get { return text; }
            set { if (text != value) { text = value; NotifyPropertyChanged(); } }
        }
    }
}
