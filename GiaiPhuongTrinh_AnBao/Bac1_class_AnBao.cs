using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiPhuongTrinh_AnBao
{
    // nhớ để public class
   public class Bac1_class_AnBao
    {
        private int a, b;
        
        public Bac1_class_AnBao(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public (double,string)Giai_bac1_AnBao()
        {
            double x = 0;
            string kq="";

            if (a == 0)
            {
                    kq = "No sol"; // vô nghiệm
            }
            else
            {
               x = Math.Round(-(double)b / (double)a,1);
            }
        

            return (x,kq);
        }
    }
}
