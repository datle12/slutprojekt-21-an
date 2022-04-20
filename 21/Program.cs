using System;
using System.Threading;
using System.Collections.Generic;


namespace _21an_new
{
    //Programmen innehåller 7 metoder
    //Menu(); Meny
    //Start(); för att påbörja spelet
    //Game(); spel win-lose conditions 
    //Deal(); delar kort
    //DealersCard(); Metoden för det första kort av delare
    //Hit(); låt spelare drar kort och visa hur många poäng har spelare
    //PlayAgain(); rensa bort allting och frågar spelare om hen vill spela igen
    class Blackjack
    {
        //skapa en arrray för spelares kort, spelare får bara har max 11 kort.
        static string[] playerCards = new string[12];
        static string hitOrStay = "";
        static int total = 0, count = 1, dealerTotal = 0;
        //skapa en slumpmässig maskin till dealer och spelare
        static Random cardRandomizer = new Random();
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to Blackjack Lite!");
            string MenuChoice = "";
            while (MenuChoice != "2")
            {
                Console.WriteLine("1. Start the game");
                Console.WriteLine("2. Quit game");
                Console.WriteLine("\n*few changes:\n1. You can not change the value of Ace, instead *Ace from now on has the value of 1, *Aces has the value of 11.");
                Console.WriteLine();
                MenuChoice = Console.ReadLine();
                Console.WriteLine();

                if (MenuChoice == "1")
                {
                    Start();
                    Console.WriteLine();
                }
                else if (MenuChoice == "2")
                {
                    Console.WriteLine("\nPress enter to close Blackjack Lite.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Error! Choose between 1-2 instead!");
                    Console.WriteLine();
                    Menu();

                }
            }
        }

