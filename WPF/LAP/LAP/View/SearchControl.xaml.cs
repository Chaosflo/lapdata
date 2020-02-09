using LAP.ViewModel;
using Model;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace LAP.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchViewModel ViewModel { get; set; }

        public SearchControl()
        {
            InitializeComponent();

            ViewModel = new SearchViewModel();
            DataContext = ViewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView cvMainModel = CollectionViewSource.GetDefaultView(DataGrid.ItemsSource);

            cvMainModel.Filter = item =>
            {
                var m = item as Car;
                return m != null && m.CarId.ToString().Contains(SearchTextBox.Text);
            };


        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.GetMainList();
        }
    }
}
