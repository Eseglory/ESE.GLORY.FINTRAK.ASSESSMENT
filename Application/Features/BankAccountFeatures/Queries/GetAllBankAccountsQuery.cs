using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BankAccountFeatures.Queries
{
    public class GetAllBankAccountsQuery : IRequest<IEnumerable<BankAccount>>
    {

        public class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, IEnumerable<BankAccount>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBankAccountsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<BankAccount>> Handle(GetAllBankAccountsQuery query, CancellationToken cancellationToken)
            {
                var bankaccountList = await _context.BankAccounts.ToListAsync();
                if (bankaccountList == null)
                {
                    return null;
                }
                return bankaccountList.AsReadOnly();
            }
        }
    }
}
