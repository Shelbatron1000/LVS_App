using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Prototype.GroupingTest
{
    class MainViewModel
    {

        private Product _oldProduct;

        public ObservableCollection<Product> Products { get; set; } 

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Title = "Surface Laptop",
                    IsVisible = false,
                },
                new Product
                {
                    Title = "Surface Book",
                    IsVisible = false,
                },
                new Product
                {
                    Title = "X1 Carbon",
                    IsVisible = false,
                }
            };
        }

        internal void HideOrShowProduct(Product product)
        {
            if (_oldProduct == product)
            {
                // click twice on the same item will hide it
                product.IsVisible = !product.IsVisible;
                UpdateProducts(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    // hide previous selected item
                    _oldProduct.IsVisible = false;
                    UpdateProducts(_oldProduct);
                }
                // show selected item
                product.IsVisible = true;
                UpdateProducts(product);
            }

            _oldProduct = product;
        }

        private void UpdateProducts(Product product)
        {
            var index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(index, product);
        }
    }
}
