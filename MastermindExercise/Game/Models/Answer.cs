using MastermindExercise.Game.Static;
using System.Text;

namespace MastermindExercise.Game.Models;
/// <summary>
/// Value object that represents an answer generated for a Mastermind game.
/// </summary>
public record Answer
{
    public string Value { get; }
    public Answer()
    {
        Value = GenerateRandomAnswerString();
    }

    /// <summary>
    /// Generates a string at random representing an answer in a Mastermind game with given rules.
    /// </summary>
    /// <returns>A string representing the generated answer.</returns>
    private string GenerateRandomAnswerString()
    {
        var answerLength = GameRules.ANSWER_LENGTH;
        var minimumDigit = GameRules.MINIMUM_ANSWER_DIGIT;
        var maximumDigit = GameRules.MAXIMUM_ANSWER_DIGIT;
        var randomGenerator = new Random();

        var answerBuilder = new StringBuilder();
        for (int i = 0; i < answerLength; i++)
        {
            var randomDigit = randomGenerator.Next(minimumDigit, maximumDigit + 1);
            answerBuilder.Append(randomDigit);
        }

        return answerBuilder.ToString();
    }
}
