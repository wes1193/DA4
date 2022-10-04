using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public  class LoggingExtensions
    {
         public  void LogMsg2Console(string msg)
        {
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] "+ msg) ;            
            return ;
        }
        
    }
}