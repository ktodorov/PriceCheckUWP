using PriceCheck.Business.Interfaces.Command;
using PriceCheck.Business.Services.Command;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PriceCheck.UWP.UserControls
{
    public sealed partial class AddProductControl : UserControl, IOperationControl
    {
        IProductCommandService productCommandService;

        public event EventHandler OperationCompleted;
        public event EventHandler CanceledOperation;

        ProductModel Product;

        public AddProductControl()
        {
            this.InitializeComponent();
            productCommandService = new ProductCommandService();
            Product = new ProductModel();
            DataContext = Product;
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            await productCommandService.AddProductAsync(Product);

            OperationCompleted?.Invoke(this, new EventArgs());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            CanceledOperation?.Invoke(this, new EventArgs());
        }
    }
}
