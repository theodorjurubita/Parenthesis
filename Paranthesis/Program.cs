using System;
using System.Collections.Generic;
using System.Linq;

namespace Paranthesis
{
    public class Program
    {
        private static void Main()
        {
            var openParthesis = new[] {'(', '[', '{'};
            var closedParathesis = new[] {')', ']', '}'};
            var nextClosedparenthesis = new Stack<char>();

            Console.WriteLine("Please enter here the string you would like to validate and then press ENTER:");
            var stringToSearchInto = Console.ReadLine();

            var currentIndexInString = 0;
            var stringBalanced = true;
            if (stringToSearchInto != null)
            {
                foreach (var currentCharacter in stringToSearchInto)
                {
                    if (openParthesis.Contains(currentCharacter))
                    {
                        var index = -1;
                        for (var i = 0; i < openParthesis.Count(); i++)
                        {
                            if (currentCharacter.Equals(openParthesis[i]))
                            {
                                index = i;
                                break;
                            }
                        }

                        nextClosedparenthesis.Push(closedParathesis[index]);
                    }
                    else if (closedParathesis.Contains(currentCharacter))
                    {
                        var startIndex = 0;
                        var length = 7;
                        var subtraction = currentIndexInString + 3 - stringToSearchInto.Length;
                        if (currentIndexInString - 3 > 0)
                        {
                            startIndex = currentIndexInString - 3;
                        }

                        if (subtraction >= 0)
                        {
                            length = length - subtraction - 1;
                        }

                        if (length > stringToSearchInto.Length)
                        {
                            length = stringToSearchInto.Length;
                        }

                        var stringToOutput = stringToSearchInto.Substring(startIndex, length).Replace(' ', '.');
                        try
                        {
                            var necessaryparenthesis = nextClosedparenthesis.Pop();
                            if (!currentCharacter.Equals(necessaryparenthesis))
                            {
                                Console.WriteLine("We have an error here ---->" +
                                                  $" '{stringToOutput}'");
                                stringBalanced = false;
                                break;
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("We have an error here ---->" +
                                              $" '{stringToOutput}'");
                            stringBalanced = false;
                            break;
                        }
                    }

                    currentIndexInString++;
                }
            }
            else
            {
                Console.WriteLine("The string you have entered above is null ! Terminating the program...");
            }

            if (stringBalanced && nextClosedparenthesis.Count.Equals(0))
            {
                Console.WriteLine("The string is balanced!");
            }
            else
            {
                Console.WriteLine("The string is not balanced or you might have not closed all the parenthesis!");
            }
        }
    }
}