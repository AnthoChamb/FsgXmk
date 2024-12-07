using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkTempoStreamReaderFactory
    {
        IXmkTempoReader Create(Stream stream, bool leaveOpen);
    }
}
