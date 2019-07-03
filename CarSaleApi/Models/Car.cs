﻿using System;

namespace CarSaleApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime MadeDateTime { get; set; }
    }
}