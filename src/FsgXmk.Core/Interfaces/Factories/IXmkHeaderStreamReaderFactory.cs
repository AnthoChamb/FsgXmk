using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IXmkHeaderStreamReaderFactory
    {
        IXmkHeaderReader Create(Stream stream, bool leaveOpen);
    }
}
