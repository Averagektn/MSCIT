using System.Text.RegularExpressions;

namespace lab3
{
    public class Holstead
    {
        static int par = 0;
        static int comma = 0;
        static bool _skip = false;

        const string REGEX_VARIABLE = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b";
        const string REGEX_VARIABLE_INIT = @"^\b[a-zA-Z_][a-zA-Z0-9_]*\s*:=";

        const string REGEX_LITERAL_TRUE = @"\btrue\b";
        const string REGEX_LITERAL_FALSE = @"\bfalse\b";
        const string REGEX_LITERAL_INT = @"\b\d+\b";
        const string REGEX_LITERAL_FLOAT = @"\b\d+\.\d+\b";
        const string REGEX_LITERAL_STRING = @"""(?:\\.|[^""\\])*""";
        const string REGEX_LITERAL_CHAR = @"'\S'";
        const string REGEX_LITERAL_NIL = @"\bnil\b";
        const string REGEX_LITERAL_COMPLEX = @"\b[0-9]*\s*\+\s*[0-9]*i\b";

        const string REGEX_OPERATOR_FUNC = @"\b[a-zA-Z_][a-zA-Z0-9_]*\.?[a-zA-Z_][a-zA-Z0-9_]*\b";

        static readonly HashSet<string> FCO = new()
        {"if", "else", "switch", "case", "default", "for", "break", "continue", "goto"};

        static readonly Regex operandRegex = new(REGEX_VARIABLE);
        public static Dictionary<string, int> operands = new();
        public static Dictionary<string, int> functions = new();
        public static Dictionary<string, int> operators = new()
        {
        {"++", 0}, {"--", 0}, {"+", 0 }, {"-", 0 }, {"*", 0 }, {"/", 0 }, {"%", 0 },
        {"&&", 0}, {"||", 0}, {">>", 0}, {"<<", 0}, {"&", 0 }, {"|", 0 }, {"^", 0 },
        {">=", 0}, {"<=", 0}, {"==", 0}, {"!=", 0}, {">", 0 }, {"<", 0 },
        {"!", 0 },
        {"[", 0 }, {"{", 0 },
        {":", 0 },

        {"if",0}, {"else", 0}, {"switch", 0}, {"case", 0}, {"default", 0}, {"for", 0}, {"break", 0}, {"continue", 0}, {"goto", 0}
        };

        public static void Pars(string codeLine)
        {
            codeLine = Regex.Replace(codeLine, REGEX_LITERAL_STRING, "");
            codeLine = Regex.Replace(codeLine, REGEX_LITERAL_CHAR, "");
            par += Regex.Count(codeLine, @"\(");
            //comma += Regex.Count(codeLine, @"\,");
        }

        public static void Parse(string codeLine)
        {
            Pars(codeLine);

            codeLine = FindOperands(codeLine);

            if (codeLine != string.Empty)
            {
                FindOperators(codeLine);
            }
            if (operators.ContainsKey("("))
            {
                operators["("] = par;
            }
            else
            {
                operators.Add("(", par);
            }
            foreach (var elem in functions)
            {
                operators["("] -= elem.Value;
            }

            if (operators.ContainsKey(","))
            {
                operators[","] = comma;
            }
            else
            {
                operators.Add(",", comma);
            }
        }

        static void FindOperators(string codeLine)
        {
            if (codeLine.StartsWith("func "))
            {
                functions.Add(codeLine[5..(codeLine.IndexOf('('))], 0);
            }
            else
            {
                codeLine = CountALC(codeLine);
                CountSystemFunc(codeLine);
            }
        }

        static string CountSystemFunc(string codeLine)
        {
            codeLine = codeLine.Trim();
            if (codeLine == string.Empty)
            {
                return codeLine;
            }

            while (Regex.IsMatch(codeLine, REGEX_OPERATOR_FUNC))
            {
                string tmp = Regex.Match(codeLine, REGEX_OPERATOR_FUNC).Value.Trim();
                if (functions.ContainsKey(tmp))
                {
                    functions[tmp] += Regex.Count(codeLine, tmp);
                }
                else
                {
                    functions.Add(tmp, Regex.Count(codeLine, tmp));
                }
                codeLine = Regex.Replace(codeLine, tmp, "");
            }
            return codeLine;
        }

        static string CountUserFunc(string codeLine)
        {
            foreach (var elem in functions)
            {
                int count = Regex.Matches(codeLine, @"\b" + Regex.Escape(elem.Key) + @"\b").Count;
                functions[elem.Key] += count;
                codeLine = codeLine.Replace(elem.Key, "");
            }
            return codeLine;
        }

        static string CountALC(string codeLine)
        {
            foreach (var elem in operators)
            {
                string pattern;
                if (FCO.Contains(elem.Key))
                {
                    pattern = @"\b" + Regex.Escape(elem.Key) + @"\b";
                    operators[elem.Key] += Regex.Count(codeLine, pattern);
                }
                else
                {
                    pattern = Regex.Escape(elem.Key);
                    operators[elem.Key] += Regex.Count(codeLine, pattern);
                }
                codeLine = codeLine.Replace(elem.Key, "");
                codeLine = Regex.Replace(codeLine, pattern, "");
            }
            return codeLine;
        }

