using System.Transactions;

namespace AirBnbClone.Models.Inheritance
{
    public abstract class Translatable
    {
        public Guid Id { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
