using IKM1.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace IKM1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static DataGrid AllPropertiesView;
        public static DataGrid AllBuyersView;
        public static DataGrid AllRealtorsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllPropertiesView = ViewAllProperties;
            AllBuyersView = ViewAllBuyers;
            AllRealtorsView = ViewAllRealtors;
        }

        private void ViewAllProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}