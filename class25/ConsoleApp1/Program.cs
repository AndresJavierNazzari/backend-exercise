using System;
using System.Collections.Generic;

public class ValidParentheses {
    public static IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        if(string.IsNullOrEmpty(digits)) return result;
        string[] mapping = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        result.Add("");

        foreach(char digit in digits) {
            List<string> tempResult = new List<string>();

            foreach(string prefix in result) {
                string letters = mapping[digit - '2'];
                foreach(char letter in letters) {
                    tempResult.Add(prefix + letter);
                }
            }
            result = tempResult;
        }

        return result;
    }

    public static bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();

        foreach(char c in s) {
            if(c == '(' || c == '[' || c == '{') {
                // If the character is an open bracket, push it onto the stack
                stack.Push(c);
            } else {
                // If the character is a closing bracket, check if it matches the corresponding open bracket
                if(stack.Count == 0) {
                    // No open bracket to match with, invalid
                    return false;
                }

                char openBracket = stack.Pop();

                if(c == ')' && openBracket != '(' ||
                    c == ']' && openBracket != '[' ||
                    c == '}' && openBracket != '{') {
                    // Mismatched brackets, invalid
                    return false;
                }
            }
        }

        // If the stack is empty, all brackets are matched
        return stack.Count == 0;
    }

    public static void Main() {
        // Example usage:
        Console.WriteLine(LetterCombinations("24"));
        Console.WriteLine(LetterCombinations(""));
        Console.WriteLine(LetterCombinations("2"));
    }
}
