using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkStreamReaderFactory
    {
        IXmkReader Create(Stream stream, bool leaveOpen);
    }
}
