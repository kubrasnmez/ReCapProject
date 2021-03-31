using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concreate
{
    public class Card : IEntity
    {
        public int CardId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv  { get; set; }
        public int ExpirationDate { get; set; }
        public decimal MoneyInTheCard { get; set; }
    }
}
