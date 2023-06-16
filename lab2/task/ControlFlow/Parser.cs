using System.Text.RegularExpressions;

namespace ControlFlow
{
    public class Parser
    {
        public int CL;
        public float CL_Relative;
        public int CLI;

        const string REGEX_LITERAL_TRUE = @"\btrue\b";
        const string REGEX_LITERAL_FALSE = @"\bfalse\b";
        const string REGEX_LITERAL_INT = @"\b\d+\b";
        const string REGEX_LITERAL_FLOAT = @"\b\d+\.\d+\b";
        const string REGEX_LITERAL_STRING = @"""(?:\\.|[^""\\])*""";
        const string REGEX_LITERAL_CHAR = @"'\S'";
        const string REGEX_LITERAL_NIL = @"\bnil\b";
        const string REGEX_LITERAL_COMPLEX = @"\b[0-9]*\s*\+\s*[0-9]*i\b";

        readonly Dictionary<string, int> operators = new()
        {
            {":=", 0}, {"=", 0 },
            {"if",0}, {"case", 0}, {"for", 0},
            {"break", 0}, {"continue", 0}, {"goto", 0},
            {@"\+\+", 0}, {"--", 0}
        };

        string[] add(string[] codeLines)
        {
            List<string> lines = new List<string>(codeLines);

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("if") || lines[i].Contains("for") || lines[i].Contains("case"))
                {
                    int ifs = Regex.Count(lines[i], "if");
                    int cases = Regex.Count(lines[i], "case");
                    int fors = Regex.Count(lines[i], "for");
                    int counter = ifs + fors + cases;
                    int ctrOpen = Regex.Count(lines[i], "{");

                    if (counter - ctrOpen != 0)
                    {
                        for (int j = 0; j < counter - ctrOpen; j++)
                        {
                            lines.Insert(i + 1, "");
                            lines[i + 1] = "{ " + lines[i + 1];
                            lines[i + 1] += " } ";
                        }
                    }
                }
            }
            return lines.ToArray();
        }

        void output(string[] code)
        {
            for (int i = 0; i < code.Length; i++)
            {
                Console.WriteLine(code[i]);
            }
        }

        public void Parse(string[] code)
        {
            Clear(code);
            code = code.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            //output(code);
            code = add(code);
            //output(code);
            Count_CL(code);
            Count_Relative_CL(code);
            Count_CLI(code);
        }

        void Count_CLI(string[] codeLines)
        {
            CLI = 0;
            int currNest = -2;
            int pos_open = -1;
            int pos_close = -1;
            for (int i = 0; i < codeLines.Length; i++)
            {
                do
                {
                    pos_open = codeLines[i].IndexOf('{');
                    pos_close = codeLines[i].IndexOf('}');
                    if (codeLines[i].Contains("switch"))
                    {
                        currNest--;
                    }
                    if (codeLines[i].Contains(':'))
                    {
                        currNest++;
                        codeLines[i] = codeLines[i].Replace(':', ' ');
                        /*if (currNest > CLI)
                        {
                            CLI = currNest;
                        }*/
                    }

                    else if (pos_open != -1)
                    {
                        if (pos_close != -1)
                        {
                            if (pos_open < pos_close)
                            {
                                currNest++;
                                codeLines[i] = codeLines[i].Remove(pos_open, 1);
                            }
                            else { }
                        }
                        else
                        {
                            currNest++;
                            codeLines[i] = codeLines[i].Remove(pos_open, 1);
                        }
                        /*if (currNest > CLI)
                        {
                            CLI = currNest;
                        }*/
                    }

                    if (pos_close != -1)
                    {
                        if (pos_open != -1)
                        {
                            if (pos_open > pos_close)
                            {
                                currNest--;
                                codeLines[i] = codeLines[i].Remove(pos_close, 1);
                            }
                            else { }
                        }
                        else
                        {
                            currNest--;
                            codeLines[i] = codeLines[i].Remove(pos_close, 1);
                        }
                    }
                    if (currNest > CLI)
                    {
                        CLI = currNest;
                    }
                } while (pos_open != -1 || pos_close != -1);

            }
        }

        void Count_Relative_CL(string[] codeLines)
        {
            int operatorsNum = CountOperators(codeLines);

            try
            {
                CL_Relative = (float)CL / operatorsNum;
            }
            catch (System.DivideByZeroException)
            {
                CL_Relative = 0;
            }
        }

        int CountOperators(string[] codeLines)
        {
            int counter = 0;
            const string REGEX_OPERATOR_FUNC = @"\b[a-zA-Z_][a-zA-Z0-9_]*\.?[a-zA-Z_][a-zA-Z0-9_]*\(";
            for (int i = 0; i < codeLines.Length; i++)
            {
                foreach (var op in operators)
                {
                    counter += Regex.Count(codeLines[i], op.Key);
                    codeLines[i] = Regex.Replace(codeLines[i], op.Key, " ");
                }
                counter += Regex.Count(codeLines[i], REGEX_OPERATOR_FUNC);
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_OPERATOR_FUNC, "");
            }

            // We do not count "main" function
            return counter - 1;
        }

        void Clear(string[] codeLines)
        {
            int i;
            for (i = 0; !(codeLines[i].Contains("func main")); i++)
            {
                codeLines[i] = "";
            }
            i++;
            for (; i < codeLines.Length; i++)
            {
                codeLines[i] = codeLines[i].Trim();
                codeLines[i] = Regex.Replace(codeLines[i], @"\b\+\b", " ");
                codeLines[i] = Regex.Replace(codeLines[i], @"\b-\b", " ");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_STRING, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_CHAR, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_TRUE, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_FALSE, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_INT, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_FLOAT, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_NIL, "");
                codeLines[i] = Regex.Replace(codeLines[i], REGEX_LITERAL_COMPLEX, "");
                codeLines[i] = Regex.Replace(codeLines[i], ">=", " ");
                codeLines[i] = Regex.Replace(codeLines[i], "<=", " ");
                codeLines[i] = Regex.Replace(codeLines[i], "==", " ");
                codeLines[i] = Regex.Replace(codeLines[i], "!=", " ");
            }
        }

        void Count_CL(string[] codeLines)
        {
            CL = 0;
            for (int i = 0; i < codeLines.Length; i++)
            {
                CL += Regex.Count(codeLines[i], "if");
                CL += Regex.Count(codeLines[i], "case");
                CL += Regex.Count(codeLines[i], "for");
            }
        }
    }
}

