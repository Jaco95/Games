using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace _1._1._2
{
    class Program
    {
        static double meAttack = 0;
        static double mehealth = 0;
        static bool isDaytime = true;
        static int secondsElapsed = 0;
        static double AStrong = 0;
        static double AHealth = 0;
        static int secondsInDay = 200;
        static int secondsInNight = 120;
        static bool mineOnceaday = true;
        static bool Sleeping = false;
        static bool returns = false;
        static Dictionary<string, int> itemAmounts = new Dictionary<string, int>();
        static List<string> inventory = new List<string>();
        static Double money = 0.0;
        static bool Exsist = true;
        static int monsterbuff = 0;
        static bool shockers = false;
        static bool secondStory = false;
        static bool healthincrease = false;
        static bool retruns2 = false;
        static string Monsterm = "";
        static bool playonce = true;
        static bool pieeater = true;
        static bool wego = false;
        static bool retruns3 = false;
        static bool retruns4 = false;
        static double howmanygone = 0;
        static bool shopkeeper = false;
        static bool ihatethis = false;




        static void Main(string[] args)
        {



            isDaytime = true;
            Timer timer = new Timer(UpdateTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            List<string> miningChoices = new List<string> { "Ruby", "Opal", "Monster" };
            int maxTries = 6;
            Random random = new Random();
            string placetogo = "m"; // Starting location: Mine
            double moneyValue = 0.0;
            bool FirsttimeinHouse = true;

            int rooms = 0;
            int kitchen = 0;
            int garden = 0;
            int livingRooms = 0;
            int roomsCost = 4;
            int currentTries = 0;
            int SecondStory = 0;
            bool foundOpal = false;
            bool livingrum = false;
            bool foundRuby = false;

            bool secretHouse = true;
            bool IntroGetroom = false;

            List<string> weaponNames = new List<string>
            {

                "Iron Sword",
                "Bow",
                "Shocker",
            };



            if (File.Exists("game_state.txt"))
            {
                string[] lines = File.ReadAllLines("game_state.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0];
                        int value = int.Parse(parts[1]);
                        switch (key)
                        {
                            case "Money":
                                money = value;
                                break;
                            case "MoneyValue":
                                moneyValue = value;
                                break;
                            case "Kitchen":
                                kitchen = value;
                                break;
                            case "Rooms":
                                rooms = value; // Update rooms only if it's found in the file
                                break;
                            case "livingRooms":
                                livingRooms = value;
                                break;
                            case "Second Story":
                                break;
                            case "garden":
                                garden = value;
                                break;

                            default:
                                itemAmounts[key] = value;
                                break;
                        }
                    }
                }
            }


            Console.WriteLine("In the heart of a dense forest lay an abandoned village, forgotten by time. Among the desolate ruins stood a solitary figure, Mr.Henderson, the village's last caretaker. He had been the guardian of this secluded haven for as long as he could remember.");
            Thread.Sleep(200);
            Console.WriteLine("One morning, as the sun's first rays filtered through the canopy, he noticed a stranger stirring amidst the overgrown grass. Curiosity piqued, Mr. Henderson approached the newcomer, a young man with a bewildered look in his eyes.");
            Thread.Sleep(200);
            Console.WriteLine("I'm Mr. Henderson, the last resident of this village, he continued. If you wish, you can build a home here, create a sanctuary amidst the tranquility of this forgotten place. Oh, and always feel welcome to come to my shop to buy and sell things.");
            Thread.Sleep(200);
            Console.WriteLine("As a gesture of welcome, Mr. Henderson offered the young man a sturdy pickaxe. Take this, he said, It might come in handy. Follow the path towards the mine, where treasure is waiting to be found.");
            Thread.Sleep(200);
            Console.WriteLine("With determination in his heart, he set forth on the winding path, his steps leading him closer to the fabled mine hidden amidst the dense forest.");
            Thread.Sleep(1000);
            while (true)
            {
                switch (placetogo)
                {
                    case "m": // Mine

                        if (isDaytime)
                        {
                            if (mineOnceaday)
                            {



                                currentTries = 0;
                                foundOpal = false;
                                foundRuby = false;

                                while (maxTries > currentTries)
                                {



                                    Console.WriteLine("Swing your pickaxe!");
                                    Console.WriteLine("Press enter to mine...");
                                    Console.ReadLine();



                                    double probability = random.NextDouble();
                                    if (secondStory)
                                    {
                                        if (probability < 0.2)
                                        {
                                            foundRuby = true;
                                            inventory.Add("ruby");
                                            itemAmounts["ruby"] = inventory.Count(item => item == "ruby");
                                            Console.WriteLine("Congratulations! You found the ruby!");
                                            Console.WriteLine("You have had " + currentTries + " tries so far!");
                                            currentTries++;
                                            Console.ReadLine();
                                        }
                                        else if (probability < 0.5)
                                        {
                                            foundOpal = true;
                                            inventory.Add("opal");
                                            itemAmounts["opal"] = inventory.Count(item => item == "opal");
                                            Console.WriteLine("Congratulations! You found the opal!");
                                            Console.WriteLine("You have had " + currentTries + " tries so far!");
                                            currentTries++;
                                            Console.ReadLine();
                                        }
                                        else if (probability < 0.55 && Exsist)
                                        {


                                            miningChoices.Remove("Monster");
                                            if (healthincrease)
                                            {
                                                mehealth = 200;
                                            }
                                            else
                                            {
                                                mehealth = 100;
                                            }

                                            Monsters();

                                            if (returns)
                                            {
                                                playonce = true;
                                                pieeater = true;
                                                Exsist = false;
                                                mineOnceaday = false;
                                                returns = false;
                                                if (healthincrease)
                                                {
                                                    mehealth = 200;
                                                }
                                                else
                                                {
                                                    mehealth = 100;
                                                }

                                                Console.WriteLine("you can continue mining now");


                                            }




                                        }
                                        else
                                        {
                                            Console.WriteLine("Oops! No luck this time. Keep trying!");
                                            currentTries++;
                                        }
                                    }
                                    else
                                    {


                                        if (probability < 0.1)
                                        {
                                            foundRuby = true;
                                            inventory.Add("ruby");
                                            itemAmounts["ruby"] = inventory.Count(item => item == "ruby");
                                            Console.WriteLine("Congratulations! You found the ruby!");
                                            Console.WriteLine("You have had " + currentTries + " tries so far!");
                                            currentTries++;
                                            Console.ReadLine();
                                        }
                                        else if (probability < 0.3)
                                        {
                                            foundOpal = true;
                                            inventory.Add("opal");
                                            itemAmounts["opal"] = inventory.Count(item => item == "opal");
                                            Console.WriteLine("Congratulations! You found the opal!");
                                            Console.WriteLine("You have had " + currentTries + " tries so far!");
                                            currentTries++;
                                            Console.ReadLine();
                                        }
                                        else if (probability < 0.35 && Exsist)
                                        {


                                            miningChoices.Remove("Monster");
                                            if (healthincrease)
                                            {
                                                mehealth = 200;
                                            }
                                            else
                                            {
                                                mehealth = 100;
                                            }
                                            Monsters();

                                            if (returns)
                                            {
                                                playonce = true;
                                                pieeater = true;
                                                Exsist = false;
                                                mineOnceaday = false;
                                                returns = false;
                                                if (healthincrease)
                                                {
                                                    mehealth = 200;
                                                }
                                                else
                                                {
                                                    mehealth = 100;
                                                }
                                                Console.WriteLine("you can continue mining now");


                                            }




                                        }
                                        else
                                        {
                                            Console.WriteLine("Oops! No luck this time. Keep trying!");
                                            currentTries++;
                                        }
                                    }
                                }

                                if (currentTries >= maxTries)
                                {
                                    Console.WriteLine("Exhaustion weighed heavily upon you, and your weary arms could swing the pickaxe no more.");
                                    Thread.Sleep(500);
                                    Exsist = true;
                                    mineOnceaday = false;

                                    miningChoices.Add("Monster");
                                    Console.WriteLine("Go home or go to shop (y or x)");
                                    placetogo = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("You can only mine once a day.");

                                Console.WriteLine("Go home or go to shop (y or x)");
                                placetogo = Console.ReadLine();
                            }
                        }
                        else
                        {
                            if (!ihatethis)
                            {
                                ihatethis = true;
                                Console.WriteLine("You hear sounds from the mine at night time. Do you want to investigate? (Danger)");

                                string youknow = Console.ReadLine();

                                if (youknow == "yes")
                                {
                                    Console.WriteLine("As the you enter the mine a monster lunged at you, its chilling touch sent shivers down your spine. With a thunderous force, it slammed you against the unyielding ground, leaving you dazed and disoriented. My vision blurred, and you struggled to catch you breath, the weight of the encounter bearing down upon you.");
                                    wego = true;
                                    fights1();

                                }
                                else
                                {
                                    Console.WriteLine("Go home or go to shop (y or x)");
                                    placetogo = Console.ReadLine();
                                }
                            }
                            if (retruns3)
                            {
                                Console.WriteLine("You got to escape");
                                wego = false;
                                ihatethis = false;
                                retruns3 = false;
                                if (healthincrease)
                                {
                                    mehealth = 200;
                                }
                                else
                                {
                                    mehealth = 100;
                                }
                                Console.WriteLine("Go home or go to shop (y or x)");
                                placetogo = Console.ReadLine();

                            }
                            else if (retruns4)
                            {

                                howmanygone++;
                                if (howmanygone == 3)
                                {

                                    justwork();





                                }

                                Console.WriteLine("You have fought " + howmanygone + " times.");
                                Console.WriteLine("Continue to fight?");
                                string you = Console.ReadLine();
                                if (you == "yes")
                                {
                                    if (healthincrease)
                                    {
                                        mehealth = 200;
                                    }
                                    else
                                    {
                                        mehealth = 100;
                                    }
                                    wego = true;
                                    retruns4 = true;

                                    fights1();
                                }
                                else
                                {
                                    wego = false;
                                    retruns3 = false;
                                    ihatethis = false;
                                    howmanygone = 0;
                                    Console.WriteLine("Go home or go to shop (y or x)");
                                    placetogo = Console.ReadLine();
                                }
                            }


                        }

                        break;

                    case "x": // Shop

                        if (isDaytime)
                        {


                            Console.WriteLine("Shop Owner: Welcome to my shop! How can I assist you today?");
                            string customerResponse = Console.ReadLine();

                            if (customerResponse.Contains("sell"))
                            {
                                Console.WriteLine("Shop Owner: Oh, you have something to sell! What item are you interested in selling? (You can only sell minarals)");
                                Thread.Sleep(1000);
                                Console.WriteLine("Inventory:");
                                foreach (var item in itemAmounts)
                                {
                                    Console.WriteLine($"You have: {item.Value} {item.Key} ");
                                }

                                string itemToSell = Console.ReadLine();

                                // Check if the item is in the inventory and has a positive amount
                                if (itemAmounts.ContainsKey(itemToSell) && itemAmounts[itemToSell] > 0)
                                {
                                    Console.WriteLine($"Shop Owner: Great! I'll evaluate your {itemToSell} and let you know the price I can offer.");
                                    Console.WriteLine($"Shop Owner: How many are you planning on selling?");

                                    string amountSold = Console.ReadLine();
                                    int convertedAmountSold = Convert.ToInt32(amountSold);

                                    if (convertedAmountSold <= itemAmounts[itemToSell])
                                    {
                                        if (itemToSell == "ruby")
                                        {
                                            moneyValue = 150 * convertedAmountSold;
                                        }
                                        else if (itemToSell == "opal")
                                        {
                                            moneyValue = 80 * convertedAmountSold;
                                        }
                                        else if (itemToSell == "diamond")
                                        {
                                            moneyValue = 1000 * convertedAmountSold;
                                        }
                                        else
                                        {
                                            Console.WriteLine("I'm sorry, but the item you want to sell is not valuable or does not exist.");
                                        }

                                        Console.WriteLine($"I can give you {moneyValue} for {convertedAmountSold} {itemToSell}. Is that okay with you?");
                                        string Yes = Console.ReadLine();

                                        if (Yes.Contains("yes"))
                                        {
                                            itemAmounts[itemToSell] -= convertedAmountSold;
                                            money += moneyValue;
                                            Console.WriteLine($"Shop Owner: Thank you for selling your item/s! You received {moneyValue} coins.");

                                            for (int i = 0; i < convertedAmountSold; i++)
                                            {
                                                inventory.Remove(itemToSell);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You don't have that many items to sell.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Shop Owner: I'm sorry, but it seems you don't have that item in your inventory to sell.");
                                }
                            }
                            else if (customerResponse.Contains("buy"))
                            {
                                double discountPercentage = 15.0;
                                double discountAmount = discountPercentage / 100.0;
                                Console.WriteLine("Shop Owner: Wonderful! What item are you interested in purchasing?");
                                Console.WriteLine("we sell: Wood Planks, Metal, leather, and diamonds!");
                                Console.WriteLine("Iron Sword: Increases overall damage by 20 (600)  Double boots: lands whirling attack 2 times (1000) Shocker: Can shock enemies for a turn (2000)");
                                Console.WriteLine("DO NOT BUY MUTIPLE WEAPONS OR GAME WILL CRASH");
                                string itemToBuy = Console.ReadLine();
                                Console.WriteLine("And how many?");
                                Thread.Sleep(1000);
                                Console.WriteLine($"You have: {money} coins");
                                string howManyBuy = Console.ReadLine();
                                double ConvertedHowMany = Convert.ToDouble(howManyBuy);


                                if (itemToBuy == "wood planks")
                                {
                                    double buying = 50;


                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buying * ConvertedHowMany} coins.");
                                    string Answer = Console.ReadLine();
                                    if (Answer.Contains("Yes"))
                                    {
                                        if (buying * ConvertedHowMany <= money)
                                        {

                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buying * ConvertedHowMany;
                                                double discountedBuying = buying - (discountAmount * buying);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buying * ConvertedHowMany;
                                            }




                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to use the wood planks wisely and build your dream home.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }

                                }
                                else if (itemToBuy == "metal")
                                {

                                    double buyingMetal = 300;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingMetal * ConvertedHowMany} coins.");
                                    string AnswerMetal = Console.ReadLine();
                                    if (AnswerMetal.Contains("Yes"))
                                    {
                                        if (buyingMetal * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingMetal * ConvertedHowMany;
                                                double discountedBuying = buyingMetal - (discountAmount * buyingMetal);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingMetal * ConvertedHowMany;
                                            }

                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to use the metal wisely and build your dream home.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");
                                        }
                                    }
                                }
                                else if (itemToBuy == "leather")
                                {
                                    double buyingLeather = 25;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingLeather * ConvertedHowMany} coins.");
                                    string AnswerLeather = Console.ReadLine();
                                    if (AnswerLeather.Contains("Yes"))
                                    {
                                        if (buyingLeather * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingLeather * ConvertedHowMany;
                                                double discountedBuying = buyingLeather - (discountAmount * buyingLeather);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingLeather * ConvertedHowMany;
                                            }


                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to use the wood planks wisely and build your dream home.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }


                                }
                                else if (itemToBuy == "diamond")
                                {
                                    double buyingDiamond = 1200;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingDiamond * ConvertedHowMany} coins.");
                                    string AnswerDiamond = Console.ReadLine();
                                    if (AnswerDiamond.Contains("Yes"))
                                    {
                                        if (buyingDiamond * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingDiamond * ConvertedHowMany;
                                                double discountedBuying = buyingDiamond - (discountAmount * buyingDiamond);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingDiamond * ConvertedHowMany;
                                            }

                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to use the wood planks wisely and build your dream home.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }



                                }
                                else if (itemToBuy == "iron sword")
                                {
                                    double buyingDiamond = 600;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingDiamond * ConvertedHowMany} coins.");
                                    string AnswerDiamond = Console.ReadLine();
                                    if (AnswerDiamond.Contains("Yes"))
                                    {


                                        if (buyingDiamond * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingDiamond * ConvertedHowMany;
                                                double discountedBuying = buyingDiamond - (discountAmount * buyingDiamond);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingDiamond * ConvertedHowMany;
                                            }

                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }

                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to stay safe.");


                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }

                                }
                                else if (itemToBuy == "double boots")
                                {
                                    double buyingDiamond = 1000;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingDiamond * ConvertedHowMany} coins.");
                                    string AnswerDiamond = Console.ReadLine();
                                    if (AnswerDiamond.Contains("Yes"))
                                    {


                                        if (buyingDiamond * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingDiamond * ConvertedHowMany;
                                                double discountedBuying = buyingDiamond - (discountAmount * buyingDiamond);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingDiamond * ConvertedHowMany;
                                            }

                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to stay safe.");

                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }
                                }
                                else if (itemToBuy == "shocker")
                                {
                                    double buyingDiamond = 2000;
                                    Console.WriteLine($"Shop Owner: Sure, we have {itemToBuy} in stock. Let me check the price for you. That will be {buyingDiamond * ConvertedHowMany} coins.");
                                    string AnswerDiamond = Console.ReadLine();
                                    if (AnswerDiamond.Contains("Yes"))
                                    {


                                        if (buyingDiamond * ConvertedHowMany <= money)
                                        {
                                            if (livingrum)
                                            {
                                                double discount = discountAmount * buyingDiamond * ConvertedHowMany;
                                                double discountedBuying = buyingDiamond - (discountAmount * buyingDiamond);
                                                double discountedConvertedHowMany = ConvertedHowMany - (discountAmount * ConvertedHowMany);
                                                money -= discountedBuying * discountedConvertedHowMany;
                                                Console.WriteLine("I have taken 15 percent of just for you, my friend.");
                                                money = Math.Round(money);
                                            }
                                            else
                                            {
                                                money -= buyingDiamond * ConvertedHowMany;
                                            }

                                            for (int i = 0; i < ConvertedHowMany; i++)
                                            {
                                                inventory.Add(itemToBuy);
                                                itemAmounts[itemToBuy] = inventory.Count(item => item == itemToBuy);
                                            }
                                            Console.WriteLine("With a cheerful nod, the shopkeeper urges you to stay safe.");

                                        }
                                        else
                                        {
                                            Console.WriteLine("Shop Owner: I'm sorry, but you don't have enough money to purchase this item.");

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oh well. Bye!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Shop Owner: I'm sorry, but we don't sell that item.");
                                }
                            }
                            else if (customerResponse.Contains("Secret House"))
                            {
                                secretHouse = false;
                                Console.WriteLine("I see. The shopkeeper's eyes gleamed with delight. With a mysterious smile, he handed the wanderer a neatly rolled parchment. Unraveling it, the stranger found detailed instructions and a list of materials needed to build his dream house in the abandoned village.");
                                Thread.Sleep(2000);
                                Console.WriteLine("It reads:  A Room nedds 4 Logs to be build, kitchen needs 6 logs, 2 metal and 1 opal, livingRoom cost 12 leather and 4 metal.");
                                Thread.Sleep(1000);
                                Console.WriteLine("To build another story, 20 logs, 12, metal and 2 diamonds will be needed. For a garden, 10 logs, and a diamond");
                                Thread.Sleep(1000);
                                Console.WriteLine("to build a second story, you need 4 rooms, 2 living rooms and 1 kitchen.");
                                Thread.Sleep(1000);
                                Console.WriteLine("Eachroom you build, you gain a special effect:");

                                Console.WriteLine("Make sure to not lose this. good luck building your house!");


                            }
                            else
                            {
                                Console.WriteLine("Shop Owner: I'm sorry, I didn't catch that. Are you here to sell or buy something? Oh well, doesn't matter. Please leave.");
                            }


                            Console.WriteLine("Do you want to go back to mining, check coins (or stay at shop), or go home? (m/i/x/y)");
                            placetogo = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Its Night time, the shop is currently closed");
                            Console.WriteLine("Do you want to go back to mining, check coins (or stay at shop), or go home? (m/i/x/y)");
                            placetogo = Console.ReadLine();
                        }

                        break;

                    case "i": // Inventory
                        Console.WriteLine($"You have: {money} coins");
                        Console.WriteLine("Inventory:");
                        foreach (var item in itemAmounts)
                        {
                            Console.WriteLine($"You have: {item.Value} {item.Key} ");
                        }
                        Console.WriteLine("Health: " + mehealth + "       Strong: " + meAttack + " ");
                        Thread.Sleep(1000);
                        Console.WriteLine("Do you want to go back to mining, check coins (or stay at shop), or go home? (m/i/x/y)");
                        placetogo = Console.ReadLine();
                        break;

                    case "y": // Home


                        if (FirsttimeinHouse)
                        {
                            Console.WriteLine("In your journey, you stumble upon a picturesque location, abundant with natural beauty and resources,");
                            Thread.Sleep(1000);
                            Console.WriteLine("where you envision building your dream house and creating a sanctuary amidst the tranquil surroundings.");
                            Thread.Sleep(1000);
                            Console.WriteLine("To start, I recommend building your first room. You will need FOUR wood planks to do so (b to build)");
                            string buildIntro = Console.ReadLine();


                            if (buildIntro.Contains("b"))
                            {
                                int woodPlankCountIntro = itemAmounts.ContainsKey("wood planks") ? itemAmounts["wood planks"] : 0;

                                if (woodPlankCountIntro >= roomsCost)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < roomsCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("wood planks");
                                        itemAmounts["wood planks"] = inventory.Count(item => item == "Wood Planks");
                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your first room is Complete!");

                                    Console.WriteLine("You are now free to build your house as much as you like! you can continue to build rooms, or add kitchens and living rooms. Soon enough a garden or second story can be added, but first have a chat with the storekeeper and say to him: Secret House.");
                                    FirsttimeinHouse = false;

                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough wood planks. Buy them with coins from the shop!");
                                }
                            }
                        }



                        if (!secretHouse)
                        {


                            if (!IntroGetroom) // Check if the player has already built a room
                            {

                                rooms++;

                                IntroGetroom = true; // Set the flag to true after building the first room



                            }

                            if (!isDaytime && rooms >= 1)
                            {
                                Console.WriteLine("Do you want to sleep?");
                                string sleeper = Console.ReadLine();
                                if (sleeper.Contains("Yes"))
                                {
                                    double probability = random.NextDouble();
                                    if (probability > 0.7)
                                    {
                                        if (probability > 0.3)
                                        {
                                            if (kitchen == 0)
                                            {

                                                Sleeping = true;
                                                Console.WriteLine("You slept through the night!");

                                            }
                                            else
                                            {
                                                Console.WriteLine(" Malgathor, the Soul-Eater attacked your house and destroyed one of your kitchens");
                                                kitchen -= 1;
                                            }
                                        }
                                        if (probability > 0.4)
                                        {

                                            if (rooms <= 1)
                                            {

                                                Sleeping = true;
                                                Console.WriteLine("You slept through the night!");

                                            }
                                            else
                                            {
                                                Console.WriteLine(" Malgathor, the Soul-Eater attacked your house and destroyed one of your rooms");
                                                rooms -= 1;
                                            }
                                        }
                                        if (probability > 0.3)
                                        {
                                            if (livingRooms == 0)
                                            {

                                                Sleeping = true;
                                                Console.WriteLine("You slept through the night!");

                                            }
                                            else
                                            {
                                                Console.WriteLine(" Malgathor, the Soul-Eater attacked your house and destroyed one of your rooms");
                                                livingRooms -= 1;
                                            }
                                        }


                                    }
                                    else
                                    {


                                        Sleeping = true;
                                        Console.WriteLine("You slept through the night!");
                                    }
                                }


                            }


                            Console.WriteLine("You have: " + rooms + " room/s, " + kitchen + " kitchen/s, " + livingRooms + " Living Room/s " + SecondStory + " seconds stories " + garden + "garden/s");
                            Thread.Sleep(500);
                            Console.WriteLine("n to check pamphlete. f to not.");
                            placetogo = Console.ReadLine();

                            if (placetogo != "n")
                            {



                            }
                            else
                            {
                                pamp();

                                if (retruns2)
                                {

                                }
                            }
                            Console.WriteLine("What do you want to build?");
                            string build = Console.ReadLine();

                            if (build.Contains("room"))
                            {
                                int woodPlankCountIntro = itemAmounts.ContainsKey("wood planks") ? itemAmounts["wood planks"] : 0;

                                if (woodPlankCountIntro >= roomsCost)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < roomsCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("wood planks");
                                        itemAmounts["wood planks"] = inventory.Count(item => item == "wood planks");
                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your room is Complete! you can now sleep at night.");
                                    rooms++;



                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough wood planks. Buy them with coins from the shop!");
                                }
                            }
                            else if (build.Contains("kitchen"))
                            {
                                int kitchenMetalCost = 2;
                                int kitchenWoodCost = 6;
                                int kitchenWoodPlanks = itemAmounts.ContainsKey("wood planks") ? itemAmounts["wood planks"] : 0;
                                int kitchenMetal = itemAmounts.ContainsKey("metal") ? itemAmounts["metal"] : 0;
                                if (kitchenWoodPlanks >= kitchenWoodCost && kitchenMetal >= kitchenMetalCost)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < kitchenWoodCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("wood planks");
                                        itemAmounts["wood planks"] = inventory.Count(item => item == "wood planks");

                                    }

                                    for (double checkingForPlanks = 0; checkingForPlanks < kitchenMetalCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("metal");
                                        itemAmounts["metal"] = inventory.Count(item => item == "metal");

                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your kitchen is Complete!");
                                    Console.WriteLine("You know get on pie each fight that you cooked to use. type pie to use");
                                    kitchen++;

                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough matriels. Buy them with coins from the shop!");
                                }

                            }
                            else if (build.Contains("living room"))
                            {
                                int LivingLeatherCost = 12;
                                int LivingMetalCost = 4;
                                int LivingLeather = itemAmounts.ContainsKey("leather") ? itemAmounts["leather"] : 0;
                                int LivingMetal = itemAmounts.ContainsKey("metal") ? itemAmounts["metal"] : 0;
                                if (LivingLeather >= LivingLeatherCost && LivingMetal >= LivingMetalCost)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < LivingMetalCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("metal");
                                        itemAmounts["metal"] = inventory.Count(item => item == "metal");

                                    }

                                    for (double checkingForPlanks = 0; checkingForPlanks < LivingLeatherCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("leather");
                                        itemAmounts["leather"] = inventory.Count(item => item == "leather");

                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your Living Room is Complete!");
                                    bool youkno = true;
                                    if (youkno)
                                    {
                                        Console.WriteLine("The shop keeper revealed a unique proposition as he saw your living room. In this desolate village, I sense an opportunity for both of us. I will grace your home with my presence, and in return, I shall lower the price of my finest goods for you, dear adventurer.");
                                        Console.WriteLine("You accept and he hands you a token. as long as you wear this you can reak the rewards of my proposition he says.");
                                        youkno = false;
                                    }

                                    livingRooms++;
                                    livingrum = true;

                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough matriels. Buy them with coins from the shop!");
                                }

                            }
                            else if (build.Contains("second story"))
                            {
                                int LivingLeatherCost = 12;
                                int LivingMetalCost = 4;
                                int LivingDiamondCost = 2;
                                int LivingDiamond = itemAmounts.ContainsKey("Diamond") ? itemAmounts["Diamond"] : 0;
                                int LivingLeather = itemAmounts.ContainsKey("Wood Planks") ? itemAmounts["Wood Planks"] : 0;
                                int LivingMetal = itemAmounts.ContainsKey("Metal") ? itemAmounts["Metal"] : 0;
                                if (LivingLeather >= LivingMetalCost && LivingMetal >= LivingLeatherCost && LivingDiamond >= LivingDiamondCost && rooms == 3 && livingRooms == 1 && kitchen == 1)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < LivingMetalCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("metal");
                                        itemAmounts["metal"] = inventory.Count(item => item == "metal");

                                    }

                                    for (double checkingForPlanks = 0; checkingForPlanks < LivingLeatherCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("wood planks");
                                        itemAmounts["wood planks"] = inventory.Count(item => item == "wood planks");

                                    }

                                    for (double checkingForPlanks = 0; checkingForPlanks < LivingDiamondCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("diamond");
                                        itemAmounts["diamond"] = inventory.Count(item => item == "diamond");

                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your Second Story is Complete!");
                                    SecondStory++;
                                    Console.WriteLine("The cozy and lucky atmosphere of the second story will bring good fortune, throughout your mining. ");
                                    secondStory = true;


                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough matriels/rooms. Buy them with coins from the shop!");
                                }





                            }
                            else if (build.Contains("garden"))
                            {
                                int kitchenMetalCost = 1;
                                int kitchenWoodCost = 10;
                                int kitchenWoodPlanks = itemAmounts.ContainsKey("wood planks") ? itemAmounts["wood planks"] : 0;
                                int kitchenMetal = itemAmounts.ContainsKey("diamond") ? itemAmounts["diamond"] : 0;
                                if (kitchenWoodPlanks >= kitchenWoodCost && kitchenMetal >= kitchenMetalCost)
                                {
                                    for (double checkingForPlanks = 0; checkingForPlanks < kitchenWoodCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("wood planks");
                                        itemAmounts["wood planks"] = inventory.Count(item => item == "wood planks");

                                    }

                                    for (double checkingForPlanks = 0; checkingForPlanks < kitchenMetalCost; checkingForPlanks++)
                                    {
                                        inventory.Remove("diamond");
                                        itemAmounts["diamond"] = inventory.Count(item => item == "diamond");

                                    }

                                    Console.WriteLine("Bang! Bang! Vrr... Whirr... CLANK");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("your Garden is Complete!");
                                    garden++;
                                    Console.WriteLine("your garden brings you great health with the flowers and fresh air, increasing your health to 200");
                                    mehealth = 200;
                                    healthincrease = true;
                                }
                                else
                                {
                                    Console.WriteLine("You do not have enough matriels. Buy them with coins from the shop!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("I think you should go to the shop first.");
                        }





                        Thread.Sleep(1000);
                        Console.WriteLine("Do you want to go back to mining, check coins (or go to shop), or stay home? (m/i/x/y)");
                        placetogo = Console.ReadLine();

                        break;
                    case "enter":

                        bossbattle();
                        break;



                    default:
                        Console.WriteLine("Invalid location. Please choose from the available options: m (mining), i (inventitory), x (shop), y (home)");
                        placetogo = Console.ReadLine();
                        break;
                }
            }


        }
        static void UpdateTime(object state)
        {
            // Increment the time counter by one second
            secondsElapsed++;

            // Check if it's time to switch to night
            if (secondsElapsed >= secondsInDay / 2 && isDaytime)
            {
                Console.WriteLine("It's now night time.");
                isDaytime = false;
                secondsElapsed = 0;
                monsterbuff++;
                if (monsterbuff == 10)
                {
                    AHealth += 10;
                    AStrong += 10;
                }
                else
                {
                    AHealth += 2;
                    AStrong += 2;
                }




            }
            // Check if it's time to switch back to day
            if (secondsElapsed >= secondsInNight && !isDaytime)
            {
                Console.WriteLine("It's now day time.");
                isDaytime = true;
                mineOnceaday = true;
                secondsElapsed = 0; // Reset the time counter
            }
            else if (Sleeping)
            {

                isDaytime = true;
                mineOnceaday = true;
                secondsElapsed = 0;
                Sleeping = false;
            }
        }



        static void Monsters()
        {
            Random random = new Random();
            double probability = random.NextDouble();

            string Attack = "";




            if (probability < 0.1)
            {
                AStrong = 45;
                AHealth = 200;

                Console.WriteLine("As you mine deeper into the darkness, a chilling voice echoes through the cavern, You dare to intrude in my realm,");
                Console.WriteLine("mortal? A figure materializes before you, his eyes glowing with an otherworldly intensity.");
                Console.WriteLine("Your presence disturbs the spirits of the departed. Prepare yourself for a confrontation that will test the limits of your courage.");
                Console.WriteLine("You have encountered: Azurael, the Ghostly Reaper");
                Console.WriteLine("Strength = 45 Health = 200");
                Monsterm = "Azurael";
                Monster();

            }
            else if (probability < 0.6)
            {
                AStrong = 10;
                AHealth = 50;

                Console.WriteLine("An ominous rumbling fills the air. Suddenly, the ground trembles beneath your feet, and with a thunderous roar, rocks and debris are hurled aside. A figure emerges from the darkness, towering above you with an insatiable hunger in his glowing eyes.");
                Console.WriteLine("You have encountered: Malgathor, the Soul-Eater");
                Console.WriteLine("Strength = 10 Health = 50");

                Monsterm = "Malgathor";
                Monster();
            }
            else
            {
                AStrong = 20;
                AHealth = 90;
                Console.WriteLine("In the depths of the mine, an ancient malevolence stirs. A faint whisper of chilling wind snakes through the tunnels, carrying a foreboding presence. As you venture further, the shadows coil and twist, taking the form of a colossal serpent.");
                Console.WriteLine("You have encountered: Drakona, the Abyssal Serpent");
                Console.WriteLine("Strength = 20 Health = 90");
                Console.WriteLine("Your Choice of Attack?");

                Monsterm = "Drakona";
                Monster();

            }




        }
        static void Monster()
        {


            Random random = new Random();
            double probability = random.NextDouble();
            if (mehealth <= 0)
            {






                Console.WriteLine("The " + Monsterm + " lunges forward with a menacing strike, overpowering you in the fight. It takes all your coins before vanishing back into the darkness of the mine.");
                shockers = false;
                money = 0; // Reset the player's coins to 0 when defeated
                Console.WriteLine("You have " + money + " coins");
                playonce = false;
                if (wego)
                {
                    retruns3 = true;
                    return;
                }


                returns = true;
                return;



            }

            Console.WriteLine("Attempt to flee (Run), Whirling Kick (Weak but reliable), Cyclone Strike (risky but powerful), Crushing Uppercut (powerful, but can hurt the player)");
            string Attack = Console.ReadLine();

            switch (Attack)
            {

                case "whirling kick":



                    if (inventory.Contains("double boots") && !inventory.Contains("iron sword"))
                    {
                        meAttack = 40;

                        Console.WriteLine("You did a double whirling kick!");
                    }
                    else if (inventory.Contains("iron sword") && !inventory.Contains("double boots"))
                    {
                        meAttack = 40;
                        Console.WriteLine("You hit " + Monsterm + " with a whirling kick");
                    }
                    else if (inventory.Contains("double boots") && inventory.Contains("iron sword"))
                    {
                        meAttack = 60;
                        Console.WriteLine("You did a double whirling kick!");
                    }
                    else
                    {
                        meAttack = 20;
                        Console.WriteLine("You hit " + Monsterm + " with a whirling kick");
                    }


                    AHealth -= meAttack;
                    if (AHealth <= 0)
                    {
                        Console.WriteLine(" " + Monsterm + " health is now: 0!");
                    }
                    else
                    {
                        Console.WriteLine("  " + Monsterm + " health is now: " + AHealth);
                    }

                    Thread.Sleep(1000);
                    MonsterFights();
                    return;
                    break;
                case "cyclone strike":
                    if (probability > 0.4)
                    {
                        if (inventory.Contains("iron sword"))
                        {
                            meAttack = 90;
                        }
                        else
                        {
                            meAttack = 60;
                        }
                        Console.WriteLine("You hit  " + Monsterm + " with a cyclone strike");
                        AHealth -= meAttack;
                        if (AHealth <= 0)
                        {
                            Console.WriteLine(" " + Monsterm + " health is now: 0!");
                        }
                        else
                        {
                            Console.WriteLine(" " + Monsterm + " health is now: " + AHealth);
                        }

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        mehealth -= 35;
                        Console.WriteLine("You miss and take 35 damage");
                    }
                    MonsterFights();
                    return;
                    break;
                case "crushing uppercut":
                    if (inventory.Contains("iron sword"))
                    {
                        meAttack = 60;
                    }
                    else
                    {
                        meAttack = 40;
                    }
                    Console.WriteLine("You hit  " + Monsterm + " with a crushing uppercut");
                    AHealth -= meAttack;
                    if (AHealth <= 0)
                    {
                        Console.WriteLine(" " + Monsterm + " health is now: 0!");
                    }
                    else
                    {
                        Console.WriteLine(" " + Monsterm + " health is now: " + AHealth);
                    }
                    mehealth -= 25;
                    Console.WriteLine("You did 20 damage to yourself");
                    Thread.Sleep(1000);
                    MonsterFights();
                    return;
                    break;
                case "run":
                    if (probability < 0.5)
                    {
                        Console.WriteLine("You escaped!");
                        if (wego)
                        {
                            retruns3 = true;
                            return;
                        }
                        else
                        {
                            returns = true;
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine(" " + Monsterm + " has caught you. It takes all your materials.");

                        int WoodPlanks = itemAmounts.ContainsKey("wood planks") ? itemAmounts["wood planks"] : 0;
                        for (double checkingForPlanks = 0; checkingForPlanks < WoodPlanks; checkingForPlanks++)
                        {
                            inventory.Remove("wood planks");
                            itemAmounts["wood planks"] = inventory.Count(item => item == "wood planks");
                        }

                        int Metal = itemAmounts.ContainsKey("metal") ? itemAmounts["metal"] : 0;
                        for (double checkingForMetal = 0; checkingForMetal < Metal; checkingForMetal++)
                        {
                            inventory.Remove("metal");
                            itemAmounts["metal"] = inventory.Count(item => item == "metal");
                        }

                        int Leather = itemAmounts.ContainsKey("leather") ? itemAmounts["leather"] : 0;
                        for (double checkingForLeather = 0; checkingForLeather < Leather; checkingForLeather++)
                        {
                            inventory.Remove("leather");
                            itemAmounts["leather"] = inventory.Count(item => item == "leather");
                        }
                        if (wego)
                        {
                            retruns3 = true;
                            return;
                        }
                        else
                        {
                            returns = true;
                            return;
                        }
                    }
                    break;
                case "pie":

                    if (pieeater)
                    {
                        Console.WriteLine("You ate a pie to regain 30 health");
                        mehealth += 30;
                        pieeater = false;
                        MonsterFights();
                        return;

                    }
                    else
                    {
                        Console.WriteLine(" you already ate it.");
                        Monster();
                        return;
                    }

                    break;

                default:
                    Monster();
                    break;
            }





        }
        static void MonsterFights()
        {



            Random random = new Random();
            double probability = random.NextDouble();


            if (mehealth <= 0)
            {






                Console.WriteLine("The Monster lunges forward with a menacing strike, overpowering you in the fight. It takes all your coins before vanishing back into the darkness of the mine.");
                shockers = false;
                money = 0; // Reset the player's coins to 0 when defeated
                Console.WriteLine("You have " + money + " coins");
                playonce = false;
                if (wego)
                {
                    retruns3 = true;
                    return;
                }
                else
                {
                    returns = true;
                    return;
                }





            }
            else if (AHealth <= 0)
            {
                // Monster defeated
                Console.WriteLine("In a final, desperate strike, you summon all your strength and deliver a devastating blow, vanquishing the fearsome creature, leaving it lifeless on the ground before you. The mine falls silent once more, and you stand as the victorious conqueror of the abyss.");

                if (probability <= 0.2)
                {
                    Console.WriteLine("It dropped a diamond!");
                    shockers = false;
                    inventory.Add("diamond");
                    itemAmounts["diamond"] = inventory.Count(item => item == "diamond");
                    if (wego)
                    {
                        retruns4 = true;
                        return;
                    }
                    else
                    {
                        returns = true;
                        return;
                    }




                }
                else if (probability > 0.2 && probability <= 0.6)
                {
                    Console.WriteLine("It dropped 400 Coins!");
                    shockers = false;
                    money += 400;
                    if (wego)
                    {
                        retruns4 = true;
                        return;
                    }
                    else
                    {
                        returns = true;
                        return;
                    }


                }
                else
                {
                    Console.WriteLine("It dropped 2 metal and a ruby!");
                    shockers = false;
                    inventory.Add("ruby");
                    itemAmounts["ruby"] = inventory.Count(item => item == "ruby");
                    inventory.Add("metal");
                    itemAmounts["metal"] = inventory.Count(item => item == "metal");
                    inventory.Add("metal");
                    itemAmounts["metal"] = inventory.Count(item => item == "metal");
                    if (wego)
                    {
                        retruns4 = true;
                        return;
                    }
                    else
                    {
                        returns = true;
                        return;
                    }


                }
            }


            if (inventory.Contains("shocker") && !shockers)
            {

                Console.WriteLine("Do you want to use shocker? (Once per fight)");
                string shocker = Console.ReadLine();

                if (shocker == "yes")
                {
                    Console.WriteLine("You shock the monster and daze it!");
                    shockers = true;
                    Monster();
                }
                else
                {
                    Console.WriteLine("The " + Monsterm + " attacks with a menacing strike, dealing " + AStrong + " damage!");
                    mehealth -= AStrong;
                    if (mehealth <= 0)
                    {
                        Console.WriteLine("The " + Monsterm + " lunges forward, overpowering you in the fight. It takes all your coins before vanishing back into the darkness of the mine.");
                        shockers = false;
                        money = 0; // Reset the player's coins to 0 when defeated
                        Console.WriteLine("You have " + money + " coins");
                        playonce = false;
                        if (wego)
                        {
                            retruns3 = true;
                            return;
                        }
                        else
                        {
                            returns = true;
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your health is now: " + mehealth);
                    }

                    Monster();
                }
            }
            else
            {



                Console.WriteLine("The " + Monsterm + " attacks with a menacing strike, dealing " + AStrong + " damage!");
                mehealth -= AStrong;
                if (mehealth <= 0)
                {
                    Console.WriteLine("The " + Monsterm + " lunges forward, overpowering you in the fight. It takes all your coins before vanishing back into the darkness of the mine.");
                    shockers = false;
                    money = 0; // Reset the player's coins to 0 when defeated
                    Console.WriteLine("You have " + money + " coins");
                    playonce = false;
                    if (wego)
                    {
                        retruns3 = true;
                        return;
                    }
                    else
                    {
                        returns = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Your health is now: " + mehealth);
                }
                Monster();
            }



            // Call the Monsters() function recursively to continue the battle

        }
        static void pamp()
        {


            Console.WriteLine(" A Room nedds 4 Logs to be build, kitchen needs 6 logs, 2 metal, livingRoom cost 12 leather and 4 metal.");
            Thread.Sleep(500);
            Console.WriteLine("To build another story, 15 logs, 8, metal and 2 diamonds will be needed. yu will need to have atleast 3 rooms, 1 kitchen and 1 living room to complete second story. For a garden, 10 logs, and a diamond");
            Thread.Sleep(500);
            Console.WriteLine("to build a second story, you need 4 rooms, 2 living rooms and 1 kitchen.");
            Thread.Sleep(500);
            retruns2 = true;
            return;


        }

        public static void fights1()
        {


            Random random = new Random();
            double probability = random.NextDouble();

            if (probability < 0.2)
            {
                AStrong = 60;
                AHealth = 250;
                Console.WriteLine("Suddenly, the temperature plummets, and an icy breeze sends shivers down your spine. Before you can react, you feel an unseen force slam you against the cold, stone wall of the mine. Your breath escapes you, and panic starts to set in as you struggle to break free.");
                Console.WriteLine("You have encountered: Veilstrike, the Silent Phantom");
                Console.WriteLine("Strength = 60 Health = 250");
                Monsterm = "Veilstrike";
                Monster();
            }
            else if (probability < 0.4)
            {
                AStrong = 70;
                AHealth = 250;
                Console.WriteLine("Deep within the mine's murky depths, you stumble upon the a monster. His ghastly presence freezes your blood, and with a bone-chilling glare, he hurls dark magic, forcing you to fight for your life against this malevolent force");
                Console.WriteLine("You have encountered: Necerise, the Cursed Lich");
                Console.WriteLine("Strength = 70 Health = 250");
                Monsterm = "Necerise";
                Monster();
            }
            else if (probability < 0.6)
            {
                AStrong = 99;
                AHealth = 60;
                Console.WriteLine("The monster possesses unimaginable and mystical powers that can bend reality itself. Her ethereal presence strikes fear into the hearts of all who encounter her, as she weaves spells of darkness and deception, capable of overpowering even the bravest souls.");
                Console.WriteLine("You have encountered: Nyxia, the Enchantress of Shadows");
                Console.WriteLine("Strength = 99 Health = 60");
                Monsterm = "Necerise";
                Monster();
            }
            else
            {
                fights1();
            }






        }

        public static void bossbattle()
        {

            Random random = new Random();
            double probability = random.NextDouble();

            Console.WriteLine("Whirling Kick (Weak but reliable), Cyclone Strike (risky but powerful), Crushing Uppercut (powerful, but can hurt the player)");
            string Attacks = Console.ReadLine();

            switch (Attacks)
            {

                case "whirling kick":



                    if (inventory.Contains("double boots") && !inventory.Contains("iron sword"))
                    {
                        meAttack = 120;

                        Console.WriteLine("You did a double whirling kick!");
                    }
                    else if (inventory.Contains("iron sword") && !inventory.Contains("double boots"))
                    {
                        meAttack = 100;
                        Console.WriteLine("You hit Zephros with a whirling kick");
                    }
                    else if (inventory.Contains("double boots") && inventory.Contains("iron sword"))
                    {
                        meAttack = 150;
                        Console.WriteLine("You did a double whirling kick!");
                    }
                    else
                    {
                        meAttack = 35;
                        Console.WriteLine("You hit Zephros with a whirling kick");
                    }


                    AHealth -= meAttack;
                    if (AHealth <= 0)
                    {
                        Console.WriteLine("Zephros health is now: 0!");
                    }
                    else
                    {
                        Console.WriteLine(" Zephros health is now: " + AHealth);
                    }

                    Thread.Sleep(1000);
                    win();
                    break;
                case "cyclone strike":
                    if (probability > 0.4)
                    {
                        if (inventory.Contains("iron sword"))
                        {
                            meAttack = 150;
                        }
                        else
                        {
                            meAttack = 120;
                        }
                        Console.WriteLine("You hit Zephros with a cyclone strike");
                        AHealth -= meAttack;
                        if (AHealth <= 0)
                        {
                            Console.WriteLine("Zephros health is now: 0!");
                        }
                        else
                        {
                            Console.WriteLine("Zephros health is now: " + AHealth);
                        }

                        Thread.Sleep(1000);
                    }
                    else
                    {
                        mehealth -= 35;
                        Console.WriteLine("You miss and take 35 damage");
                    }
                    win();
                    break;
                case "crushing uppercut":
                    if (inventory.Contains("iron sword"))
                    {
                        meAttack = 130;
                    }
                    else
                    {
                        meAttack = 100;
                    }
                    Console.WriteLine("You hit Zephros with a crushing uppercut");
                    AHealth -= meAttack;
                    if (AHealth <= 0)
                    {
                        Console.WriteLine("Zephros health is now: 0!");
                    }
                    else
                    {
                        Console.WriteLine("Zephros health is now: " + AHealth);
                    }
                    mehealth -= 25;
                    Console.WriteLine("You did 25 damage to yourself");
                    Thread.Sleep(1000);
                    win();
                    break;

                case "pie":

                    if (pieeater)
                    {
                        Console.WriteLine("You ate a pie to regain 50 health");
                        mehealth += 50;
                        pieeater = false;
                        win();
                    }
                    else
                    {
                        Console.WriteLine("you already ate it.");
                        bossbattle();
                    }

                    break;

                default:
                    bossbattle();
                    break;
            }
            static void win()
            {
                Random random = new Random();
                double probability = random.NextDouble();


                if (mehealth <= 0)
                {
                    Console.WriteLine("As the battle rages on, you feel your strength waning, and the once powerful bond with the villagers begins to falter under the relentless onslaught. Zephros's nefarious powers drain the last ounce of life from your weary body, leaving you gasping for breath. Your vision blurs, and the world around you fades to black.");
                    Console.WriteLine("As your consciousness slips away, you hear the distant cries of the villagers, their hearts breaking at the loss of their hero. The shopkeeper's wicked laughter echoes in the void, triumphant in his malevolence.");
                    Console.WriteLine("End of game. thanks for Playing!");
                    Environment.Exit(0);


                }
                else if (AHealth <= 0)
                {
                    Console.WriteLine("you muster every ounce of strength and courage you possess, channeling the unwavering resolve of the villagers who stand behind you. With their combined power and your unwavering determination, you confront the monstrous shopkeeper, now a vessel of malevolence. The air crackles with intense energy as you unleash a torrent of attacks upon the cursed being. Your strikes are precise, guided by the memories of your battles and the lessons learned from each encounter.");
                    Console.WriteLine("he shopkeeper's grotesque form convulses, weakened by the relentless onslaught of your assault. The villagers' power flows through you, empowering your strikes with a radiant energy that forces back the encroaching darkness. In a final, resounding blow, you strike at the heart of the malevolent creature. The air crackles with a brilliant burst of light as the darkness is expelled, and the shopkeeper's monstrous form begins to falter.");
                    Console.WriteLine("As the cursed shopkeeper's body contorts and convulses with unimaginable power, his form suddenly explodes into a grotesque amalgamation of monstrous limbs and shadows. A deafening blast reverberates through the once-abandoned village as chaos ensues. The villagers, still bound by ropes, cry out for help.Summoning your last reserves of strength, you rush to the aid of the captured villagers.With sheer determination, you manage to free them from their restraints just in time to witness the monstrous creature's relentless assault. Your mind races, seeking a solution to end this nightmare.In a moment of clarity, you recall the ancient relic that brought you to this forsaken land.Taking it firmly in your grasp, you channel its mysterious energy, unleashing a surge of power that envelops the beast.As the mystical energy collides with the monster, the shadows dissipate, and the creature lets out a haunting cry before vanishing into oblivion.");
                    Console.WriteLine("With the curse finally lifted, the village begins to flourish again. You choose to make this place your home, vowing to protect it from any future threats. The once-abandoned village transforms into a thriving community, and its people celebrate your arrival.");
                    Console.WriteLine("End of game. Thanks for playing!");
                    Environment.Exit(0);
                }


                if (inventory.Contains("shocker") && !shockers)
                {

                    Console.WriteLine("Do you want to use shocker? (Once per fight)");
                    string shocker = Console.ReadLine();

                    if (shocker == "yes")
                    {
                        Console.WriteLine("You shock Zephros and daze it!");
                        shockers = true;
                        bossbattle();
                    }
                    else
                    {
                        Console.WriteLine("The Zephros unleashes his dark magic, dealing " + AStrong + " damage!");
                        mehealth -= AStrong;
                        if (mehealth <= 0)
                        {
                            Console.WriteLine("you muster every ounce of strength and courage you possess, channeling the unwavering resolve of the villagers who stand behind you. With their combined power and your unwavering determination, you confront the monstrous shopkeeper, now a vessel of malevolence. The air crackles with intense energy as you unleash a torrent of attacks upon the cursed being. Your strikes are precise, guided by the memories of your battles and the lessons learned from each encounter.");
                            Console.WriteLine("he shopkeeper's grotesque form convulses, weakened by the relentless onslaught of your assault. The villagers' power flows through you, empowering your strikes with a radiant energy that forces back the encroaching darkness. In a final, resounding blow, you strike at the heart of the malevolent creature. The air crackles with a brilliant burst of light as the darkness is expelled, and the shopkeeper's monstrous form begins to falter.");
                            Console.WriteLine("As the cursed shopkeeper's body contorts and convulses with unimaginable power, his form suddenly explodes into a grotesque amalgamation of monstrous limbs and shadows. A deafening blast reverberates through the once-abandoned village as chaos ensues. The villagers, still bound by ropes, cry out for help.Summoning your last reserves of strength, you rush to the aid of the captured villagers.With sheer determination, you manage to free them from their restraints just in time to witness the monstrous creature's relentless assault. Your mind races, seeking a solution to end this nightmare.In a moment of clarity, you recall the ancient relic that brought you to this forsaken land.Taking it firmly in your grasp, you channel its mysterious energy, unleashing a surge of power that envelops the beast.As the mystical energy collides with the monster, the shadows dissipate, and the creature lets out a haunting cry before vanishing into oblivion.");
                            Console.WriteLine("With the curse finally lifted, the village begins to flourish again. You choose to make this place your home, vowing to protect it from any future threats. The once-abandoned village transforms into a thriving community, and its people celebrate your arrival.");
                            Console.WriteLine("End of game. Thanks for playing!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Your health is now: " + mehealth);
                        }
                        bossbattle();
                    }
                }
                else
                {


                    Console.WriteLine("The monster attacks with a menacing strike, dealing " + AStrong + " damage!");
                    mehealth -= AStrong;

                    if (mehealth <= 0)
                    {
                        Console.WriteLine("you muster every ounce of strength and courage you possess, channeling the unwavering resolve of the villagers who stand behind you. With their combined power and your unwavering determination, you confront the monstrous shopkeeper, now a vessel of malevolence. The air crackles with intense energy as you unleash a torrent of attacks upon the cursed being. Your strikes are precise, guided by the memories of your battles and the lessons learned from each encounter.");
                        Console.WriteLine("he shopkeeper's grotesque form convulses, weakened by the relentless onslaught of your assault. The villagers' power flows through you, empowering your strikes with a radiant energy that forces back the encroaching darkness. In a final, resounding blow, you strike at the heart of the malevolent creature. The air crackles with a brilliant burst of light as the darkness is expelled, and the shopkeeper's monstrous form begins to falter.");
                        Console.WriteLine("As the cursed shopkeeper's body contorts and convulses with unimaginable power, his form suddenly explodes into a grotesque amalgamation of monstrous limbs and shadows. A deafening blast reverberates through the once-abandoned village as chaos ensues. The villagers, still bound by ropes, cry out for help.Summoning your last reserves of strength, you rush to the aid of the captured villagers.With sheer determination, you manage to free them from their restraints just in time to witness the monstrous creature's relentless assault. Your mind races, seeking a solution to end this nightmare.In a moment of clarity, you recall the ancient relic that brought you to this forsaken land.Taking it firmly in your grasp, you channel its mysterious energy, unleashing a surge of power that envelops the beast.As the mystical energy collides with the monster, the shadows dissipate, and the creature lets out a haunting cry before vanishing into oblivion.");
                        Console.WriteLine("With the curse finally lifted, the village begins to flourish again. You choose to make this place your home, vowing to protect it from any future threats. The once-abandoned village transforms into a thriving community, and its people celebrate your arrival.");
                        Console.WriteLine("End of game. Thanks for playing!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Your health is now: " + mehealth);
                    }

                    bossbattle();
                }








            }



        }
        public static void justwork()
        {


            double nice = 400;
            AHealth = 600;
            AStrong = 130;
            mehealth += nice;
            Console.WriteLine("As night shrouds the abandoned village in darkness, you notice an eerie glow emanating from the once-closed shop. Intrigued and cautious, you follow the light to investigate. To your horror, you find the shopkeeper, eyes filled with malevolence, tying up innocent villagers in sinister, enchanted bonds. In an instant, the shopkeeper transforms into a colossal, nightmarish monster, its monstrous form now blocking the escape route. The village's fate rests on your shoulders as you face the terrifying and powerful entity, determined to free the captives and bring an end to this nightmarish curse.");
            Console.WriteLine("The shopkeeper's face contorts with agony as he utters sinister words in an ancient tongue. His body starts convulsing, rising higher and higher from the ground, surrounded by an aura of darkness. Panic takes hold as he transforms into a monstrous entity known as Zephros, the Malevolent.");
            Thread.Sleep(1000);
            Console.WriteLine("His eyes burn with a malevolent fire, and his once-friendly smile turns into a twisted grin. The ground shakes under your feet as his monstrous form swells, ripping through the seams of his mortal body. Time seems to slow as you face this horrifying creature that was once the humble shopkeeper.");
            Thread.Sleep(1000);
            Console.WriteLine("Zephros releases a bone-chilling roar, and the very air around him turns icy cold. Your heart races as you prepare to confront this embodiment of terror and malevolence. The villagers' lives hang in the balance, and only your courage and strength stand in the way of an unspeakable fate.");
            Thread.Sleep(1000);
            Console.WriteLine("As Zephros, the Malevolent, unleashes his unholy powers, an overwhelming darkness engulfs you. A chilling sensation seizes your soul, and with every fiber of your being, you struggle to resist. But Zephros's grip is relentless, draining the life force from you, leaving you weakened and helpless. Your eyes roll back, and a haunting emptiness fills your consciousness as your body drops to the ground, crumbling like fragile parchment.");
            Thread.Sleep(1000);
            Console.WriteLine("But just as despair threatens to consume you, the villagers, bound and desperate, pool their latent power. The power of the villagers courses through your veins, augmenting your abilities beyond anything you've known before.");
            Console.WriteLine("you have encountered: Zephros, the Malevolent.");
            Console.WriteLine("Your new health is " + mehealth + " and your much stronger");
            Console.WriteLine("Zephros health is 800 and strong is 130");
            Monsterm = "Zephros";
            bossbattle();




        }

    }
}
