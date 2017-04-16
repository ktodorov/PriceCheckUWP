using PriceCheck.Business.Interfaces.Query;
using PriceCheck.Business.Services.Query;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PriceCheck.UWP.UserControls
{
    public sealed partial class ProductsList : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IProductQueryService productService;

        private string _searchText;
        public string searchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("searchText");
            }
        }

        public ProductsList()
        {
            searchText = string.Empty;
            DataContext = this;

            this.InitializeComponent();

            productService = new ProductQueryService();
        }

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public async Task RefreshProductsAsync()
        {
            spProducts.Children.Clear();

            var currentProducts = await productService.GetAllProductsAsync(searchText);
            foreach (var product in currentProducts)
            {
                var productControl = new ProductControl(product);
                spProducts.Children.Add(productControl);
            }

            tbSummary.Text = $"All products: {currentProducts.Count}";
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            var addProductControl = new EditProductControl();
            addProductControl.OperationCompleted += AddProductControl_OperationCompleted;
            addProductControl.CanceledOperation += AddProductControl_CanceledOperation;
            dialogPopup.Child = addProductControl;
            dialogPopup.IsOpen = true;
        }

        private void AddProductControl_CanceledOperation(object sender, EventArgs e)
        {
            HideDialog();
        }

        private async void AddProductControl_OperationCompleted(object sender, EventArgs e)
        {
            HideDialog();
            await RefreshProductsAsync();
        }

        private void HideDialog()
        {
            dialogPopup.Child = null;
            dialogPopup.IsOpen = false;
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            await RefreshProductsAsync();
        }
    }
}
