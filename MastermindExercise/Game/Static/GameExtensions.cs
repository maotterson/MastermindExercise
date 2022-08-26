using System.Text;

namespace MastermindExercise.Game.Static;
/// <summary>
/// Extension methods used within the Mastermind game.
/// </summary>
public static class GameExtensions
{
    /// <summary>
    /// Extension method to append symbols to displayed result for a given number of times.
    /// </summary>
    /// <param name="resultBuilder">StringBuilder object representing the result.</param>
    /// <param name="numberOfSymbols">Number of symbols to append to result.</param>
    /// <param name="symbol">Symbol that will be appended to the displayed result.</param>
    /// <returns>StringBuilder object representing the result that has had symbols appended to it.</returns>
    public static StringBuilder AppendResultSymbols(this StringBuilder resultBuilder, int numberOfSymbols, char symbol)
    {
        for (int i = 0; i < numberOfSymbols; i++)
        {
            resultBuilder.Append(symbol);
        }
        return resultBuilder;
    }
}
