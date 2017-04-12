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
        public ProductControl()
        {
            this.InitializeComponent();
        }

        //public ProductControl(Product product)
        //{
        //    this.InitializeComponent();
        //    AttachedProduct = product;
        //    mainGrid.DataContext = AttachedProduct;
        //}

        private async void deleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            //using (var pcContext = new PriceCheckContext())
            //{
            //    pcContext.Products.Remove(AttachedProduct);
            //    await pcContext.SaveChangesAsync();
            //}

            ((Panel)this.Parent).Children.Remove(this);
        }

        private void editProductButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
