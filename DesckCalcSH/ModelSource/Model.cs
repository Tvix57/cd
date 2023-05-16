using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DesckCalcSH.ModelSource
{
    public class Model {
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

        [DllImport("ModelSource/src/dll/Model2.dll")]
        private unsafe static extern Deque* init_deque();
        [DllImport("ModelSource/src/dll/Model2.dll")]
        private unsafe static extern void convert_to_rpn(Deque* deq, char* str);
        [DllImport("ModelSource/src/dll/Model2.dll")]
        private unsafe static extern double calculation(Deque* deq, double x_value);
        [DllImport("ModelSource/src/dll/Model2.dll")]
        private unsafe static extern void d_free(Deque* deq);

        public Model(string input)
        {
           // 
            var arr = input.ToCharArray();
            unsafe
            {
                fixed (char* charPTR = arr)
                {
                    rpn = init_deque();
                    convert_to_rpn(rpn, charPTR);
                }
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
