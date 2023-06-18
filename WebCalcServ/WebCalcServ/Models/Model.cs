using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WebCalcServ.Models;

public class Model
{
    public string RawString
    {
        get { return _raw; }
        set { _raw = value; }
    }
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

    [DllImport("Models/lib/ModelLib2")]
    private unsafe static extern Deque* init_deque();
    [DllImport("Models/lib/ModelLib2")]
    private unsafe static extern void convert_to_rpn(Deque* deq, IntPtr str);
    [DllImport("Models/lib/ModelLib2")]
    private unsafe static extern double calculation(Deque* deq, double x_value);
    [DllImport("Models/lib/ModelLib2")]
    private unsafe static extern void d_free(Deque* deq);

    public double Calculate()
    {

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
    public void PrepareString()
    {
        string new_string = _raw;
        List<string> regexs = new List<string>()
            {
                @"([\+\-\*/\^\(A])([\+])|^[\+]",
                @"([\+\-\*/\^\(A])([\-])|^[\-]"
            };
        List<string> template = new List<string>()
            {
                "B",
                "C"
            };

        new_string = new_string.Replace("acos", "G").Replace("cos", "D").Replace("asin", "H").
                      Replace("sin", "E").Replace("atan", "I").Replace("tan", "F").
                      Replace("sqrt", "J").Replace("ln", "K").Replace("log", "L").
                      Replace("mod", "A");

        for (int i = 0; i < template.Count; ++i)
        {
            new_string = Regex.Replace(new_string, regexs[i], "$1" + template[i]);
        }
        IntPtr ptr = Marshal.StringToHGlobalAnsi(new_string);
        unsafe
        {
            rpn = init_deque();
            convert_to_rpn(rpn, ptr);
        }
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
    

