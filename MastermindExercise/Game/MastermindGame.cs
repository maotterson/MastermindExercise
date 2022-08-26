using MastermindExercise.Game.Models;
using MastermindExercise.Game.Static;

namespace MastermindExercise.Game;
/// <summary>
/// Class that dictates the actions taken throughout a Mastermind game.
/// </summary>
public class MastermindGame
{
    public bool IsSolved { get; private set; } = false;
    public bool IsRunning { get; private set; } = true;
    public short CurrentGuess { get; private set; } = 1;
    public Answer Answer { get; }

    public MastermindGame(Answer answer)
    {
        Answer = answer;
    }

    /// <summary>
    /// Creates a new Guess object from user input.
    /// </summary>
    /// <param name="input">Input to be evaluated as a guess.</param>
    /// <returns>A valid Mastermind Guess object.</returns>
    public Guess MakeGuess(string? input)
    {
        var guess = new Guess(input);
        CurrentGuess++;
        return guess;
    }

    /// <summary>
    /// Processes a guess object into a result and updates the game state.
    /// </summary>
    /// <param name="guess">A Mastermind guess object to be checked.</param>
    /// <returns>A Mastermind Result object.</returns>
    public Result ProcessGuess(Guess guess)
    {
        var result = new Result(guess, Answer);
        if (result.IsSolved || OutOfGuesses())
        {
            IsRunning = false;
            IsSolved = result.IsSolved;
        }
        return result;
    }
    /// <summary>
    /// Determines whether there are any remaining guesses.
    /// </summary>
    /// <returns>Whether there are any remaining guesses.</returns>
    private bool OutOfGuesses()
    {
        var isOutOfGuesses = CurrentGuess > GameRules.TOTAL_GUESS_ATTEMPTS;
        return isOutOfGuesses;
    }
}
