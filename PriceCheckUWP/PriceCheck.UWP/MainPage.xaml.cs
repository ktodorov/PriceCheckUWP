using PriceCheck.Business.Interfaces;
using PriceCheck.Business.Interfaces.Query;
using PriceCheck.Business.Services;
using PriceCheck.Business.Services.Query;
using PriceCheck.UWP.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PriceCheck.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IProductQueryService productService;

        public MainPage()
        {
            this.InitializeComponent();

            productService = new ProductQueryService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshProductsAsync();
        }

        private async Task RefreshProductsAsync()
        {
            spProducts.Children.Clear();

            var currentProducts = await productService.GetAllProductsAsync();
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
    }
}
