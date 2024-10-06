namespace WSB.Biblioteka.Libraries
{
    public interface IDelayFineCalculator
    {
        public ValueTask<Decimal> CalculateFineForDelayAsync(Guid bookId, Guid userId);
    }
}