        static void Start()
        {
            //bestämmer dealers kort
            dealerTotal = cardRandomizer.Next(17, 25);
            //två första kortet
            playerCards[0] = Deal();
            playerCards[1] = Deal();
            //delare första kort
            string dealerFirst = DealersCard();

            do
            {

                Console.Write("You were dealed " + playerCards[0] + " and " + playerCards[1] + ". \nYour total is ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(total);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
                Console.WriteLine("");
                Console.WriteLine("\nDealer's first card is " + dealerFirst);


                if (total.Equals(21))
                {
                    Console.WriteLine("\nYou got Blackjack!\nWould you like to play again? y/n");
                    PlayAgain();
                }

                Console.WriteLine("\nWould you like to Hit or Stay?");
                hitOrStay = Console.ReadLine().ToLower();

                if (hitOrStay != "hit" && hitOrStay != "stay")
                {
                    Console.WriteLine("Error! write these 2 keyword (hit/stay) instead!");
                    hitOrStay = Console.ReadLine().ToLower();
                }

                Game();


            } while (!hitOrStay.Equals("hit") && !hitOrStay.Equals("stay"));

        }
        static void Game()
        {
            if (hitOrStay.Equals("hit"))
            {
                Hit();
                //flyttar till metod Hit()
            }
            else if (hitOrStay.Equals("stay"))
            {

                if (total > dealerTotal && total <= 21)
                {
                    Console.WriteLine("dealer is taking cards...");
                    Thread.Sleep(2000);
                    Console.Write("\nCongrats! You won the game! The dealer's total was ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(dealerTotal);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                    Console.WriteLine("\nWould you like to play again? y/n");
                    PlayAgain();
                }
                else if (total < dealerTotal && dealerTotal <= 21)
                {
                    Console.WriteLine("dealer is taking cards...");
                    Thread.Sleep(2000);
                    Console.Write("\nSorry, you lost, dealer's total was ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(dealerTotal);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                    Console.WriteLine("\nWould you like to play again? y/n");
                    PlayAgain();
                    PlayAgain();
                }
                else if (total < 21 && dealerTotal > 21)
                {
                    Console.WriteLine("dealer is taking cards...");
                    Thread.Sleep(2000);
                    Console.Write("\nCongrats! You won the game! The dealer's total was ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(dealerTotal);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                    Console.WriteLine("\nWould you like to play again? y/n");
                    PlayAgain();
                }
                else if (total > 21 && dealerTotal > 21)
                {
                    Console.WriteLine("dealer is taking cards...");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nYou both busted, it's a tie" + ".\nWould you like to play again? y/n");
                    PlayAgain();
                }
                else if (total == dealerTotal)
                {
                    Console.WriteLine("dealer is taking cards...");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nYou both had same points, it's a tie" + "\nWould you like to play again? y/n");
                    PlayAgain();
                }


            }
            Console.ReadLine();
        }

        static string Deal()
        {
            string Card = "";
            int cards = cardRandomizer.Next(1, 15);
            switch (cards)
            {
                case 1:
                    Card = "Two"; total += 2;
                    break;
                case 2:
                    Card = "Three"; total += 3;
                    break;
                case 3:
                    Card = "Four"; total += 4;
                    break;
                case 4:
                    Card = "Five"; total += 5;
                    break;
                case 5:
                    Card = "Six"; total += 6;
                    break;
                case 6:
                    Card = "Seven"; total += 7;
                    break;
                case 7:
                    Card = "Eight"; total += 8;
                    break;
                case 8:
                    Card = "Nine"; total += 9;
                    break;
                case 9:
                    Card = "Ten"; total += 10;
                    break;
                case 10:
                    Card = "Jack"; total += 10;
                    break;
                case 11:
                    Card = "Queen"; total += 10;
                    break;
                case 12:
                    Card = "King"; total += 10;
                    break;
                case 13:
                    Card = "Aces"; total += 11;
                    break;
                case 14:
                    Card = "Ace"; total += 1;
                    break;
                default:
                    Card = "2"; total += 2;
                    break;
            }
            return Card;


        }
        static string DealersCard()
        {

            var dealerFC = new List<string>();
            dealerFC.Add("Two");
            dealerFC.Add("Three");
            dealerFC.Add("Four");
            dealerFC.Add("Five");
            dealerFC.Add("Six");
            dealerFC.Add("Seven");
            dealerFC.Add("Eight");
            dealerFC.Add("Nine");
            dealerFC.Add("Ten");
            dealerFC.Add("Jack");
            dealerFC.Add("Queen");
            dealerFC.Add("King");
            dealerFC.Add("Ace");
            dealerFC.Add("Aces");
            int index = cardRandomizer.Next(dealerFC.Count);
            return (dealerFC[index]);
        }
        static void Hit()
        {
            count += 1;
            Console.WriteLine("...");
            Thread.Sleep(1000);
            playerCards[count] = Deal();
            Console.Write("\nYou were dealed a/n " + playerCards[count] + ".\nYour new total is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(total);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");



            if (total.Equals(21))
            {
                Console.WriteLine("\nYou got Blackjack!.\nWould you like to play again? y/n");
                PlayAgain();
            }
            else if (total.Equals(21) && dealerTotal.Equals(21))
            {
                Console.WriteLine("\nYou both had same points, it's a tie" + "\nWould you like to play again? y/n");
                PlayAgain();
            }

            else if (total > 21 && dealerTotal > 21)
            {
                Console.WriteLine("\nYou both busted, it's a tie" + ".\nWould you like to play again? y/n");
                PlayAgain();
            }
            else if (total > 21)
            {
                Console.Write("\nYou busted, therefore you lost. Sorry. The dealer's total was ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(dealerTotal);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
                Console.WriteLine("\nWould you like to play again? y/n");
                PlayAgain();
            }
            else if (total < 21)
            {
                do
                {
                    Console.WriteLine("\nWould you like to hit or stay?");
                    hitOrStay = Console.ReadLine().ToLower();

                    if (hitOrStay != "hit" && hitOrStay != "stay")
                    {
                        Console.WriteLine("Error! write these 2 keyword (hit/stay) instead!");
                        hitOrStay = Console.ReadLine().ToLower();
                    }
                } while (!hitOrStay.Equals("hit") && !hitOrStay.Equals("stay"));
                Game();
                //tillbaka till metod Game() om total mindre än 21.
            }

        }

        static void PlayAgain()
        {
            string playAgain = "";
            do
            {
                playAgain = Console.ReadLine().ToLower();
            } while (!playAgain.Equals("y") && !playAgain.Equals("n"));
            if (playAgain.Equals("y"))
            {
                Console.WriteLine("\nPress enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                count = 1;
                total = 0;
                Start();
            }
            else if (playAgain.Equals("n"))
            {
                Console.WriteLine("\nPress enter to close Blackjack Lite.");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }

    }


}









