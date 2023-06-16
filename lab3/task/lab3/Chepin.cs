using System.Text.RegularExpressions;

namespace lab3
{
    public static class Chepin
    {
        public enum Group { P, M, C, T };
        public static Dictionary<string, int> Spen
        {
            get
            {
                Dictionary<string, int> res = new();
                foreach (var op in Holstead.operands)
                {
                    if (Regex.IsMatch(op.Key, $"^{REGEX_VARIABLE}$") && op.Key != "true" && op.Key != "false")
                    {
                        res.Add(op.Key, op.Value);
                    }
                }
                return res;
            }
        }
        public static int TotalSpen
        {
            get
            {
                int res = 0;
                foreach (var op in Holstead.operands)
                {
                    if (Regex.IsMatch(op.Key, $"^{REGEX_VARIABLE}$") && op.Key != "true" && op.Key != "false")
                    {
                        res += op.Value;
                    }
                }
                return res;
            }
        }
        static readonly HashSet<string> Controls = new() { "if", "switch", "case", "for" };

        const string REGEX_LITERAL_STRING = @"""(?:\\.|[^""\\])*""";
        const string REGEX_VARIABLE = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b";

        public static float CalculateMetric(Dictionary<string, Group> pairs)
        {
            float res;
            int m, p, c, t;
            

            m = (from tmp in pairs where tmp.Value.Equals(Group.M) select tmp).Count();
            p = (from tmp in pairs where tmp.Value.Equals(Group.P) select tmp).Count();
            c = (from tmp in pairs where tmp.Value.Equals(Group.C) select tmp).Count();
            t = (from tmp in pairs where tmp.Value.Equals(Group.T) select tmp).Count();

            res = p + 2 * m + 3 * c + t / 2;

            return res;
        }

        private static void InitHosltead()
        {
            Holstead.functions = new();
            Holstead.operands = new();
            Holstead.operators = new()
            {
                {"++", 0}, {"--", 0}, {"+", 0 }, {"-", 0 }, {"*", 0 }, {"/", 0 }, {"%", 0 },
                {"&&", 0}, {"||", 0}, {">>", 0}, {"<<", 0}, {"&", 0 }, {"|", 0 }, {"^", 0 },
                {">=", 0}, {"<=", 0}, {"==", 0}, {"!=", 0}, {">", 0 }, {"<", 0 },
                {"!", 0 },
                {"[", 0 }, {"{", 0 },
                {":", 0 },

                {"if",0}, {"else", 0}, {"switch", 0}, {"case", 0}, {"default", 0}, {"for", 0}, {"break", 0}, {"continue", 0}, {"goto", 0}
            };
        }

        public static Dictionary<string, Group> Count(string src, bool isIO)
        {
            InitHosltead();
            Dictionary<string, Group> variables;

            using var sr = new StreamReader(src);
            var ops = new HashSet<string>();
            var spenDict = new Dictionary<string, int>();
            string? line;
            if (isIO)
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("fmt.Scan") || line.Contains("fmt.Fscan") || line.Contains("fmt.Print"))
                    {
                        line = line[(line.IndexOf('(') + 1)..];
                        line = Regex.Replace(line, REGEX_LITERAL_STRING, "");
                        MatchCollection matches = Regex.Matches(line, REGEX_VARIABLE);
                        foreach (Match match in matches.Cast<Match>())
                        {
                            ops.Add(match.Value);
                        }
                    }
                }

            }
            else
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Holstead.Parse(line);
                }
                foreach (var op in Holstead.operands)
                {
                    ops.Add(op.Key);
                }
            }

            variables = FormDictionary(ops);

            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            while ((line = sr.ReadLine()) != null)
            {
                if (!CountC(line, variables))
                {
                    if (!CountP(line, variables))
                    {
                        CountM(line, variables);
                    }
                }
            }
            return variables;
        }

        private static Dictionary<string, Group> FormDictionary(HashSet<string> operands)
        {
            Dictionary<string, Group> res = new();
            foreach (var op in operands)
            {
                if (Regex.IsMatch(op, $"^{REGEX_VARIABLE}$") && op != "true" && op != "false")
                {
                    res.Add(op, Group.T);
                }
            }
            return res;
        }

        private static bool CountP(string codeLine, Dictionary<string, Group> variables)
        {
            int res = 0;
            if (codeLine.Contains("fmt.Scan") || codeLine.Contains("fmt.Fscan"))
            {
                foreach (var op in variables.Keys)
                {
                    string pattern = @"\b" + Regex.Escape(op) + @"\b";
                    if (Regex.IsMatch(codeLine, pattern) && variables[op] != Group.C)
                    {
                        variables[op] = Group.P;
                        res++;
                    }
                }
            }
            else if (codeLine.Contains('='))
            {
                res = 0;
                codeLine = codeLine[..(codeLine.IndexOf('=') - 1)];
                foreach (var op in variables.Keys)
                {
                    string pattern = @"\b" + Regex.Escape(op) + @"\b";
                    if (Regex.IsMatch(codeLine, pattern) && variables[op] == Group.P)
                    {
                        variables[op] = Group.M;
                    }
                }
            }


            if (res != 0)
            {
                return true;
            }
            return false;
        }

        private static bool CountM(string codeLine, Dictionary<string, Group> variables)
        {
            int res = 0;

            if (codeLine.Contains('='))
            {
                codeLine = codeLine[(codeLine.IndexOf('=') + 1)..];
            }


            foreach (var op in variables.Keys)
            {
                string pattern = @"\b" + Regex.Escape(op) + @"\b";
                if (Regex.IsMatch(codeLine, pattern) && variables[op] != Group.C && variables[op] != Group.P)
                {
                    variables[op] = Group.M;
                    res++;
                }
            }

            if (res != 0)
            {
                return true;
            }
            return false;
        }

        private static bool CountC(string codeLine, Dictionary<string, Group> variables)
        {
            int res = 0;

            foreach (var control in Controls)
            {
                if (codeLine.Contains(control))
                {
                    foreach (var op in variables.Keys)
                    {
                        string pattern = @"\b" + Regex.Escape(op) + @"\b";
                        if (Regex.IsMatch(codeLine, pattern))
                        {
                            variables[op] = Group.C;
                            res++;
                        }
                    }
                }
            }

            if (res != 0)
            {
                return true;
            }
            return false;
        }
    }
}
