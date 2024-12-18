﻿using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkReader : IDisposable
    {
        IXmk Read();
        ValueTask<IXmk> ReadAsync();
    }
}