        static string FindOperands(string codeLine)
        {
            codeLine = codeLine.Trim();

            if (codeLine.StartsWith("{"))
            {
                operators["{"]++;
                return "";
            }

            if (codeLine.StartsWith("type ") && codeLine.Contains("struct"))
            {
                if (codeLine.Contains("{"))
                {
                    operators["{"]++;
                }
                _skip = true;
            }

            if (codeLine.EndsWith("}"))
            {
                _skip = false;
            }


            if (codeLine.StartsWith("func "))
            {
                return codeLine;
            }

            if (_skip || codeLine == string.Empty || codeLine.StartsWith("import ") || codeLine.StartsWith("package ") ||
                codeLine.StartsWith("type "))
            {
                return "";
            }

            if (codeLine.StartsWith("var ") || codeLine.StartsWith("const ") || Regex.IsMatch(codeLine, REGEX_VARIABLE_INIT) ||
                codeLine.StartsWith("for "))
            {
                if (codeLine.StartsWith("for "))
                {
                    string tmp = codeLine[4..];
                    codeLine = CheckVariables(codeLine[4..]);

                    codeLine = CountVariables(codeLine);
                    codeLine = CountLiterals(codeLine, REGEX_LITERAL_INT);
                    tmp = CountSystemFunc(tmp);
                    CountUserFunc(tmp);
                    operators["for"]++;
                }
                else
                {
                    codeLine = CheckVariables(codeLine);

                }
                codeLine = Regex.Replace(codeLine, REGEX_LITERAL_STRING, "");
                codeLine = Regex.Replace(codeLine, REGEX_LITERAL_CHAR, "");
                codeLine = Regex.Replace(codeLine, REGEX_LITERAL_COMPLEX, "");
                codeLine = CountVariables(codeLine);
                codeLine = CountALC(codeLine);
                codeLine = CountSystemFunc(codeLine);
                CountUserFunc(codeLine);
                codeLine = "";
            }
            else
            {
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_STRING);
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_CHAR);

                codeLine = CountLiterals(codeLine, REGEX_LITERAL_COMPLEX);
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_FLOAT);
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_INT);

                codeLine = CountLiterals(codeLine, REGEX_LITERAL_TRUE);
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_FALSE);
                codeLine = CountLiterals(codeLine, REGEX_LITERAL_NIL);

                codeLine = CountVariables(codeLine);
            }

            return codeLine;
        }

        static string CountLiterals(string codeLine, string REGEX)
        {
            if (codeLine == string.Empty)
            {
                return codeLine;
            }
            string newLine = codeLine;
            string tmp = "";
            while (Regex.IsMatch(codeLine, REGEX))
            {
                tmp = Regex.Match(codeLine, REGEX).Value;
                if (operands.ContainsKey(tmp))
                {
                    operands[tmp]++;
                }
                else
                {
                    operands.Add(tmp, 1);
                }
                codeLine = codeLine[(codeLine.IndexOf(tmp) + tmp.Length)..];
                newLine = newLine.Replace(tmp, "");
            }
            return newLine;
        }

        static string CountVariables(string codeLine)
        {
            string[] variables = new string[operands.Count];
            int ind = 0;

            foreach (var variable in operands)
            {
                variables[ind++] = @"\b" + Regex.Escape(variable.Key) + @"\b";
            }

            for (int i = 0; i < variables.Length; i++)
            {
                string tmp;
                if ((tmp = Regex.Match(codeLine, variables[i]).Value) != string.Empty)
                {
                    operands[tmp] += Regex.Count(codeLine, variables[i]);
                    codeLine = Regex.Replace(codeLine, variables[i], "");
                }
            }
            return codeLine;
        }

        static string FindVariables(string codeLine)
        {
            codeLine = codeLine.TrimStart();
            var tmp = operandRegex.Match(codeLine).Value.Trim();

            if (tmp == string.Empty)
            {
                return tmp;
            }

            if (!operands.ContainsKey(tmp))
            {
                operands.Add(tmp, 0);
            }

            return codeLine;
        }

        static string CheckVariables(string codeLine)
        {
            if (codeLine.StartsWith("var "))
            {
                codeLine = codeLine[3..];
                do
                {
                    codeLine = FindVariables(codeLine);
                    codeLine = codeLine.TrimStart();
                } while (codeLine.StartsWith(","));
            }
            else if (codeLine.StartsWith("const "))
            {
                codeLine = codeLine[5..];
                do
                {
                    codeLine = FindVariables(codeLine);
                    codeLine = codeLine.TrimStart();
                } while (codeLine.StartsWith(","));
            }
            else if (codeLine.Contains(":="))
            {
                FindVariables(codeLine);
                return (codeLine[(codeLine.IndexOf(":=") + 2)..]);
            }
            if (codeLine.Contains('='))
            {
                return codeLine[(codeLine.IndexOf("=") + 1)..];
            }
            else
            {
                return "";
            }
        }
    }
}
