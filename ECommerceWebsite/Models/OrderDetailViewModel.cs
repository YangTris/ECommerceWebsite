﻿using Shared;

namespace ECommerceWebsite.Models
{
    public class OrderDetailViewModel : ViewModelBase
    {
        /*public string orderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string userId { get; set; }
        public string paymentId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public decimal total { get; set; }
        public List<CartItemDTO> items { get; set; }*/
        public List<OrderViewModel> orders = new();
    }
}
