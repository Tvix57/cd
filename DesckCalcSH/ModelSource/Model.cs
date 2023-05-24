using LiveChartsCore;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DesckCalcSH.ModelSource
{
    public class Model {
        public string RawString { get { return _raw; } }
        private string _raw;
        [StructLayout(LayoutKind.Explicit)]
        struct token_t
        {
            [FieldOffset(0)]
            int operation;
            [FieldOffset(0)]
            double number;
        }
        enum e_type_t
        {
            NUMBER,
            OPERATION,
            VARIABLE
        }
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct lexeme_t
        {
            e_type_t type;
            token_t token;
            lexeme_t* next;
            lexeme_t* prev;
        }
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct Deque
        {
            unsafe lexeme_t* head;
            unsafe lexeme_t* tail;
        }
        private unsafe Deque* rpn = null;

        [DllImport("ModelSource/src/dll/ModelLib2.dll")]
        private unsafe static extern Deque* init_deque();
        [DllImport("ModelSource/src/dll/ModelLib2.dll")]
        private unsafe static extern void convert_to_rpn(Deque* deq, IntPtr str);
        [DllImport("ModelSource/src/dll/ModelLib2.dll")]
        private unsafe static extern double calculation(Deque* deq, double x_value);
        [DllImport("ModelSource/src/dll/ModelLib2.dll")]
        private unsafe static extern void d_free(Deque* deq);

        public Model(string input)
        {
            _raw = input;
            List<Regex> regexs = new List<Regex>() 
            { 
                new Regex( @"([\+\-\*/\^\(A])([\+])"),
                new Regex( @"([\+\-\*/\^\(A])([\-])"),
                new Regex( @"^[\+]"),
                new Regex( @"^[\-]")//////проверить регулярки
            };
            List<string> template = new List<string>()
            {
                "\\1B",
                "\\1C",
                "B",
                "C"
            };

            input = input.Replace("acos", "G").Replace("cos", "D").Replace("asin", "H").
                          Replace("sin", "E").Replace("atan", "I").Replace("tan", "F").
                          Replace("sqrt", "J").Replace("ln", "K").Replace("log", "L").
                          Replace("mod", "A");

            for (int i = 0; i < regexs.Count; ++i)
            {
                input = regexs[i].Replace(input, template[i]);
            }
            IntPtr ptr = Marshal.StringToHGlobalAnsi(input);
            unsafe {
                rpn = init_deque();
                convert_to_rpn(rpn, ptr);
            }
        }
        public double Calculate() {
            double result = double.NaN;
            unsafe
            {
                result = calculation(rpn, 0.0);
            }
            return result;
        }
        public double Calculate(double x_value)
        {
            double result = double.NaN;
            unsafe
            {
                result = calculation(rpn, x_value);
            }
            return result;
        }

        ~Model() 
        {
            unsafe
            {
                if (rpn != null)
                {
                    d_free(rpn);
                }
            }
        }
    }
    
}
