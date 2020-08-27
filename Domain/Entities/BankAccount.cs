using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
public class BankAccount : BaseEntity
{
    public string DepositorId { get; set; }
    public string Name { get; set; }
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public decimal InitialAmount { get; set; }
}
}
