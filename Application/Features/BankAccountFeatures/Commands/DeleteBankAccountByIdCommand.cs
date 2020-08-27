using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BankAccountFeatures.Commands
{
    public class DeleteBankAccountByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBankAccountByIdCommandHandler : IRequestHandler<DeleteBankAccountByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteBankAccountByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBankAccountByIdCommand command, CancellationToken cancellationToken)
            {
                var bankaccount = await _context.BankAccounts.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (bankaccount == null) return default;
                _context.BankAccounts.Remove(bankaccount);
                await _context.SaveChangesAsync();
                return bankaccount.Id;
            }
        }
    }
}
