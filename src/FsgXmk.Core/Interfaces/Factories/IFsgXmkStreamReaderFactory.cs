using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IFsgXmkStreamReaderFactory
    {
        IFsgXmkReader Create(Stream stream, bool leaveOpen);
    }
}
