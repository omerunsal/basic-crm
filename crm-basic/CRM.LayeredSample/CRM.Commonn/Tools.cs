using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Commonn
{
    public class Tools
    {
        public static string ConnectionString
        {   
            get
            {
                ////string cnnString = @"Server = DESKTOP - QSRGKG9\SQLEXPRESS; Database = CrmDB; Integrated Security = Yes ";

                return @"Server = DESKTOP-QSRGKG9\SQLEXPRESS; Database = CrmDB; Integrated Security = Yes ";
            }
        }
    }
}
