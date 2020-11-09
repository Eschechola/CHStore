using System;
using CHStore.Application.Accounts.Domain.Enums;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.ApplicationServices.DTO
{
    public class CustomerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public CustomerDocumentType DocumentType { get; set; }
    }
}
