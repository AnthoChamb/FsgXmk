using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkEventStreamReaderFactory
    {
        IXmkEventReader Create(Stream stream, bool leaveOpen);
    }
}
