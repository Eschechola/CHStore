using System;

namespace CHStore.Database.Entities
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public bool Active { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }

        public Order Order { get; private set; }

        public Voucher(
            string code,
            decimal discountPercentage,
            bool active,
            DateTime initialDate,
            DateTime finalDate)
        {
            Code = code.ToUpper();
            DiscountPercentage = discountPercentage;
            Active = active;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }
    }
}
