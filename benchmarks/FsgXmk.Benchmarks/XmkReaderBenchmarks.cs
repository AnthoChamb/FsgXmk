using BenchmarkDotNet.Attributes;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Factories;
using FsgXmk.Kaitai.Factories;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FsgXmk.Benchmarks
{
    public class XmkReaderBenchmarks
    {
        private readonly string _path;
        private readonly XmkStreamReaderFactory _factory;
        private readonly KaitaiXmkStreamReaderFactory _kaitaiFactory;

        public XmkReaderBenchmarks()
        {
            static string CallerFilePath([CallerFilePath] string callerFilePath = "") => callerFilePath;

            _path = Path.Combine(Path.GetDirectoryName(CallerFilePath())!, "guitar_3x2.xmk");
            _factory = new XmkStreamReaderFactory(new XmkHeaderStreamReaderFactory(new XmkHeaderByteArrayReaderFactory()),
                                                  new XmkTempoStreamReaderFactory(new XmkTempoByteArrayReaderFactory()),
                                                  new XmkTimeSignatureStreamReaderFactory(new XmkTimeSignatureByteArrayReaderFactory()),
                                                  new XmkEventStreamReaderFactory(new XmkEventByteArrayReaderFactory()),
                                                  new XmkBlobsStreamReaderFactory(new XmkBlobsByteArrayReaderFactory()));
            _kaitaiFactory = new KaitaiXmkStreamReaderFactory();
        }

        [Benchmark(Baseline = true)]
        public IXmk XmkStreamReader()
        {
            using var stream = File.OpenRead(_path);
            using var reader = _factory.Create(stream, true);
            return reader.Read();
        }

        [Benchmark]
        public async ValueTask<IXmk> XmkStreamReaderAsync()
        {
            using var stream = File.OpenRead(_path);
            using var reader = _factory.Create(stream, true);
            return await reader.ReadAsync();
        }

        [Benchmark]
        public IXmk KaitaiXmkStreamReader()
        {
            using var stream = File.OpenRead(_path);
            using var reader = _kaitaiFactory.Create(stream, true);
            return reader.Read();
        }

        [Benchmark]
        public async ValueTask<IXmk> KaitaiXmkStreamReaderAsync()
        {
            using var stream = File.OpenRead(_path);
            using var reader = _kaitaiFactory.Create(stream, true);
            return await reader.ReadAsync();
        }
    }
}
