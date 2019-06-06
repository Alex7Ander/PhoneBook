using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class CurrentDirrectoryReturner
    {
        public static string getDirrectory()
        {
            var directory = Directory.GetCurrentDirectory();
            if (directory != null)
            {
                return directory;
            }
            else{
                return null;
            }
        }
    }
}
