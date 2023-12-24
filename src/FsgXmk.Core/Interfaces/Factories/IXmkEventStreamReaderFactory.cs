using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IXmkEventStreamReaderFactory
    {
        IXmkEventReader Create(Stream stream, bool leaveOpen);
    }
}
