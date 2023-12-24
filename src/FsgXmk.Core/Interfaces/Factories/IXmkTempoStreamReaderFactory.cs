using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IXmkTempoStreamReaderFactory
    {
        IXmkTempoReader Create(Stream stream, bool leaveOpen);
    }
}
