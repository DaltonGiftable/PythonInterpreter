using System;

namespace PythonInterpreter
{

    class MainClass
    {
        public static void Main()
        {
            string pythonCodeEx = @"
            def exampleMethod():
            print('I'm a Python Interpreter')

            myDict={
                    'name':'Dalton',
                    'unit':'C# & .NET'
                }
            ";
            Console.WriteLine("Original Python Code:\n" + pythonCodeEx);

            //checking whether the last character is a colon
            bool lastCharacter = LastCharacterIsColon(pythonCodeEx);
            Console.WriteLine("\nLast Character is Colon: " + lastCharacter);

            //adding a tab space after a colon
            string formattedCode = FormatCode(pythonCodeEx);
            Console.WriteLine("\nFormatted Python Code:\n" + formattedCode);

            //validating method syntax if "def" is present
            if (pythonCodeEx.Contains("def"))
            {
                bool isValidSyntax = ValidateMethodSyntax(pythonCodeEx);
                Console.WriteLine("\nMethod Syntax is Valid: " + isValidSyntax);
            }

            //checking if opening curly braces are part of the code
            bool containsDictionary = IsDictionary(pythonCodeEx);
            Console.WriteLine("\nContains Dictionary: " + containsDictionary);
        }

        static bool LastCharacterIsColon(string code)
        {
            return code.TrimEnd().EndsWith(":", StringComparison.Ordinal);
        }

        static string FormatCode(string code)
        {
            string[] lines = code.Split('\n');
            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (LastCharacterIsColon(lines[i]))
                {
                    lines[i + 1] = "    " + lines[i + 1];
                }
            }
            return string.Join("\n", lines);
        }

        static bool ValidateMethodSyntax(string code)
        {
            //validation
            return code.Contains("def ") && code.Contains(":");
        }

        static bool IsDictionary(string code)
        {
            return code.Contains("{") && code.Contains("}");
        }
    }
}