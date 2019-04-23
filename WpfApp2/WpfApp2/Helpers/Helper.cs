using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp2.Sprites.Controls;

namespace WpfApp2.Helpers
{
    public class Helper
    {
        static public MainWindow GetWindow()
        {
            Application application = Application.Current;
            MainWindow window = (MainWindow)application.MainWindow;
            return window;
        }

        static public T FindParent<T>(FrameworkElement from) where T : FrameworkElement
        {
            FrameworkElement current = from;
            T t;
            do
            {
                t = current as T;
                current = (FrameworkElement)VisualTreeHelper.GetParent(current);
            }
            while (t == null && current != null);
            return t;
        }

        static public WhileControl GetWhile(FrameworkElement from)
        {
            int ch = 0;
            var current_ = (FrameworkElement)VisualTreeHelper.GetParent(from);

            Canvas  current =  (Canvas)VisualTreeHelper.GetParent(current_);
            var x = Canvas.GetLeft(from);
            var y = Canvas.GetTop(from);
            while(Canvas.GetLeft(current.Children[ch]) <= x && Canvas.GetTop(current.Children[ch]) <= y)
            {
                ch++;
            }
            WhileControl whileControl = current.Children[ch] as WhileControl;
            return whileControl;
        }

        static public T FindParent2<T>(FrameworkElement from) where T : FrameworkElement
        {
            T t = from as T;
            FrameworkElement current = current = (FrameworkElement)VisualTreeHelper.GetParent(from);
           
            do
            {
                t = current as T;
                current = (FrameworkElement)VisualTreeHelper.GetParent(current);
            }
            while (t == null && current != null);
            return t;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if(depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
