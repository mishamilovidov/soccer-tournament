using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Name:           Misha Milovidov
 *  Date:           2016.09.14
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

            public soccerTeam(string sName, int iPoints)
            {
                this.teamName = sName;
                this.points = iPoints;
            }

        }

        public class Game
        {
            public string homeTeam;
            public string visitorTeam;
            public int homePoints;
            public int visitorPoints;
        }

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
            //Create a list of soccer-team objects and declare variables:
            List<soccerTeam> teams = new List<soccerTeam>();
            bool intValidation = false;
            int teamCount = 0;

            //STEP 1: Get the number of teams from the user.
            Console.Write("How many teams? ");

            //Keep asking user until valid integer is entered:
            while (intValidation == false)
            {
                string sTeams = Console.ReadLine();
                try
                {
                    teamCount = Convert.ToInt32(sTeams);
                    intValidation = true;
                }
                catch (FormatException)
                {
                    Console.Write("Please enter a valid integer: ");
                }

            }
            Console.WriteLine("\n");

            //STEP 2: Get information about each team from the user.
            for (int i = 0; i < teamCount; i++)
            {
                int teamPoints = 0;
                bool integerValidation = false;

                //Get team name from user:
                Console.Write("Enter Team " + (i + 1) + "'s name: ");
                string teamName = UppercaseFirst(Console.ReadLine());

                //Get team points from user:
                Console.Write("Enter Team " + teamName + "'s points: ");
                //Keep asking user until valid integer is entered:
                while (integerValidation == false)
                {
                    string sTeamPoints = Console.ReadLine();
                    try
                    {
                        teamPoints = Convert.ToInt32(sTeamPoints);
                        integerValidation = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Please enter a valid integer: ");
                    }

                }

                Console.WriteLine("\n");

                //Add soccer-team object to list:
                soccerTeam teamInfo = new soccerTeam(teamName, teamPoints);
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

            Console.Read();
        }
    }
}
