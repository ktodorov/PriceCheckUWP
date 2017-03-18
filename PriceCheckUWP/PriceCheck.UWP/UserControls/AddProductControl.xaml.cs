using PriceCheck.DAL.Context;
using PriceCheck.DAL.Entities;
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
    public sealed partial class AddProductControl : UserControl
    {
        public event EventHandler OperationCompleted;

        public AddProductControl()
        {
            this.InitializeComponent();
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product();
            newProduct.Name = tbProductName.Text;
            newProduct.Url = tbProductUrl.Text;
            newProduct.Description = tbProductDescription.Text;

            using (var priceCheckContext = new PriceCheckContext())
            {
                priceCheckContext.Products.Add(newProduct);
                await priceCheckContext.SaveChangesAsync();
            }

            OperationCompleted?.Invoke(this, new EventArgs());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            OperationCompleted?.Invoke(this, new EventArgs());
        }
    }
}
