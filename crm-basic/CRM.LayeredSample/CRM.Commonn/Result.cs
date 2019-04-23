using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Commonn
{
    public class Result 
    {
        public bool IsSucceeded { get; set; }
        public Result()
        {
            IsSucceeded = false; // defaultta 0
        }
    }

    public class Result<T> : Result
    {
        public T TransactionResult { get; set; }
    }
    //CRM.Dal içine -> customerDAL.cs adında bir class açalaım
}
