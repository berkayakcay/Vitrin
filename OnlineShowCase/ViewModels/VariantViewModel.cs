using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShowCase.Models;

namespace OnlineShowCase.ViewModels
{
    public partial class VariantViewModel
    {
        public VariantViewModel()
        {
            this.ItemVariants = new List<ItemVariant>();
            this.Barcodes = new List<Barcode>();

        }
        public Item Item { get; set; }
        public List<ItemVariant> ItemVariants { get; set; }
        public List<Barcode> Barcodes { get; set; }
        public List<Price> Prices { get; set; }
    }
}
