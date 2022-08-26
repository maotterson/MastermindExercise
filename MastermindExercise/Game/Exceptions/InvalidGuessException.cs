namespace MastermindExercise.Game.Exceptions;
/// <summary>
/// Exception thrown when a valid Guess can not be created from a given input.
/// </summary>
public class InvalidGuessException : Exception
{
    public InvalidGuessException() : base("Invalid guess.")
    {
    }
}
