using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Name:           Misha Milovidov
 *  Date:           2016.09.14
 *  GitHub Repo:    https://github.com/mmilovidov/soccer-tournament.git
 *  Description:    Draw a class diagram that represents a Soccer Tournament. You will need a Team parent class, a child soccer class, and a game class. 
 *                  Write a program that prompts the user to enter in the number of teams competing in an olympic soccer tournament. Then for the number 
 *                  of teams entered, prompt the user to enter the name of the team and the number of points the team has scored. Finally, display the 
 *                  results of the tournament. Make sure your console output matches the sample screenshot in the requirements below exactly.
 */

namespace consoleProject
{
    class Program
    {
        public class Team
        {
            public string teamName;
            public int wins;
            public int losses;

        }

        public class soccerTeam : Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;

            public soccerTeam(string sName)
            {
                this.teamName = sName;
            }

        }

        public class Game
        {
            public string homeTeam;
            public string visitorTeam;
            public int homeScore = 0;
            public int visitorScore = 0;

            public Game(string sHomeTeam, string sVisitorTeam)
            {
                this.homeTeam = sHomeTeam;
                this.visitorTeam = sVisitorTeam;
            }
        }

        //Function that makes sure integer wasn't negative
        static int validateIntPositive(int optionSelected)
        {
            while (optionSelected < 0)
            {
                Console.Write("Your input is negative; please enter a number that is positive: ");
                string userInput = Console.ReadLine();

                optionSelected = Convert.ToInt32(userInput);
            }

            return optionSelected;
        }

        //Function that makes sure valid integer was entered
        static int validateInt (string userInput)
        {
            bool intValidate = false;
            int optionSelected = 0;

            while (intValidate == false)
            {
                try
                {
                    optionSelected = Convert.ToInt32(userInput);
                    intValidate = true;
                }
                catch (FormatException)
                {
                    Console.Write("Please enter a valid integer: ");
                    userInput = Console.ReadLine();
                }
            }

            optionSelected = validateIntPositive(optionSelected);
            return optionSelected;
        }

        //Capitalizes first letter of string
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {  
            bool validOption = false;

            while (validOption == false) 
            { 
                int optionSelected = 0;

                Console.WriteLine("1 - Add teams and points from tournament to view rankings");
                Console.WriteLine("2 - Simulate tournament for simulated rankings");
                Console.Write("Please select an option: ");

                optionSelected = validateInt(Console.ReadLine());

                Console.WriteLine("\n");

                if (optionSelected == 1)
                {
                    //Create a list of soccer-team objects and declare variables:
                    List<soccerTeam> teams = new List<soccerTeam>();
                    int teamCount = 0;

                    //STEP 1: Get the number of teams from the user.
                    Console.Write("How many teams? ");
                    //Keep asking user until valid integer is entered:
                    teamCount = validateInt(Console.ReadLine());

                    Console.WriteLine("\n");

                    //STEP 2: Get information about each team from the user.
                    for (int i = 0; i < teamCount; i++)
                    {
                        int teamPoints = 0;

                        //Get team name from user:
                        Console.Write("Enter Team " + (i + 1) + "'s name: ");
                        //Make first letter capitalized
                        string teamName = UppercaseFirst(Console.ReadLine());

                        //Get team points from user:
                        Console.Write("Enter Team " + teamName + "'s points: ");
                        //Keep asking user until valid integer is entered:
                        teamPoints = validateInt(Console.ReadLine());

                        Console.WriteLine("\n");

                        //Add soccer-team object to list:
                        soccerTeam teamInfo = new soccerTeam(teamName);
                        teamInfo.points = teamPoints;
                        teams.Add(teamInfo);
                    }

                    //STEP 3: Sort list of soccer-team object by their points descending.
                    List<soccerTeam> sortedTeams = teams.OrderByDescending(team => team.points).ToList();

                    //STEP 4: Display table of soccer team names and points by points descending.
                    Console.Write("Here is the sorted list:");
                    Console.WriteLine("\n");
                    Console.WriteLine("Position".PadRight(25, ' ') + "\t" + "Name".PadRight(25, ' ') + "\t" + "Points".PadRight(25, ' '));
                    Console.WriteLine("--------".PadRight(25, ' ') + "\t" + "--------".PadRight(25, ' ') + "\t" + "--------".PadRight(25, ' '));

                    int count = 0;
                    foreach (soccerTeam teamRank in sortedTeams)
                    {
                        count++;
                        Console.WriteLine(Convert.ToString(count).PadRight(25, ' ') + "\t" +
                            Convert.ToString(teamRank.teamName).PadRight(25, ' ') + "\t" +
                            Convert.ToString(teamRank.points).PadRight(25, ' '));
                    }

                    //Exit loop
                    validOption = true;
                }

                else if (optionSelected == 2)
                {
                    Console.Write("Tournament simulation is not completed; partial code is commented out.\nPlease select option 1.");
                    Console.WriteLine("\n");

                    ////Create a list of soccer-team objects and declare variables:
                    //List<soccerTeam> teams = new List<soccerTeam>();

                    //int teamCount = 0;

                    ////STEP 1: Get the number of teams in the tournament from the user.
                    //Console.Write("How many teams are in the tournament? ");

                    ////Keep asking user until valid integer is entered:
                    //teamCount = validateInt(Console.ReadLine());

                    ////Get team names from user
                    //for (int i = 0; i < teamCount; i++)
                    //{
                    //    //Get team name from user:
                    //    Console.Write("Enter Team " + (i + 1) + "'s name: ");
                    //    string teamName = UppercaseFirst(Console.ReadLine());

                    //    //Add soccer-team object to list:
                    //    soccerTeam teamInfo = new soccerTeam(teamName);
                    //    teams.Add(teamInfo);
                    //}

                    ////Create a list of game objects
                    //List<Game> games = new List<Game>();

                    //int offset = 1;

                    //foreach (soccerTeam team in teams)
                    //{
                    //    string homeTeam = team.teamName;

                    //    for (int i = offset; i < (teams.Count); i++)
                    //    {
                    //        string awayTeam = teams[i].teamName;

                    //        Console.WriteLine(homeTeam + " vs. " + awayTeam + ":");
                    //        Console.Write("How many goals did " + homeTeam + " score? ");
                    //        int homeGoals = validateInt(Console.ReadLine());
                    //        Console.Write("How many goals did " + awayTeam + " score? ");
                    //        int awayGoals = validateInt(Console.ReadLine());

                    //        Game gameInfo = new Game(homeTeam, awayTeam);
                    //        gameInfo.homeScore = homeGoals;
                    //        gameInfo.visitorScore = awayGoals;

                    //    }

                    //    offset++;
                    //}

                    //Exit loop
                    //validOption = true;
                    validOption = false;
                }

                else
                {
                    Console.Write("Not a valid option!\n\n");

                    //Loop back to options
                    validOption = false;
                }
            }
            Console.Read();
        }
    }
}
