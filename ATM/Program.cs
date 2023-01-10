public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    { return cardNum; }

    public int getPin()
    { return pin; }

    public string getFirstName()
    { return firstName; }

    public string getLastName()
    { return lastName; }

    public double getBalance()
    { return balance; }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        void Deposit(CardHolder currentUser)
        {
            double deposit = 0.0D;
            Console.WriteLine("How much would you like to deposit?");
            try
            {
                deposit = Convert.ToDouble(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.getBalance());
                Console.WriteLine();
                Console.WriteLine("Thank you for your deposit. Your new balance is: {0}", currentUser.getBalance().ToString("C3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Processing Your Request: {0}", ex.Message);
            }
        }

        void WithDraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            try
            {
                double withdrawal = Convert.ToDouble(Console.ReadLine());
                if (withdrawal > 0 && currentUser.getBalance() > withdrawal)
                {
                    double newBalance = currentUser.getBalance() - withdrawal;
                    currentUser.setBalance(newBalance);
                    Console.WriteLine();
                    Console.WriteLine("You are good to go! Thank You!");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Processing Your Request: {0}", ex.Message);
            }
        }

        void Balance(CardHolder currentUser)
        {
            Console.WriteLine("Current Balance: {0}", currentUser.getBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("922-6439-85", 5961, "Eddy", "Murray", 372.67d));
        cardHolders.Add(new CardHolder("139-2794-37", 6606, "April", "Adams", 449.33d));
        cardHolders.Add(new CardHolder("181-3315-59", 9781, "Derek", "Lloyd", 667.86d));
        cardHolders.Add(new CardHolder("421-2232-65", 1466, "Bruce", "Nelson", 82.52d));
        cardHolders.Add(new CardHolder("259-5875-88", 2442, "Kimberly", "Cameron", 4402.4d));
        cardHolders.Add(new CardHolder("454-1734-52", 5615, "Elia", "Spencer", 36532.0d));

        Console.WriteLine("-----Welcome to Simple ATM-----");
        Console.WriteLine();
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(u => u.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not Recognized. Please try again...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Processing Your Request: {0}", ex.Message);
            }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.pin == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect PIN. Please try again...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Processing Your Request: {0}", ex.Message);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Welcome " + currentUser.getFirstName()+"...");
        Console.WriteLine();
        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Processing Your Request: {0}", ex.Message);
            }
            switch (option)
            {
                case 1:
                    Deposit(currentUser);
                    break;

                case 2:
                    WithDraw(currentUser);
                    break;

                case 3:
                    Balance(currentUser);
                    break;
                
                default:
                    if(option != 4)
                    {
                        Console.WriteLine("No Options Found");
                    }
                    break;
            }
        } while (option != 4);
        Console.WriteLine();
        Console.WriteLine("Thank You! Have a Nice Day!");
    }
}