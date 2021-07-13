using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Sales.Domain.Validators;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Voucher : Entity, IAggregateRoot
    {
        #region Properties

        public string Code { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public bool Active { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }

        //EF Properties
        public Order Order { get; private set; }

        #endregion

        #region Constructors

        protected Voucher()
        {
        }

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

        #endregion

        #region Methods

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
        public void ActivateVoucher() => Active = true;
        public void DeactivateVoucher() => Active = false;

        public bool Validate()
        {
            var validator = new VoucherValidator();
            var validation = validator.Validate(this);

            if (validation.Errors.Count > 0)
                throw new DomainException(validation.Errors[0].ErrorMessage);

            return true;
        }

        #endregion
    }
}
