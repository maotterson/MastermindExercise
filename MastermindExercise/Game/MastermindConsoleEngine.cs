using MastermindExercise.Game.Exceptions;
using MastermindExercise.Game.Models;
using MastermindExercise.Game.Static;

namespace MastermindExercise.Game;

/// <summary>
/// Singleton class that is used to run the Mastermind game within a console environment. 
/// </summary>
public class MastermindConsoleEngine
{
    public static MastermindConsoleEngine? Instance { get; private set; }
    private MastermindGame game;
    private MastermindConsoleEngine()
    {
        var answer = new Answer();
        game = new MastermindGame(answer);
    }
    /// <summary>
    /// Runs the mastermind game engine, ensuring there is one such instance running and dictating the flow of the game from beginning to end.
    /// </summary>
    public static void Run()
    {
        if(Instance is null)
        {
            Instance = new MastermindConsoleEngine();
        }

        Instance.DisplayHeader();
        Instance.StartGame();
        Instance.DisplayResult();
    }
    /// <summary>
    /// Invokes the Mastermind game loop to continue while the game is in a running state.
    /// </summary>
    private void StartGame()
    {
        while (game.IsRunning)
        {
            try
            {
                Console.Write($"{ConsoleOutputs.GUESS_PROMPT}{game.CurrentGuess}: ");
                var input = Console.ReadLine();
                var guess = game.MakeGuess(input);
                var result = game.ProcessGuess(guess);
                Console.WriteLine(result.Value);
            }
            catch (InvalidGuessException)
            {
                Console.WriteLine(ConsoleOutputs.INVALID_GUESS_PROMPT);
            }
        }
    }

    /// <summary>
    /// Displays the initial user-friendly header to the console.
    /// </summary>
    private void DisplayHeader()
    {
        Console.WriteLine(ConsoleOutputs.INITIAL_HEADER);
    }

    /// <summary>
    /// Displays the result of the game after the game is no longer running.
    /// </summary>
    private void DisplayResult()
    {
        if (game.IsSolved)
        {
            Console.WriteLine($"{ConsoleOutputs.WIN_MESSAGE} {game.Answer.Value}!");
        }
        else
        {
            Console.WriteLine($"{ConsoleOutputs.LOSE_MESSAGE} {game.Answer.Value}.");
        }
    }
}
