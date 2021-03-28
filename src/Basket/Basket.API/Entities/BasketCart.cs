﻿using System.Collections.Generic;

namespace Basket.Api.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> items { get; set; } = new List<BasketCartItem>();

        public BasketCart() { } 
        public BasketCart(string userName) 
        {
            UserName = userName;
        }

        // calculate total price of basket card
        public decimal TotalPrice { 
            get 
            {
                decimal totalPrice = 0;
                foreach (var item in items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            } 
        }
    }
}
