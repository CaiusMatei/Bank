
namespace Banken
{
    internal class Program
    {
       
        public class CardHolder {

            // skapar strings, int och double för användernamnet, pinkoden och saldon//

            int pinCode;
            String firstName;
            String lastName;
            double balance;
            String accountType;
            double amount;
          

            public CardHolder( int pinCode, string firstName, string lastName, double balance, string accountType,double amount)
            {
                
                this.balance = balance;
                this.pinCode = pinCode;
                this.firstName = firstName;
                this.lastName = lastName;
                this.accountType = accountType;
                this.amount = amount;
            }

            public double getAmount()
            {
                return amount;
            }
          
            public int getPinCode()
            {
                return pinCode;
            }

            public String getFirstName()
            {
                return firstName;
            }
            public String getLastName()
            {
                return lastName;
            }
            public double getBalance() { 
                
                return balance; 
            
            }
            public String getAccountType()
            {
                return accountType;
            }
            
            public void setAmount(double newAmount)
            {
                amount = newAmount;
            }
            public void setaccountType(String newaccountType)
            {
                accountType = newaccountType;
            }
            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }
            public void setpinCode(int newpinCode)
            {
                pinCode = newpinCode;
            }
            public void setfirstName(String newfirstName)
            {
                firstName = newfirstName;
            }
            public void setlastName(String newlastName)
            {
                lastName = newlastName;
            }

            public void Transfer(CardHolder receiver, double amount)
            {
                if (balance < amount)
                {
                    Console.WriteLine("Not enough funds to complete the transfer.");
                    return;
                }

                balance -= amount;
                receiver.balance += amount;

                Console.WriteLine("Transfer successful!");
                Console.WriteLine("");
            }

            static void Main(string[] args)
            {
                // nedåt skapas en meny så att man väljer olika alternativ efter man har loggat in// 

                void printOptions()
                {
                    Console.WriteLine("Välj ett alternativ");
                    Console.WriteLine("1. Lägg till pengar  ");
                    Console.WriteLine("2. Ta ut pengar  ");
                    Console.WriteLine("3. Överföring mellan konton");
                    Console.WriteLine("4. Se Konto och Saldo ");
                    Console.WriteLine("5. Logga ut");

                }

                // Funktionen gör så att man kan lägga pengar på kontot//

                

                void deposit(CardHolder currentUser)
                {
                    Console.WriteLine("Hur mycket pengar vill du lägga till? ");
                    double deposit = Double.Parse(Console.ReadLine());
                    currentUser.setBalance(currentUser.getBalance() + deposit );
                    Console.WriteLine("Din nya saldo är: " + currentUser.getBalance());
                }



                // funktionen gör så att man kan ta ut pengar från kontot//

                void withdraw(CardHolder currentUser)
                {
                    Console.WriteLine("Hur mycket pengar vill du ta ut: ");
                    double withdraw = Double.Parse(Console.ReadLine());
                    if (currentUser.getBalance() < withdraw)
                    {
                        Console.WriteLine("Inte tillräckligt med pengar :(");

                    }
                    else
                    {
                        currentUser.setBalance(currentUser.getBalance() - withdraw);
                        Console.WriteLine("Du har tagit ut pengar! Tack så mycket");
                    }
                }

                // Visar vad saldo är på kontot//

                void balance(CardHolder currentUser)
                {
                    Console.WriteLine("PersonKonto --> " + " Giltig saldo: " + currentUser.getBalance());
                }

                // Skapar array med namnet och pin koden//

                string[] Names = { "Caius", "Mohib", "Messi", "Ronaldo", "FinalBoss" };
                int[] pinCodes = { 1234, 1111, 2222, 4545, 4209 };

                // skapar en lista med personer, deras konto och hur mycket pengar var och en har//

              List<CardHolder> cardHolders= new List<CardHolder>();

                cardHolders.Add(new CardHolder( 1234,"Caius","Matei",5080,"PersonKonto",0));
                cardHolders.Add(new CardHolder( 1111, "Mohib", "Javed", 5001, "PersonKonto",0));
                cardHolders.Add(new CardHolder( 2222, "Messi", "Messi", 8080, "PersonKonto", 0));
                cardHolders.Add(new CardHolder( 4545, "Ronaldo", "Cristiano", 3080, "PersonKonto", 0));
                cardHolders.Add(new CardHolder( 4209, "FinalBoss", "Boss", 1080, "PersonKonto", 0));




                Console.WriteLine("Välkomen till ATM ");

                Console.WriteLine("Ange ditt namn och pin-koden");
                String firstName = "";
                
                CardHolder currentUser;

                // kollar om namnet finns inne i listan som skapades övanför, om det inte finns så skrivs det att det existerar inte//


             

                while (true)
                {
                    try
                    {
                        firstName= Console.ReadLine();
                        currentUser = cardHolders.FirstOrDefault(a => a.firstName== firstName);
                        if (currentUser != null) { break; }
                        else { Console.WriteLine("Namnet existerar inte, försök igen!! "); }
                    }
                    catch { Console.WriteLine("Namnet existerar inte, försök igen!! "); }

                }
                Console.WriteLine("Ange ditt pin kod !! ");
                int userPin = 0;

                // samma sak gäller för pin koden//


                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                       
                        if (currentUser.getPinCode() == userPin) { break; }
                        else { Console.WriteLine("Fel pin kod, Försök igen!"); }
                    }
                    catch { Console.WriteLine("Fel pin kod, Försök igen!"); }

                }

                // om godkänd och användaren kommer in så får hen en meny med olika alternativ//

                Console.WriteLine("Välkomen " + currentUser.getFirstName());
                Console.WriteLine("");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1)
                    {
                        deposit(currentUser);
                    }
                    else if (option == 2) { withdraw(currentUser); }
                    else if (option == 4) { balance(currentUser); }
                    else if (option == 3)
                    {
                        foreach (var item in Names)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Ange mottagarens namn:");
                        string receiverName = Console.ReadLine();
                        CardHolder receiver = cardHolders.FirstOrDefault(a => a.firstName == receiverName);

                        if (receiver == null)
                        {
                            Console.WriteLine("Mottagaren existerar inte.");
                        }
                        else
                        {
                            Console.WriteLine("Ange beloppet att överföra:");
                            double transferAmount = double.Parse(Console.ReadLine());
                            currentUser.Transfer(receiver, transferAmount);
                        }
                    }


                    else if (option == 5) { break; }
                    else { option = 0; }
                }
                while (option != 5);
                Console.WriteLine("Tack så mycket, ha en trevlig dag");
                
                
            }
        }
    }
}