using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndedTask.Mocks;

namespace EndedTask.Mocks
{
  static  public class GenerateCodeClient
    {

        static public string Generate()
        {
            string Code = "";
            
            DateTime Year = DateTime.Today;
            for (int i = 0; Code.Length!=9; i++)
            {
                if (i < 4) {
                    Code += GenerateCodeProduct.X[GenerateCodeProduct.RandomizeDigit()];
                }
                else if (i == 4) { 
                    Code += '-';
                }
                else
                {
                    Code += Year.Year.ToString();
                    break;
                }
            }

            return Code;
        }
    }
}
