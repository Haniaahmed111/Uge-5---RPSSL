using System;

class Program
{
    static void Main()
    {

        string[] names = { "rock", "paper", "scissors", "lizard", "spock" };
        var rnd = new Random();

        int playerScore = 0;
        int agentScore  = 0;
        int winningScore = 3;

        Console.WriteLine("Rock Paper Scissors Lizard Spock");
        Console.WriteLine("Først til 3 point vinder. Skriv 'x' for at afslutte.\n");

        while (playerScore < winningScore && agentScore < winningScore)
        {
            Console.Write("Vælg (rock/paper/scissors/lizard/spock eller 0-4): ");
            string input = Console.ReadLine()?.Trim() ?? "";

            if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                return;


            int p = ParseChoice(input, names);
            if (p < 0)
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.\n");
                continue;
            }

            int a = rnd.Next(0, 5);

            Console.WriteLine($"Du: {names[p]}   |   Agent: {names[a]}");

            if (p == a)
            {
                Console.WriteLine("Uafgjort.\n");
            }
            else if (Beats(p, a))
            {
                playerScore++;
                Console.WriteLine("Du vinder runden.\n");
            }
            else
            {
                agentScore++;
                Console.WriteLine("Agenten vinder runden.\n");
            }

            Console.WriteLine($"Score: Du {playerScore} — Agent {agentScore}\n");
        }

        if (playerScore == winningScore)
            Console.WriteLine("Game over: Du vandt.🏆");
        else
            Console.WriteLine("Game over: Agenten vandt.🥸");
    }


    static int ParseChoice(string input, string[] names)
    {

        if (int.TryParse(input, out int n) && n >= 0 && n < names.Length)
            return n;


        for (int i = 0; i < names.Length; i++)
            if (string.Equals(input, names[i], StringComparison.OrdinalIgnoreCase))
                return i;

        return -1;
    }


    static bool Beats(int x, int y)
    {
        return
            (x == 0 && (y == 2 || y == 3)) || 
            (x == 1 && (y == 0 || y == 4)) || 
            (x == 2 && (y == 1 || y == 3)) || 
            (x == 3 && (y == 1 || y == 4)) || 
            (x == 4 && (y == 0 || y == 2));   
    }
}
