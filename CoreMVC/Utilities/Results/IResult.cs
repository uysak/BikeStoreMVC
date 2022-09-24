using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVC.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        public bool Success { get;}
        public string Message { get;}
    }
}
