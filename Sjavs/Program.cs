using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sjavs.Enums;

namespace Sjavs
{
    class Program
    {      
        static void Main(string[] args)
        {
            GameLogic g = new GameLogic();
            g.Play();          
        } 
    }
}
