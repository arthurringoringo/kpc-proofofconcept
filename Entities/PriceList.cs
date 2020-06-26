using System;
using System.ComponentModel.DataAnnotations;

namespace apitest.Entities
{

    public class StoreA {

        [Key]
        [Required]
        public int Barcode { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
    }

    public class StoreB
    {

        [Key]       
        [Required]
        public int Barcode { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
    }
}
