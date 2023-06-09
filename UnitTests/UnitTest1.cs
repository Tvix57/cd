using DesckCalcSH.ModelSource;
namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(3, 3);
        }
        [Fact]
        public void Test2()
        {
            Model m = new Model();
            m.RawString = "1+2";
            m.PrepareString();
            Assert.Equal(3, m.Calculate());
        }


        [Fact]
        public void Test3()
        {
            string test = "1.23+2.23";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r1 = m.Calculate();
            double cp1 = 1.23 + 2.23;
            Assert.Equal(r1, cp1, 6);
        }
        [Fact]
        public void Test4()
        {
            string test = "1.4356789-2.245";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r2 = m.Calculate();
            double cp2 = 1.4356789 - 2.245;
            Assert.Equal(r2, cp2, 6);
        }
        [Fact]
        public void Test5()
        {
            string test = "100.456";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r3 = m.Calculate();
            double cp3 = 100.456;
            Assert.Equal(r3, cp3, 6);
        }
        [Fact]
        public void Test6()
        {
            string test = "(100.456)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r4 = m.Calculate();
            double cp4 = 100.456;
            Assert.Equal(r4, cp4, 6);
        }
        [Fact]
        public void Test7()
        {
            string test = "2.1/(1.5+1.678)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r5 = m.Calculate();
            double cp5 = 2.1 / (1.5 + 1.678);
            Assert.Equal(r5, cp5, 6);
        }
        [Fact]
        public void Test8()
        {
            string test = "2.7856*(5.345-2.345)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r6 = m.Calculate();
            double cp6 = 2.7856 * (5.345 - 2.345);
            Assert.Equal(r6, cp6, 6);
        }
        [Fact]
        public void Test9()
        {
            string test = "2.25*(5.67-2.543)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r7 = m.Calculate();
            double cp7 = 2.25 * (5.67 - 2.543);
            Assert.Equal(r7, cp7, 6);
        }
        [Fact]
        public void Test10()
        {
            string test = "(2^2)+(2^2)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r8 = m.Calculate();
            double cp8 = Math.Pow(2, 2) + Math.Pow(2, 2);
            Assert.Equal(r8, cp8, 6);
        }
        [Fact]
        public void Test11()
        {
            string test = "(2^2)^(2^2)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r9 = m.Calculate();
            double cp9 = 256;
            Assert.Equal(r9, cp9, 6);
        }
        [Fact]
        public void Test12()
        {
            string test = "0mod2";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r10 = m.Calculate();
            double cp_10 = 0;
            Assert.Equal(r10, cp_10);
        }
        [Fact]
        public void Test13()
        {
            string test = "(sqrt(4))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r11 = m.Calculate();
            double cp11 = 2;
            Assert.Equal(r11, cp11, 6);
        }
        [Fact]
        public void Test14()
        {
            string test = "1/0";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r12 = m.Calculate();
            double cp_error12 = double.PositiveInfinity;
            Assert.Equal(r12, cp_error12);
        }
        [Fact]
        public void Test15()
        {
            string test = "2mod0";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r13 = m.Calculate();
            Assert.True(r13 != r13);
        }
        [Fact]
        public void Test16()
        {
            string test = "((((10.987))))";

            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r14 = m.Calculate();
            double cp14 = 10.987;
            Assert.Equal(r14, cp14, 6);
        }
        [Fact]
        public void Test17()
        {
            string test = "sqrt(9)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r15 = m.Calculate();
            double cp15 = 3;
            Assert.Equal(r15, cp15, 6);
        }
        [Fact]
        public void Test18()
        {
            string test = "10mod5";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r16 = m.Calculate();
            double cp16 = 0;
            Assert.Equal(r16, cp16, 6);
        }
        [Fact]
        public void Test19()
        {
            string test = "log(10)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r17 = m.Calculate();
            double cp17 = 1;
            Assert.Equal(r17, cp17, 6);
        }
        [Fact]
        public void Test20()
        {
            string test = "ln(2.718281828459045)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r18 = m.Calculate();
            double cp18 = 1;
            Assert.Equal(r18, cp18, 6);

        }
        [Fact]
        public void Test21()
        {
            string test = "log(-10)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r19 = m.Calculate();
            Assert.True(r19 != r19);
        }
        [Fact]
        public void Test22()
        {
            string test = "ln(-10)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r20 = m.Calculate();
            Assert.True(r20 != r20);
        }
        [Fact]
        public void Test23()
        {
            string test = "sqrt(-10)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r21 = m.Calculate();
            Assert.True(r21 != r21);
        }
        [Fact]
        public void Test24()
        {
            string test = "(-sqrt(2))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r22 = m.Calculate();
            double cp22 = -1.4142135623731;
            Assert.Equal(r22, cp22, 6);
        }
        [Fact]
        public void Test25()
        {
            string test = "(-sqrt(2";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r22 = m.Calculate();
            double cp22 = -1.4142135623731;
            Assert.Equal(r22, cp22, 6);
        }
        [Fact]
        public void Test26()
        {
            string test = "(-(-(-5)))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r22 = m.Calculate();
            double cp22 = -5;
            Assert.Equal(r22, cp22, 6);
        }
        [Fact]
        public void Test27()
        {
            string test = "(-(-(+(+5))))";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r23 = m.Calculate();
            double cp23 = 5;
            Assert.Equal(r23, cp23, 6);
        }

        [Fact]
        public void Test28()
        {
            string test = "5.25-10.01";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r24 = m.Calculate();
            double cp24 = 5.25 - 10.01;
            Assert.Equal(r24, cp24, 6);
        }

        [Fact]
        public void Test29()
        {
            string test = "3.01*3.02";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 3.01 * 3.02;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test30()
        {
            string test = "9.45/3.26";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r26 = m.Calculate();
            double cp26 = 9.45 / 3.26;
            Assert.Equal(r26, cp26, 6);
        }

        [Fact]
        public void Test31()
        {
            string test = "0*3";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r27 = m.Calculate();
            double cp27 = 0 * 3;
            Assert.Equal(r27, cp27, 6);
        }

        [Fact]
        public void Test32()
        {
            string test = "0^(-1)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r28 = m.Calculate();
            double cp28 = double.PositiveInfinity;
            Assert.Equal(r28, cp28);
        }

        [Fact]
        public void Test33()
        {
            string test = "ln(0)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r29 = m.Calculate();
            double cp29 = double.NegativeInfinity;
            Assert.Equal(r29, cp29);
        }

        [Fact]
        public void Test34()
        {
            string test = "(-0)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r30 = m.Calculate();
            double cp30 = 0;
            Assert.Equal(r30, cp30, 6);
        }

        [Fact]
        public void Test35()
        {
            string test = "(2+2)*6^2";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 144;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test36()
        {
            string test = "2*2+6/3";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 6;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test37()
        {
            string test = "2^(3+4*5)*(2*2)+2+6/3";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString(); //// 2 3 4 5 * + ^ 2 2 * * 2 + 6 3 / +
            double r25 = m.Calculate();
            double cp25 = 33554436;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test38()
        {
            string test = "sin(2)*2^2+6^2*2";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 75.637189707302724;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test39()
        {
            string test = "2.+4";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 6;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test40()
        {
            string test = "sin(2-1)*2^2+6^2*2";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 75.365883939231579;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test41()
        {
            string test = "2.6+4";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 6.6;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test42()
        {
            string test = "0.2+5.6";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 5.8;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test43()
        {
            string test = "2*(2+4)*2";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 24;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test44()
        {
            string test = "(-(-(-5)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test45()
        {
            string test = "(-(-5)))";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test46()
        {
            string test = "(-(-(-5)))*(-(-5))"; //// 5 - - - 5 - - *
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -25;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test47()
        {
            string test = "(-2^(3+4*5)*(2*2)+2+6/3";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -33554428;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test48()
        {
            string test = "(-2^(3+4*5)*(2*2)+2+6/3)";  //// 2 3 4 5 * + ^ 2 2 * * - 2 + 6 3 / +
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -33554428;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test49()
        {
            string test = "tan(2";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Tan(2);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test50()
        {
            string test = "5+3*sin(10)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double standart = 3.367937;
            double res = m.Calculate();
            Assert.Equal(res, standart, 6);
        }


        [Fact]
        public void Test51()
        {
            string test = "56+21-376+(56-22)-(13+10)+(11+(7-(3+2)))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();  /// 56 21 + 376 - 56 22 - + 13 10 + - 11 7 3 2 + - + +
            double standart = -275;
            double res = m.Calculate();
            Assert.Equal(res, standart, 6);
        }


        [Fact]
        public void Test52()
        {
            string test = "(15-5)mod(5^3)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double standart = 10;
            double res = m.Calculate();
            Assert.Equal(res, standart, 6);
        }


        [Fact]
        public void Test53()
        {
            string test = "tan(10)*((5-3)*ln(4)-log(8))*2+7";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double standart = 9.4242194938376841;
            double res = m.Calculate();
            Assert.Equal(res, standart, 6);
        }


        [Fact]
        public void Test54()
        {
            string test = "12+0.0";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 12;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test55()
        {
            string test = "(-12+2.34";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -12 + 2.34;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test56()
        {
            string test = "100+(-234.";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 100 + -234;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test57()
        {
            string test = "9+(8+6)+1+(3+9)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 9 + (8 + 6) + 1 + (3 + 9);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test58()
        {
            string test = "21892683+(-60607476)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 21892683 + (-60607476);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test59()
        {
            string test = "416-434-(190-490)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 416 - 434 - (190 - 490);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test60()
        {
            string test = "107-(928-166-438)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 107 - (928 - 166 - 438);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test61()
        {
            string test = "(399-985)-63-352";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (399 - 985) - 63 - 352;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test62()
        {
            string test = "10.7-(0.98-166-438)";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 10.7 - (0.98 - 166 - 438);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test63()
        {
            string test = "10-(-928-16.6-438)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 10 - (-928 - 16.6 - 438);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test64()
        {
            string test = "399-(985-(63-352))";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 399 - (985 - (63 - 352));
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test65()
        {
            string test = "317-141-(118-695)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 317 - 141 - (118 - 695);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test66()
        {
            string test = "(3879294-5309583)-(3744311-2467480-4787696)-3324295";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString(); //// 3879294 5309583 - 3744311 2467480 - 4787696 - - 3324295 -
            double r25 = m.Calculate();
            double cp25 = (3879294 - 5309583) - (3744311 - 2467480 - 4787696) - 3324295;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test67()
        {
            string test = "(-0.38227*7856.815-0.)*(7759.3*(-51507.96))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (-0.38227 * 7856.815 - 0) * (7759.3 * -51507.96);
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test70()
        {
            string test = "(91.226*(-51.9))*(7.797*85.481)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (91.226 * -51.9) * (7.797 * 85.481);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test71()
        {
            string test = "(-25.9655*(-(-626.93*508.657)*(85.108*400.162))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -25.9655 * -(-626.93 * 508.657) * (85.108 * 400.162);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test72()
        {
            string test = "(-(-356.081*4598.63)*803.928*(70.592*0.1569)*(-36.1566)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -(-356.081 * 4598.63) * 803.928 * (70.592 * .1569) * -36.1566;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test73()
        {
            string test = "(-(-356.081*4598.63)*803.928*(70.592*(-0.1569))*(-36.1566";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -(-356.081 * 4598.63) * 803.928 * (70.592 * -.1569) * -36.1566;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test74()
        {
            string test = "(432/9.57/321)/(76.4/78.0)/(-35.8";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (432 / 9.57 / 321) / (76.4 / 78.0) / -35.8;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test75()
        {
            string test = "43.1/(495.5/711.)/28.7";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();  //// 43.1 495.5 711. / / 28.7 /
            double r25 = m.Calculate();
            double cp25 = 43.1 / (495.5 / 711) / 28.7;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test76()
        {
            string test = "(0.5757/23.3/704.1/(-31.27)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (.5757 / 23.3 / 704.1 / -31.27);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test77()
        {
            string test = "(1.375/930.0)/223.3/80.41";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (1.375 / 930.0) / 223.3 / 80.41;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test78()
        {
            string test = "4.091/(23.04/1.075/42.8)";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 4.091 / (23.04 / 1.075 / 42.8);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test79()
        {
            string test = "(7068./33.59/9.13-4)/43.5";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (7068 / 33.59 / 9.13 - 4) / 43.5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test80()
        {
            string test = "97.66/(705.2/2619.)/59.59";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString(); /// 97.66 705.2 2619. / / 59.59 /
            double r25 = m.Calculate();
            double cp25 = 97.66 / (705.2 / 2619) / 59.59;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test81()
        {
            string test = "97.66/(705.2/2619.)/(-59.59";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString(); /// "97.66/(705.2/2619.)/(-59.59
            double r25 = m.Calculate();
            double cp25 = 97.66 / (705.2 / 2619) / -59.59;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test82()
        {
            string test = "8^(3^4)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Pow(8, Math.Pow(3, 4));
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test83()
        {
            string test = "(2^9)^1";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Pow(Math.Pow(2, 9), 1);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test84()
        {
            string test = "65991.*(0.5312*5213.)*(0.9450*897643)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 65991 * (0.5312 * 5213) * (0.9450 * 897643);
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test86()
        {
            string test = "5^(3^3)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (Math.Pow(5, Math.Pow(3, 3)));
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test87()
        {
            string test = "(4^10)^3";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Pow(Math.Pow(4, 10), 3);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test88()
        {
            string test = "(8^2)^8";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Pow(Math.Pow(8, 2), 8);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test89()
        {
            string test = "(4^10)^3";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Pow(Math.Pow(4, 10), 3);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test90()
        {
            string test = "(45.34mod55.23)mod79.4";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (45.34 % 55.23) % 79.4;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test100()
        {
            string test = "357.34mod(952.34mod712.12)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 357.34 % (952.34 % 712.12); //
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test102()
        {
            string test = "499.23mod(1.8mod0.27)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 499.23 % (1.8 % 0.27);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test103()
        {
            string test = "(72*533+(-615))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = (72 * 533 + -615);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test104()
        {
            string test = "826-(738-243))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 826 - (738 - +243);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test105()
        {
            string test = "17mod863*(-173";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString(); /// 17 863 173 unar * %
            double r25 = m.Calculate();
            double cp25 = -2941;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test106()
        {
            string test = "40.34*(-0.424/(-252)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 40.34 * (-0.424 / -252);
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test108()
        {
            string test = "acos(0.1)*sin(1)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Acos(0.1) * Math.Sin(1);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test109()
        {
            string test = "cos(-1.34)+tan(2.0)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Cos(-1.34) + Math.Tan(2.0);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test110()
        {
            string test = "(-(asin(0.3465346)/2)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -(Math.Asin(+0.3465346) / 2);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test111()
        {
            string test = "atan(1.302+0.5)-1.2";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Atan(1.302 + 0.5) - 1.2;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test112()
        {
            string test = "123modsqrt(100)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 123 % Math.Sqrt(100);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test113()
        {
            string test = "ln(256-3)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Log(256 - 3);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test114()
        {
            string test = "log(123.345)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = Math.Log10(123.345);
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test115()
        {
            string test = "(-sin(13.4+atan(7)*56.4-17/4)*(cos(tan(2^4)))";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -Math.Sin(13.4 + Math.Atan(7) * 56.4 - 17 / 4.0) * (Math.Cos(Math.Tan(Math.Pow(2, 4))));
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test116()
        {
            string test = "34.4+34/3";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 45.7333333333333333;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test117()
        {
            string test = "34/0.4+5";
            Model m = new Model(); 
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 34 / 0.4 + 5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test118()
        {
            string test = "(-(-34))+5";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 34 + 5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test119()
        {
            string test = "34*(-5";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 34 * -5;
            Assert.Equal(r25, cp25, 6);
        }


        [Fact]
        public void Test120()
        {
            string test = "(-(2*2)";
            Model m = new Model(); 
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -4;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test121()
        {
            string test = "(-sin(1)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -Math.Sin(1);
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test122()
        {
            string test = "2mod(3)";
            Model m = new Model();
            m.RawString = test; 
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 2 % 3;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test123()
        {
            string test = "2)+2+2";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = 6;
            Assert.Equal(r25, cp25, 6);
        }

        [Fact]
        public void Test124()
        {
            string test = "2+(-3)";
            Model m = new Model();
            m.RawString = test;
            m.PrepareString();
            double r25 = m.Calculate();
            double cp25 = -1;
            Assert.Equal(r25, cp25, 6);
        }
    }
}