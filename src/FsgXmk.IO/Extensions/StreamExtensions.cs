using System.IO;
using System.Threading.Tasks;

namespace FsgXmk.IO.Extensions
{
    public static class StreamExtensions
    {
        public static void ReadExactly(this Stream stream, byte[] buffer, int offset, int count)
        {
            var bytesRead = stream.Read(buffer, offset, count);

            if (bytesRead != count)
            {
                ThrowHelper.ThrowEndOfStreamException();
            }
        }

        public static async Task ReadExactlyAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            var bytesRead = await stream.ReadAsync(buffer, offset, count);

            if (bytesRead != count)
            {
                ThrowHelper.ThrowEndOfStreamException();
            }
        }
    }
}
