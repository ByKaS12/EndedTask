using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Mocks
{
   static public class GenerateCodeProduct
    {
        public static char[] X = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
       public static char[] Y = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };

        static public  int RandomizeDigit()
        {
            Random random = new Random();
            int i = random.Next(0, 9);
            return i;
        }
        static public int RandomizeSymbol()
        {
            Random random = new Random();
            int i = random.Next(0, 25);
            return i;
        }
        static public string GenerateCode()
        {
            string GeneratedCode ="";
            
            
            for(int i = 0;i < 12; i++)
            {
                if(i== 2 || i==7)
                {
                    GeneratedCode += '-';

                }else if(GeneratedCode.Length==8 || GeneratedCode.Length == 9)
                {
                    GeneratedCode += Y[RandomizeSymbol()];
                }
                else
                {
                    GeneratedCode += X[RandomizeDigit()];

                }
                

                
            }
            return GeneratedCode;
        }
    }
}
