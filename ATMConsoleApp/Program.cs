using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    public string getNum() => cardNum;
    public string getFirstName() => firstName;
    public string getLastName() => lastName;
    public int getPin() => pin;
    public double getBalance() => balance;

    public void setNum(string newCardNum) => cardNum = newCardNum;
    public void setFirstName(string newFirstName) => firstName = newFirstName;
    public void setLastName(string newLastName) => lastName = newLastName;
    public void setPin(int newSetPin) => pin = newSetPin;
    public void setBalance(double newGetBalance) => balance = newGetBalance;

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose an option...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Get Balance");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?:");
            double withdrawAmount = Double.Parse(Console.ReadLine());
            // check if user has enough money
            if (currentUser.getBalance() < withdrawAmount)
            {
                Console.WriteLine("Insufficent funds...");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawAmount);
                Console.WriteLine("You have withdrawn: " + withdrawAmount);
                Console.WriteLine("\n");
                Console.WriteLine("Your new balance is :" + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("current balance is: " + currentUser.getBalance());
        }

        

        List < cardHolder > cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("3224324", 4321, "Ake", "Nathan", 150.24));
        cardHolders.Add(new cardHolder("2343242", 1234, "De Bruyne", "Kevin", 122.12));
        cardHolders.Add(new cardHolder("82736531", 7226, "Jordan", "Mike", 12312.12));
        cardHolders.Add(new cardHolder("12331133", 1441, "Turner", "Tim", 122.12));
        cardHolders.Add(new cardHolder("11209832", 9271, "Marley", "Bob", 17121.42));
        cardHolders.Add(new cardHolder("11224111", 8710, "Green", "John", 21321.23));

        void addNewcardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            cardHolders.Add(new cardHolder(cardNum, pin, firstName, lastName, balance));
        }

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Do you have an account?");
        string loginOptions = Console.ReadLine();
        String debitCardNum = "";
        cardHolder currentUser;
        int option = 0;

        if (loginOptions == "no")
        { 
        
                Console.WriteLine("Enter a new card number: ");
                 string newCardNumber = Console.ReadLine();
                Console.WriteLine("Enter a new pin number: ");
                int newPin = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your last name: ");
                string newLastName = Console.ReadLine();
                Console.WriteLine("Enter your first name: ");
                string newFirstName = Console.ReadLine();
                Console.WriteLine("Make an initial deposit: ");
                double initialBalance = Double.Parse(Console.ReadLine());
                addNewcardHolder(newCardNumber, newPin, newFirstName, newLastName, initialBalance);
                Console.WriteLine("Your account has now been created");
                printOptions();
            } 
        

        if (loginOptions == "yes")
        {
            printOptions();
            try
            {
                Console.WriteLine("Please insert your debit card: ");

                debitCardNum = Console.ReadLine();
                // check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");

            }
        }

          while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) break;
                Console.WriteLine("Card not recognized. Please try again");
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");

            }
        }


   
    

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine()) ;
                // check against our db
                if (currentUser.getPin() == userPin) break;
                Console.WriteLine("Wrong Pin. Please try again");
            }
            catch
            {
                Console.WriteLine("Wrong Pin. Please try again");

            }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName());

 
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {  }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { balance(currentUser); }
            else if (option == 3) { withdraw(currentUser); }
            else if (option == 4) break;
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }

}

