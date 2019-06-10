using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Interfaces
{
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request);  
    }

    public interface ICommand<TRequest, TResult> where TResult : class
    {
        TResult Execute(TRequest request);
    }
}
