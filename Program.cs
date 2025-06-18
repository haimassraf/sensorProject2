using System;
using InvestigationGame;
public class Program
{
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();
        game.StartGame();
        Console.ReadLine();
    }
}