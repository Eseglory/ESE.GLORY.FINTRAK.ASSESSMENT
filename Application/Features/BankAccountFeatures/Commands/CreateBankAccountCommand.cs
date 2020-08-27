using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BankAccountFeatures.Commands
{
    public class CreateBankAccountCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal InitialAmount { get; set; }
        public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBankAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBankAccountCommand command, CancellationToken cancellationToken)
            {
                var bankaccount = new BankAccount();
                bankaccount.DateCreated = DateTime.Now;
                bankaccount.Name = command.Name;
                bankaccount.InitialAmount = command.InitialAmount;
                bankaccount.Description = command.Description;
                bankaccount.AccountNumber = command.AccountNumber;
                _context.BankAccounts.Add(bankaccount);
                await _context.SaveChangesAsync();
                return bankaccount.Id;
            }
        }
    }
}
