using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.UWP.Interfaces
{
    public interface IOperationControl
    {
        event EventHandler OperationCompleted;

        event EventHandler CanceledOperation;
    }
}
