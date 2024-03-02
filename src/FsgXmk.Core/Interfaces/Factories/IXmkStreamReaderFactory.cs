using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IXmkStreamReaderFactory
    {
        IXmkReader Create(Stream stream, bool leaveOpen);
    }
}
