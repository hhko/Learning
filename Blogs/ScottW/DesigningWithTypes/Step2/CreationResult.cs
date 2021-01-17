using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step2
{
    [Union]
    public interface ICreationResult<T>
    {
        ICreationResult<T> Success(T value);
        ICreationResult<T> Error(string message);
    }
}
