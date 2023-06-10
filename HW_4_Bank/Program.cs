namespace HW_4_Bank
{
    internal class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            Client client1 = new Client("Jack", "Black");
            Client client2 = new Client("Moulin", "Rouge");
            Client client3 = new Client("Poor", "Person");

            bank.AddClient(client1);                                                    // додаємо клієнтів
            bank.AddClient(client1);                                                    // двічі той самий клієнт не додається
            bank.AddClient(client2);
            bank.AddClient(client3);

            Console.WriteLine(new string('-', 100));
            
            bank.AddAccount(client1);                                                   // створення рахунків
            bank.AddAccount(client1);
            bank.AddAccount(client2);

            Console.WriteLine(new string('-', 100));

            bank.Depositing(client1.Accounts[0], 4568.45m);                             // поповнення 1-го рахунка
            bank.Withdrawing(client1.Accounts[0], 3568.22m);                            // знімаємо, все ок
            bank.Withdrawing(client1.Accounts[0], 3568.22m);                            // намагаємося зняти, але ні
            bank.ChangeRate(client1.Accounts[0], 0.05m);                                // зміна ставки
            bank.Transfer(client1.Accounts[0], client1.Accounts[1], 456.87m);           // переказ на 2-й рахунок, все ок
            bank.Transfer(client1.Accounts[0], client1.Accounts[1], 5456.87m);          // переказ, сума перевищена
            Console.WriteLine(new string('-', 100));

            bank.Withdrawing(client2.Accounts[0], 34980.55m);                           // спроба зняття при 0 балансі
            bank.Depositing(client2.Accounts[0], 325.99m);                              // закидаємо трохи грошей
            bank.Withdrawing(client2.Accounts[0], 3534.65m);                            // знов невдала спроба зняття
            bank.ChangeRate(client2.Accounts[0], 0.04m);                                // зміна ставки
            bank.Transfer(client1.Accounts[0], client2.Accounts[0], 226.87m);           // переказ від одного клієнта до іншого
            Console.WriteLine(new string('-', 100));

            client1.GetBalance();                                                       // баланси та транзакції по клієнтах
            Console.WriteLine(new string('-', 100));

            client2.GetBalance();
            Console.WriteLine(new string('-', 100));

            client3.GetBalance();
            Console.WriteLine(new string('-', 100));

            bank.GetAccountsList();                                                     // списки клієнтів та рахунків
            bank.GetClientList();

            Console.WriteLine(  );
        }
    }
}