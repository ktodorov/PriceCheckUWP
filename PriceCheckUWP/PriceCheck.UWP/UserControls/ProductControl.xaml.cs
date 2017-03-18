using PriceCheck.Core.Entities;
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

        public ProductControl(Product product)
        {
            this.InitializeComponent();

            ProductWebsite = product.Url;
        }

        public string ProductName { get; set; }

        public string ProductWebsite { get; set; }

        public string ProductDescription { get; set; }
    }
}
