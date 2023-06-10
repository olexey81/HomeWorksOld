namespace HW_4_Bank
{
    internal class Money
    {
        private readonly decimal _Money;

        public Money(decimal money) => _Money = money;
        
        public Money AddMoney(Money amount) => new Money(_Money + amount._Money);

        public Money RemoveMoney(Money amount) => new Money(_Money - amount._Money);

        public bool IsMoreOrEqualMoney(Money amount) => _Money >= amount._Money;

        public decimal ShowMoney() => _Money;
    }
}
// -Гроші складаються з гривень та копійок, з ними можна проводити прості арифмети. операції та порівняння. Має бути незмінним.