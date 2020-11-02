﻿using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Coupon : Entity
    {
        public string Code { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public bool Active { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }

        public Order Order { get; private set; }

        public Coupon(
            string code,
            decimal discountPercentage,
            bool active,
            DateTime initialDate,
            DateTime finalDate
        )
        {
            Code = code.ToUpper();
            DiscountPercentage = discountPercentage;
            Active = active;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }

        public void ChangeCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new DomainException("O Código do Cupom não pode ser vazio.");

            Code = code;
        }

        public void ChangeDiscountPercentage(decimal discountPercentage)
        {
            if (discountPercentage <= 0)
                throw new DomainException("A Porcentagem de Desconto não pode ser menor ou igual a 0.");

            DiscountPercentage = discountPercentage;
        }

        public void ChangeInitialDate(DateTime initialDate) => InitialDate = initialDate;
        public void ChangeFinalDate(DateTime finalDate) => FinalDate = finalDate;
        public void ActivateCoupon() => Active = true;
        public void DeactivateCoupon() => Active = false;
    }
}