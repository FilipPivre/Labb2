﻿namespace Labb2
{
    internal interface IKitchenAppliance
    {
         public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        public int Id { get; set; }
    }
}
