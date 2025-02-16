﻿namespace TareaGrupal.Models
{
    public class Product
    {
        public int id { get; set;}
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock  { get; set; }
        public int supplier_id { get; set; }
    }
}
