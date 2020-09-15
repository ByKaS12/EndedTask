using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndedTask.Mocks
{
   static public class GenerateNumberOrder
    {
        static public int generate()
        { int i = 0;
            string NumberOrder = "";
            while(i != 4){
                NumberOrder +=new Random().Next(1,9);
                i++;
            }
            return Convert.ToInt32(NumberOrder);
        }

    }
}
