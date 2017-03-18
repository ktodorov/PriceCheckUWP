using PriceCheck.DAL.Context;
using PriceCheck.DAL.Entities;
using PriceCheck.UWP.UserControls;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PriceCheck.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            spProducts.Children.Clear();

            using (var db = new PriceCheckContext())
            {
                var currentProducts = db.Products.ToList();
                foreach (var product in currentProducts)
                {
                    var productControl = new ProductControl(product);
                    spProducts.Children.Add(productControl);
                }

                tbSummary.Text = $"All products: {currentProducts.Count}";
            }
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            var addProductControl = new AddProductControl();
            addProductControl.OperationCompleted += AddProductControl_OperationCompleted;
            dialogPopup.Child = addProductControl;
            dialogPopup.IsOpen = true;
        }

        private void AddProductControl_OperationCompleted(object sender, EventArgs e)
        {
            dialogPopup.Child = null;
            dialogPopup.IsOpen = false;
            LoadProducts();
        }
    }
}
