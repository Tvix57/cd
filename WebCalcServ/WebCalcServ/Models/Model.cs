using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WebCalcServ.Models;

public class Model : INotifyPropertyChanged
{
    public string RawString
    {
        get { return _raw; }
        set { _raw = value; }
    }
    private string _raw;
    readonly static string s_path = Path.Combine(Directory.GetCurrentDirectory(), ".history.log");
    public List<string> History { get; private set; } = new();
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
    public event PropertyChangedEventHandler? PropertyChanged;
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
            saveHistory(_raw);
            saveHistory(result.ToString());
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

    private void saveHistory(string line)
    {
        using (StreamWriter sw = File.AppendText(s_path))
        {
            sw.WriteLine(line);
            sw.Close();
        }
        History.Add(line);
    }

    private void loadHistory()
    {

        if (File.Exists(s_path))
        {
            using (StreamReader sr = new(s_path))
            {
                string? line;
                while ((line = sr.ReadLine()) is not null)
                {
                    History.Add(line);
                }
                sr.Close();
            }
        }
    }

    public void ClearHistory()
    {
        if (File.Exists(s_path))
        {
            File.Delete(s_path);
            History.Clear();
            OnPropertyChanged();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    

