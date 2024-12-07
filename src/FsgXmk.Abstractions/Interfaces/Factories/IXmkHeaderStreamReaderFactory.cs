using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkHeaderStreamReaderFactory
    {
        IXmkHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
