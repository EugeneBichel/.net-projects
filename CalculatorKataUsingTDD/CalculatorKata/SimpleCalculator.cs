using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorKata
{
    public class SimpleCalculator
    {
        private readonly int MaxNumber = 1000;
        private readonly string newLineDelimiter = Environment.NewLine;
        private const int IgnoredResult = -1;

        public int Sum(string delimitedOperands)
        {
            if (string.IsNullOrEmpty(delimitedOperands))
                return 0;

            int singleOperand = 0;
            if (int.TryParse(delimitedOperands, out singleOperand) == true)
            {
                if (singleOperand < 0)
                    throw new ArgumentException($"{singleOperand} operand should be >= 0");

                if (singleOperand > MaxNumber)
                    return IgnoredResult;

                return singleOperand;
            }

            const string markDelimiter = "//";
            

            if (delimitedOperands.Contains(markDelimiter))
            {
                var inputStringParts = delimitedOperands.Split(new string[] { markDelimiter },
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputStringParts.Length > 1)
                {
                    var delimiters = inputStringParts.Select(GetDelimiter).ToList();

                    var delimitersLength = 0;
                    for (int i = 0; i < delimiters.Count; i++)
                    {
                        var len = delimiters[i].Length;

                        if (len == 1)
                        {
                            delimitersLength += len + 2;
                        }
                        else
                        {
                            delimitersLength += len + 4;
                        }
                        
                    }

                    return SumCalculation(delimitedOperands.Substring(delimitersLength), delimiters);
                }
                else
                {
                    string multiDelimiter = GetMultiDelimiter(inputStringParts[0]);

                    if (string.IsNullOrEmpty(multiDelimiter))
                    {
                        var delimiter = delimitedOperands.Substring(2, 1);

                        return SumCalculation(delimitedOperands.Substring(3), delimiter);
                    }
                    if (!string.IsNullOrEmpty(multiDelimiter))
                    {
                        var delimiter = multiDelimiter;

                        return SumCalculation(delimitedOperands.Substring(1 + 2 + delimiter.Length + 1), delimiter);
                    }
                }
            }

            const string commaDelimiter = ",";
            return SumCalculation(delimitedOperands, commaDelimiter);
        }

        private string GetDelimiter(string delimiter)
        {
            var sbMultuDelimiter = new StringBuilder();

            if (delimiter[0] == '[')
            {
                var i = 0;

                while (true)
                {
                    i++;
                    if (delimiter[i] == ']')
                        break;

                    sbMultuDelimiter.Append(delimiter[i]);
                }

                return sbMultuDelimiter.ToString();
            }

            return delimiter;
        }

        private string GetMultiDelimiter(string delimitedOperands)
        {
            var sbMultuDelimiter = new StringBuilder();

            if (delimitedOperands[0] == '[')
            {
                var i = 0;

                while(true)
                {
                    i++;
                    if(delimitedOperands[i] == ']')
                        break;

                    sbMultuDelimiter.Append(delimitedOperands[i]);
                }

                return sbMultuDelimiter.ToString();
            }

            return string.Empty;
        }

        private int SumCalculation(string delimitedOperands, string delimiter)
        {
            if (delimitedOperands.Contains(delimiter) && !delimitedOperands.Contains(newLineDelimiter))
            {
                string[] operands = delimitedOperands.Split(new string[] { delimiter }, StringSplitOptions.None);

                if (operands.Length == 2)
                {
                    int operand1 = Convert.ToInt32(operands[0]);
                    int operand2 = Convert.ToInt32(operands[1]);

                    if (operand1 < 0)
                        throw new ArgumentException($"{operand1} operand should be >= 0");

                    if (operand2 < 0)
                        throw new ArgumentException($"{operand2} operand should be >= 0");

                    if (operand1 > MaxNumber)
                        return IgnoredResult;

                    if (operand2 > MaxNumber)
                        return IgnoredResult;

                    return operand1 + operand2;
                }
            }

            if (delimitedOperands.Contains(newLineDelimiter) && !delimitedOperands.Contains(delimiter))
            {
                string[] operands = delimitedOperands.Split(new string[] { newLineDelimiter }, StringSplitOptions.None);

                if (operands.Length == 2)
                {
                    int operand1 = Convert.ToInt32(operands[0]);
                    int operand2 = Convert.ToInt32(operands[1]);

                    if (operand1 < 0)
                        throw new ArgumentException($"{operand1} operand should be >= 0");

                    if (operand2 < 0)
                        throw new ArgumentException($"{operand2} operand should be >= 0");

                    if (operand1 > MaxNumber)
                        return IgnoredResult;

                    if (operand2 > MaxNumber)
                        return IgnoredResult;

                    return operand1 + operand2;
                }
            }

            if (delimitedOperands.Contains(newLineDelimiter) && delimitedOperands.Contains(delimiter))
            {
                string[] operands = delimitedOperands.Split(new string[] { delimiter, newLineDelimiter }, StringSplitOptions.None);

                if (operands.Length == 3)
                {
                    int operand1 = Convert.ToInt32(operands[0]);
                    int operand2 = Convert.ToInt32(operands[1]);
                    int operand3 = Convert.ToInt32(operands[2]);


                    if (operand1 < 0)
                        throw new ArgumentException($"{operand1} operand should be >= 0");

                    if (operand2 < 0)
                        throw new ArgumentException($"{operand2} operand should be >= 0");

                    if (operand3 < 0)
                        throw new ArgumentException($"{operand2} operand should be >= 0");

                    if (operand1 > MaxNumber)
                        return IgnoredResult;

                    if (operand2 > MaxNumber)
                        return IgnoredResult;

                    if (operand3 > MaxNumber)
                        return IgnoredResult;

                    return operand1 + operand2 + operand3;
                }
            }

            return IgnoredResult;
        }

        private int SumCalculation(string delimitedOperands, IEnumerable<string> delimiters)
        {
            string[] operands = delimitedOperands.Split(delimiters.ToArray(), StringSplitOptions.None);

            int sum = 0;

            for (var i=0;i<operands.Length;i++)
            {
               var operand = Convert.ToInt32(operands[i]);

                if (operand < 0)
                    throw new ArgumentException($"{operand} operand should be >= 0");

                if (operand > MaxNumber)
                    return IgnoredResult;

                sum += operand;
            }

            return sum;
        }
    }
}
