using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCode.Code.Builders
{
    interface IBuilder<T>
    {
        T GetInstance();
    }
}
