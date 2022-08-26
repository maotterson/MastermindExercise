using MastermindExercise.Game.Exceptions;
using MastermindExercise.Game.Static;

namespace MastermindExercise.Game.Models;
/// <summary>
/// Value object that represents a guess made by the user during a Mastermind game.
/// </summary>
public record Guess
{
    public string Value { get; }

    /// <summary>
    /// Instantiates a new Guess value object from a given input.
    /// </summary>
    /// <param name="guess">String input to be parsed into a Guess.</param>
    /// <exception cref="InvalidGuessException">Exception thrown when an invalid input is provided.</exception>
    public Guess(string? guess)
    {
        var isValidGuess = GuessValidator.ValidateGuess(guess);
        if (!isValidGuess)
        {
            throw new InvalidGuessException();
        }
        Value = guess!;
    }
}
