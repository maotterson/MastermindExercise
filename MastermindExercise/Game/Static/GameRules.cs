namespace MastermindExercise.Game.Static;
/// <summary>
/// Static class of constants to store the constraints/rules for the Mastermind game.
/// </summary>
public static class GameRules
{
    public const short ANSWER_LENGTH = 4;
    public const short MINIMUM_ANSWER_DIGIT = 1;
    public const short MAXIMUM_ANSWER_DIGIT = 6;
    public const short TOTAL_GUESS_ATTEMPTS = 10;
    public const char MATCH_SYMBOL = '+';
    public const char PARTIAL_MATCH_SYMBOL = '-';
}
