using LAP.ViewModel;
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

namespace LAP.View
{
    /// <summary>
    /// Interaction logic for Tablecontrol.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {
        public TableViewModel ViewModel { get; set; }

        public TableControl()
        {
            InitializeComponent();

            ViewModel = new TableViewModel();
            DataContext = ViewModel;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.GetMainList();
        }
    }
}
