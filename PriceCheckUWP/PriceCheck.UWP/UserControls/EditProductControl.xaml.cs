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
    public sealed partial class EditProductControl : UserControl
    {
        //public EditProductControl(Product productEntity)
        //{
        //    this.InitializeComponent();
        //    Product = Mapper.Map<ProductModel>(productEntity);
        //    DataContext = Product;
        //}

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //using (var priceChangeContext = new PriceCheckContext())
            //{
            //    var productEntity = Mapper.Map<Product>(Product);
            //    priceChangeContext.Products.Update(productEntity);
            //    await priceChangeContext.SaveChangesAsync();
            //}
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
