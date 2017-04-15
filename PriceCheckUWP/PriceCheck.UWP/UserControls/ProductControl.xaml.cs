using PriceCheck.Business.Interfaces.Command;
using PriceCheck.Business.Interfaces.Query;
using PriceCheck.Business.Services.Command;
using PriceCheck.Business.Services.Query;
using PriceCheck.Domain.Models;
using PriceCheck.UWP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PriceCheck.UWP.UserControls
{
    public sealed partial class ProductControl : UserControl
    {
        IProductCommandService productCommandService;
        IProductQueryService productQueryService;

        ProductModel AttachedProduct;

        public ProductControl()
        {
            this.InitializeComponent();
            productCommandService = new ProductCommandService();
            productQueryService = new ProductQueryService();
        }

        public ProductControl(ProductModel product)
        {
            this.InitializeComponent();
            productCommandService = new ProductCommandService();
            productQueryService = new ProductQueryService();
            AttachedProduct = product;
            mainGrid.DataContext = AttachedProduct;
        }

        private async void deleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            await productCommandService.DeleteProductAsync(AttachedProduct);
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void editProductButton_Click(object sender, RoutedEventArgs e)
        {
            var editProductControl = new EditProductControl(AttachedProduct);
            editProductControl.OperationCompleted += EditProductControl_OperationCompleted;
            editProductControl.CanceledOperation += EditProductControl_CanceledOperation; ;
            spEditView.Children.Add(editProductControl);
            spEditView.Visibility = Visibility.Visible;
        }

        private void EditProductControl_CanceledOperation(object sender, EventArgs e)
        {
            HideEditView();
        }

        private async void EditProductControl_OperationCompleted(object sender, EventArgs e)
        {
            var product = await productQueryService.GetProductById(AttachedProduct.Id);
            AttachedProduct = product;
            mainGrid.DataContext = AttachedProduct;
            HideEditView();
        }

        private void HideEditView()
        {
            spEditView.Children.Clear();
            spEditView.Visibility = Visibility.Collapsed;
        }
    }
}
