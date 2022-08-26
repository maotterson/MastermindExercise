namespace MastermindExercise.Game.Static;
/// <summary>
/// Static class of constants representing common console outputs throughout a Mastermind game.
/// </summary>
public static class ConsoleOutputs
{
    public const string INITIAL_HEADER =
        "MASTERMIND GAME\n" +
        "===============\n" +
        "by Mark Otterson\n\n";
    public const string GUESS_PROMPT = "GUESS #";
    public const string INVALID_GUESS_PROMPT = "Invalid guess. Please try again.";
    public const string WIN_MESSAGE = "Congratulations, you correctly guessed";
    public const string LOSE_MESSAGE = "Sorry, you have run out of guesses! The correct answer was";
}
