﻿using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class TransportCompanyRepository : BaseRepository<TransportCompany>, ITransportCompanyRepository
    {
        private readonly SalesContext _context;

        public TransportCompanyRepository(SalesContext context)
            : base(context)
        {
            _context = context;
        }

        public override IUnitOfWork UnitOfWork
        {
            get { return UoW; }
        }

        private IUnitOfWork UoW => _context;
    }
}
