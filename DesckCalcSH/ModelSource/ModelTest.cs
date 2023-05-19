using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DesckCalcSH.ModelSource
{
    public class ModelTest {
/*        [StructLayout(LayoutKind.Explicit)]
        struct token_test
        {
            [FieldOffset(0)]
            int operation;
            [FieldOffset(0)]
            double number;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe struct DequeTest
        {
            unsafe int* head;
            unsafe int* tail;
        }
        private unsafe DequeTest* rpn = null;

        [DllImport("ModelSource/src/dll/ModelTest.dll")]
        private unsafe static extern DequeTest* init_deque();*/
        [DllImport("ModelSource/src/dll/ModelTest.dll")]
        private unsafe static extern double calculation(double deq, double x_value);


        public ModelTest()
        {

        }
        public double Calculate(int x, int y) {
            double result = double.NaN;
            unsafe
            {
                result = calculation(x, y);
            }
            return result;
        }
    }
    
}
