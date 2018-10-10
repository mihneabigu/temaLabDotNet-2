using System;

namespace Classes{
    public class Product {

        private readonly int Id;
        private readonly String Name;
        private readonly String Description;
        private readonly DateTime StartDate;
        private readonly DateTime EndDate;
        private readonly int Price;
        private readonly int VAT;

        public Product(int id, String name, String description, DateTime startDate, DateTime endDate, int price, int vat) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Price = price;
            this.VAT = vat;
        }

        public String GetName() {
            return this.Name;
        }

        public bool IsValid() {
            return this.StartDate <= DateTime.Today && DateTime.Today <= this.EndDate;
        }

        public int ComputeVAT() {
            if (this.Price < 0 || this.VAT < 0) {
                throw new ArgumentException("Price or VAT can't be negative values");
            }
            return this.Price + this.VAT * this.Price / 100;
        }
    }
}
