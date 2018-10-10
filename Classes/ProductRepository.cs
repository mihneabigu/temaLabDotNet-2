using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes {

    public class ProductRepository {

        private readonly List<Product> productList;

        public ProductRepository(params Product[] products) {
            if (products.Length < 3) {
                throw new ArgumentException("You have to pass at least 3 products as parameters");
            }
            productList = new List<Product>();
            foreach (Product product in products) {
                productList.Add(product);
            }
        }

        public Product GetProductByName(String productName) {
            Product product = this.productList.Find(x => x.GetName().Equals(productName));
            if (product == null) {
                throw new ArgumentException("No product with the name " + productName);
            }
            return product;
        }

        public List<Product> FindAllProducts() {
            return this.productList;
        }

        public void AddProduct(Product product) {
            if (product == null) {
                throw new ArgumentException("Can't pass a null argument");
            }
            this.productList.Add(product);
        }

        public Product GetProductByPosition(int index) {
            if (index < 0 || index >= productList.Count) {
                throw new ArgumentException("Index is either lower than 0 or bigger than List.Count");
            }
            return productList.ElementAt(index);
        }

        public void RemoveProductByName(String productName) {
            Product product = GetProductByName(productName);
            productList.Remove(product);
        }
    }
}