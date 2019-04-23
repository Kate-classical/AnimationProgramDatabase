using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2.Sprites.Controls
{
    public class BaseControl : UserControl
    {
        Vector relativeMousePos; // смещение мыши от левого верхнего угла квадрата
        Canvas container;        // канвас-контейнер

        Point startPoint;

        public BaseControl()
        {
            SetBinding(RequestMoveCommandProperty, new Binding("RequestMove"));
        }
        public ICommand RequestMoveCommand
        {
            get { return (ICommand)GetValue(RequestMoveCommandProperty); }
            set { SetValue(RequestMoveCommandProperty, value); }
        }

        public Shape DraggedImageContainer
        {
            get { return (Shape)GetValue(DraggedImageContainerProperty); }
            set { SetValue(DraggedImageContainerProperty, value); }
        }

        public static readonly DependencyProperty DraggedImageContainerProperty =
            DependencyProperty.Register(
                "DraggedImageContainer", typeof(Shape), typeof(BaseControl));

        public static readonly DependencyProperty RequestMoveCommandProperty =
            DependencyProperty.Register("RequestMoveCommand", typeof(ICommand),
                                        typeof(BaseControl));

        // по нажатию на левую клавишу начинаем следить за мышью
       public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // container = Helpers.Helper.FindParent<Canvas>(this);
          //  VM.SqareVM sqareVM = this.DataContext as VM.SqareVM;
           
            relativeMousePos = e.GetPosition(this) - new Point();
            MouseMove += OnDragMove;
            LostMouseCapture += OnLostCapture;
            Mouse.Capture(this);

        }

        // клавиша отпущена - завершаем процесс
      public  void OnMouseUp2(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        // потеряли фокус (например, юзер переключился в другое окно) - завершаем тоже
        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);
        }

        void OnDragMove(object sender, MouseEventArgs e)
        {
           // UpdatePosition(e);
            UpdateDraggedSquarePosition(e);
        }

        void FinishDrag(object sender, MouseEventArgs e)
        {
            MouseMove -= OnDragMove;
            LostMouseCapture -= OnLostCapture;
            UpdateDraggedSquarePosition(null);
        }

        // требуем у VM обновить позицию через команду
        void UpdatePosition(MouseEventArgs e)
        {           
            var point = e.GetPosition(container);

            // не забываем проверку на null
            RequestMoveCommand?.Execute(point - relativeMousePos);           
        }

        // это вспомогательная функция, ей место в общей библиотеке
       

        void UpdateDraggedSquarePosition(MouseEventArgs e)
        {
            var dragImageContainer = DraggedImageContainer;
            if (dragImageContainer == null)
                return;
            var needVisible = e != null;
            var wasVisible = dragImageContainer.Visibility == Visibility.Visible;
            // включаем/выключаем видимость перемещаемой картинки
            dragImageContainer.Visibility = needVisible ? Visibility.Visible : Visibility.Collapsed;
            if (!needVisible) // если мы выключились, нам больше нечего делать
                return;

            if (!wasVisible) // а если мы были выключены и включились,
            {                // нам надо привязать изображение себя
                dragImageContainer.Fill = new VisualBrush(this); //перерисоввывывает
                dragImageContainer.SetBinding( // а также ширину/высоту
                    Shape.WidthProperty,
                    new Binding(nameof(ActualWidth)) { Source = this });
                dragImageContainer.SetBinding(
                    Shape.HeightProperty,
                    new Binding(nameof(ActualHeight)) { Source = this });
                // Binding нужен потому, что наш размер может по идее измениться
            }
            // перемещаем картинку на нужную позицию
            var parent = Helpers.Helper.FindParent<Canvas>(dragImageContainer);
            var position = e.GetPosition(parent) - relativeMousePos;
            Canvas.SetLeft(dragImageContainer, position.X);
            Canvas.SetTop(dragImageContainer, position.Y);
        }
               

        /* protected override void OnContentChanged(object oldContent, object newContent)
         {
             base.OnContentChanged(oldContent, newContent);
             StackPanel panel = new StackPanel();
             Button button = new Button();
             button.Content = "Test";
             panel.Children.Add(button);


             ((IAddChild)newContent).AddChild(panel);
         }*/
    }
}
