using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BankAccountFeatures.Commands
{
    public class UpdateBankAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal InitialAmount { get; set; }
        public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateBankAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBankAccountCommand command, CancellationToken cancellationToken)
            {
                var bankaccount = _context.BankAccounts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (bankaccount == null)
                {
                    return default;
                }
                else
                {
                    bankaccount.AccountNumber = command.AccountNumber;
                    bankaccount.Name = command.Name;
                    bankaccount.InitialAmount = command.InitialAmount;
                    bankaccount.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return bankaccount.Id;
                }
            }
        }
    }
}
