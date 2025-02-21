namespace InvestmentPlatform.Investments
{
    public class Investment
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Investment: {Name}, Price: ${Price}");
        }
        public void BuyInvestment(int quantity)
        {
            decimal totalCost =  ((int)Price) * quantity;
            Console.WriteLine($"You bought {quantity} of {Name} for a total of ${totalCost}");
        }
    }

    public class Stock : Investment
    {
        public string TickerSymbol { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Stock: {Name}, Ticker: {TickerSymbol}, Price: ${Price}");
        }
    }


    public class MutualFund : Investment
    {
        public string FundManager { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Mutual Fund: {Name}, Managed by: {FundManager}, Price: ${Price}");
        }
    }
}
