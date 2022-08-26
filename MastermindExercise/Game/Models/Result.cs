using MastermindExercise.Game.Static;
using System.Text;

namespace MastermindExercise.Game.Models;
/// <summary>
/// Object representing the result of a Mastermind guess.
/// </summary>
public class Result
{
    public string Value { get; }
    public bool IsSolved { get; }

    /// <summary>
    /// Instantiates a new Result for given Guess and Answer value objects.
    /// </summary>
    /// <param name="guess">Object representing the user's guess</param>
    /// <param name="answer">Object representing the generated answer</param>
    public Result(Guess guess, Answer answer)
    {
        IsSolved = DetermineIsSolved(guess, answer);
        Value = DetermineResultString(guess, answer);
    }
    /// <summary>
    /// Determines whether the answer has been solved via a given guess.
    /// </summary>
    /// <param name="guess">Object representing the user's guess</param>
    /// <param name="answer">Object representing the generated answer</param>
    /// <returns></returns>
    private bool DetermineIsSolved(Guess guess, Answer answer)
    {
        var isSolved = guess.Value == answer.Value;
        return isSolved;
    }

    /// <summary>
    /// Determines the resulting string that represents the result of a guess.
    /// </summary>
    /// <param name="guess">Object representing the user's guess</param>
    /// <param name="answer">Object representing the generated answer</param>
    /// <returns>The resulting string that represents a result.</returns>
    private string DetermineResultString(Guess guess, Answer answer)
    {
        var exactMatches = GetExactMatches(guess,answer);
        var partialMatches = GetPartialMatches(guess, answer);
        var resultBuilder = new StringBuilder();

        resultBuilder.AppendResultSymbols(exactMatches, GameRules.MATCH_SYMBOL);
        resultBuilder.AppendResultSymbols(partialMatches, GameRules.PARTIAL_MATCH_SYMBOL);

        return resultBuilder.ToString();
    }

    /// <summary>
    /// Determines the number of exact matches for a guess.
    /// </summary>
    /// <param name="guess">Object representing the user's guess</param>
    /// <param name="answer">Object representing the generated answer</param>
    /// <returns>The number of exact matches.</returns>
    private int GetExactMatches(Guess guess, Answer answer)
    {
        var matches = 0;
        var answerString = answer.Value;
        var guessString = guess.Value;

        for (int i = 0; i < answerString.Length; i++)
        {
            var answerDigit = answerString[i];
            var guessDigit = guessString[i];

            if (answerDigit == guessDigit)
            {
                matches++;
            }
        }
        return matches;
    }
    /// <summary>
    /// Determines the number of partial matches for a guess.
    /// </summary>
    /// <param name="guess">Object representing the user's guess</param>
    /// <param name="answer">Object representing the generated answer</param>
    /// <returns>The number of partial matches.</returns>
    private int GetPartialMatches(Guess guess, Answer answer)
    {
        var partialMatches = 0;
        var answerString = answer.Value;
        var guessString = guess.Value;
        var remainingAnswerStack = new Stack<char>();
        var remainingGuessList = new List<char>();

        // Loop to create answer and guess collections of remaining non-matched digits at the same index
        for (int i = 0; i < answerString.Length; i++)
        {
            var answerDigit = answerString[i];
            var guessDigit = guessString[i];

            if (answerDigit != guessDigit)
            {
                remainingAnswerStack.Push(answerDigit);
                remainingGuessList.Add(guessDigit);
            }
        }

        // Checks whether each remaining answer digit is contained in the collection of remaining unmatched guess digits
        while (remainingAnswerStack.Any())
        {
            var currentAnswerDigit = remainingAnswerStack.Pop();
            if (remainingGuessList.Contains(currentAnswerDigit))
            {
                partialMatches++;
                remainingGuessList.Remove(currentAnswerDigit);
            }
        }

        return partialMatches;
    }



}
