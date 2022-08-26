namespace MastermindExercise.Game.Static;
/// <summary>
/// Static class used to determine whether a guess is valid.
/// </summary>
public static class GuessValidator
{
    /// <summary>
    /// Validates whether a given string input is a valid guess.
    /// </summary>
    /// <param name="guess">String input to be parsed into a Guess object.</param>
    /// <returns></returns>
    public static bool ValidateGuess(string? guess)
    {
        if (string.IsNullOrEmpty(guess) ||
            !IsValidGuessLength(guess) ||
            !IsWithinValidGuessRange(guess))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Validates whether the guess is of valid length.
    /// </summary>
    /// <param name="guess">String input to be validated.</param>
    /// <returns>Whether the input is a valid length.</returns>
    private static bool IsValidGuessLength(string guess)
    {
        var guessLength = guess.Length;
        var expectedLength = GameRules.ANSWER_LENGTH;

        if (guessLength != expectedLength)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Validates whether each digit of a guess is within the valid range.
    /// </summary>
    /// <param name="guess">String input to be validated.</param>
    /// <returns>Whether each digit of the input is within the valid range.</returns>
    private static bool IsWithinValidGuessRange(string guess)
    {
        foreach (var digit in guess)
        {
            if (!IsValidDigit(digit))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Validates whether a given digit character is a number within the valid range.
    /// </summary>
    /// <param name="digitChar">Character digit to be validated.</param>
    /// <returns>Whether given character digit is a number within the valid range.</returns>
    private static bool IsValidDigit(char digitChar)
    {
        var isValidDigit = short.TryParse(digitChar.ToString(), out short digitAsNumber);
        if (!isValidDigit || !IsWithinValidDigitRange(digitAsNumber))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Validates whether a given digit is within the valid range.
    /// </summary>
    /// <param name="digitChar">Digit to be validated.</param>
    /// <returns>Whether given digit is within the valid range.</returns>
    private static bool IsWithinValidDigitRange(short digit)
    {
        var minimumAllowed = GameRules.MINIMUM_ANSWER_DIGIT;
        var maximumAllowed = GameRules.MAXIMUM_ANSWER_DIGIT;

        if (digit < minimumAllowed || digit > maximumAllowed)
        {
            return false;
        }

        return true;
    }
}
