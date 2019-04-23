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

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registratios.xaml
    /// </summary>
    public partial class Registratios : Window
    {
        public Data.VMDataName.DataUser DataUsers { get; set; }

        public Registratios(Data.VMDataName.DataUser dataUser)
        {
            InitializeComponent();
            DataUsers = dataUser;
            DataContext = DataUsers;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
