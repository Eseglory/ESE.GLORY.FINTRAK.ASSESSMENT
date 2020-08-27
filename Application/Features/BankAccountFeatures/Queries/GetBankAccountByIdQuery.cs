using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BankAccountFeatures.Queries
{
    public class GetBankAccountByIdQuery : IRequest<BankAccount>
    {
        public int Id { get; set; }
        public class GetBankAccountByIdQueryHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccount>
        {
            private readonly IApplicationDbContext _context;
            public GetBankAccountByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<BankAccount> Handle(GetBankAccountByIdQuery query, CancellationToken cancellationToken)
            {
                var bankaccount = _context.BankAccounts.Where(a => a.Id == query.Id).FirstOrDefault();
                if (bankaccount == null) return null;
                return bankaccount;
            }
        }
    }
}
