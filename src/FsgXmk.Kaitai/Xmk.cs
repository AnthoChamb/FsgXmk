// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

namespace FsgXmk.Kaitai
{
    public partial class Xmk : KaitaiStruct
    {
        public static Xmk FromFile(string fileName)
        {
            return new Xmk(new KaitaiStream(fileName));
        }

        public Xmk(KaitaiStream p__io, KaitaiStruct p__parent = null, Xmk p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            _read();
        }
        private void _read()
        {
            _header = new XmkHeader(m_io, this, m_root);
            _tempos = new List<XmkTempo>();
            for (var i = 0; i < Header.NumTempos; i++)
            {
                _tempos.Add(new XmkTempo(m_io, this, m_root));
            }
            _timeSignatures = new List<XmkTimeSignature>();
            for (var i = 0; i < Header.NumTimeSignatures; i++)
            {
                _timeSignatures.Add(new XmkTimeSignature(m_io, this, m_root));
            }
            _events = new List<XmkEvent>();
            for (var i = 0; i < Header.NumEvents; i++)
            {
                _events.Add(new XmkEvent(m_io, this, m_root));
            }
            __raw_blobs = m_io.ReadBytes(Header.LenBlobs);
            var io___raw_blobs = new KaitaiStream(__raw_blobs);
            _blobs = new XmkBlobs(io___raw_blobs, this, m_root);
        }
        public partial class XmkHeader : KaitaiStruct
        {
            public static XmkHeader FromFile(string fileName)
            {
                return new XmkHeader(new KaitaiStream(fileName));
            }

            public XmkHeader(KaitaiStream p__io, Xmk p__parent = null, Xmk p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _version = m_io.ReadU4be();
                _hash = m_io.ReadBytes(4);
                _numEvents = m_io.ReadU4be();
                _lenBlobs = m_io.ReadU4be();
                __unnamed4 = m_io.ReadBytes(4);
                _numTempos = m_io.ReadU4be();
                _numTimeSignatures = m_io.ReadU4be();
            }
            private uint _version;
            private byte[] _hash;
            private uint _numEvents;
            private uint _lenBlobs;
            private byte[] __unnamed4;
            private uint _numTempos;
            private uint _numTimeSignatures;
            private Xmk m_root;
            private Xmk m_parent;
            public uint Version { get { return _version; } }
            public byte[] Hash { get { return _hash; } }
            public uint NumEvents { get { return _numEvents; } }
            public uint LenBlobs { get { return _lenBlobs; } }
            public byte[] Unnamed_4 { get { return __unnamed4; } }
            public uint NumTempos { get { return _numTempos; } }
            public uint NumTimeSignatures { get { return _numTimeSignatures; } }
            public Xmk M_Root { get { return m_root; } }
            public Xmk M_Parent { get { return m_parent; } }
        }
        public partial class XmkTimeSignature : KaitaiStruct
        {
            public static XmkTimeSignature FromFile(string fileName)
            {
                return new XmkTimeSignature(new KaitaiStream(fileName));
            }

            public XmkTimeSignature(KaitaiStream p__io, Xmk p__parent = null, Xmk p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _ticks = m_io.ReadU4be();
                _measure = m_io.ReadU4be();
                _numerator = m_io.ReadU4be();
                _denominator = m_io.ReadU4be();
            }
            private uint _ticks;
            private uint _measure;
            private uint _numerator;
            private uint _denominator;
            private Xmk m_root;
            private Xmk m_parent;
            public uint Ticks { get { return _ticks; } }
            public uint Measure { get { return _measure; } }
            public uint Numerator { get { return _numerator; } }
            public uint Denominator { get { return _denominator; } }
            public Xmk M_Root { get { return m_root; } }
            public Xmk M_Parent { get { return m_parent; } }
        }
        public partial class XmkBlobs : KaitaiStruct
        {
            public static XmkBlobs FromFile(string fileName)
            {
                return new XmkBlobs(new KaitaiStream(fileName));
            }

            public XmkBlobs(KaitaiStream p__io, Xmk p__parent = null, Xmk p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _values = new List<string>();
                {
                    var i = 0;
                    while (!m_io.IsEof) {
                        _values.Add(System.Text.Encoding.GetEncoding("ASCII").GetString(m_io.ReadBytesTerm(0, false, true, true)));
                        i++;
                    }
                }
            }
            private List<string> _values;
            private Xmk m_root;
            private Xmk m_parent;
            public List<string> Values { get { return _values; } }
            public Xmk M_Root { get { return m_root; } }
            public Xmk M_Parent { get { return m_parent; } }
        }
        public partial class XmkTempo : KaitaiStruct
        {
            public static XmkTempo FromFile(string fileName)
            {
                return new XmkTempo(new KaitaiStream(fileName));
            }

            public XmkTempo(KaitaiStream p__io, Xmk p__parent = null, Xmk p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _ticks = m_io.ReadU4be();
                _start = m_io.ReadF4be();
                _tempo = m_io.ReadU4be();
            }
            private uint _ticks;
            private float _start;
            private uint _tempo;
            private Xmk m_root;
            private Xmk m_parent;
            public uint Ticks { get { return _ticks; } }
            public float Start { get { return _start; } }
            public uint Tempo { get { return _tempo; } }
            public Xmk M_Root { get { return m_root; } }
            public Xmk M_Parent { get { return m_parent; } }
        }
        public partial class XmkEvent : KaitaiStruct
        {
            public static XmkEvent FromFile(string fileName)
            {
                return new XmkEvent(new KaitaiStream(fileName));
            }


            public enum XmkEventChord
            {
                Barre = 2,
                B1 = 4,
                B2 = 8,
                B3 = 16,
                W1 = 32,
                W2 = 64,
                W3 = 128,
            }

            public enum XmkEventType
            {
                Casual = 0,
                Section = 3,
                HopoDetection = 4,
                Easy = 8,
                Medium = 16,
                Hard = 24,
                Expert = 32,
                Highway = 56,
                Sustain = 64,
                SustainEasy = 72,
                SustainMedium = 80,
                SustainHard = 88,
                SustainExpert = 96,
                Hopo = 128,
                HopoEasy = 136,
                HopoMedium = 144,
                HopoHard = 152,
                HopoExpert = 160,
                HopoSustain = 192,
                HopoSustainEasy = 200,
                HopoSustainMedium = 208,
                HopoSustainHard = 216,
                HopoSustainExpert = 224,
            }

            public enum XmkEventNote
            {
                CasualOpen = 1,
                CasualHp = 3,
                EasyB1 = 5,
                EasyW1 = 6,
                EasyB2 = 7,
                EasyW2 = 8,
                EasyB3 = 9,
                EasyW3 = 10,
                EasyOpen = 15,
                EasyHp = 20,
                MediumB1 = 23,
                MediumW1 = 24,
                MediumB2 = 25,
                MediumW2 = 26,
                MediumB3 = 27,
                MediumW3 = 28,
                MediumOpen = 33,
                MediumHp = 38,
                HardB1 = 41,
                HardW1 = 42,
                HardB2 = 43,
                HardW2 = 44,
                HardB3 = 45,
                HardW3 = 46,
                HardOpen = 51,
                HardHp = 56,
                ExpertB1 = 59,
                ExpertW1 = 60,
                ExpertB2 = 61,
                ExpertW2 = 62,
                ExpertB3 = 63,
                ExpertW3 = 64,
                ExpertOpen = 69,
                ExpertHp = 74,
                Highway = 78,
                Section = 128,
            }
            public XmkEvent(KaitaiStream p__io, Xmk p__parent = null, Xmk p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _groupIndex = m_io.ReadU4be();
                _chord = ((XmkEventChord) m_io.ReadU2be());
                _type = ((XmkEventType) m_io.ReadU1());
                _note = ((XmkEventNote) m_io.ReadU1());
                _start = m_io.ReadF4be();
                _end = m_io.ReadF4be();
                __unnamed6 = m_io.ReadBytes(4);
                _ofsBlob = m_io.ReadU4be();
            }
            private uint _groupIndex;
            private XmkEventChord _chord;
            private XmkEventType _type;
            private XmkEventNote _note;
            private float _start;
            private float _end;
            private byte[] __unnamed6;
            private uint _ofsBlob;
            private Xmk m_root;
            private Xmk m_parent;
            public uint GroupIndex { get { return _groupIndex; } }
            public XmkEventChord Chord { get { return _chord; } }
            public XmkEventType Type { get { return _type; } }
            public XmkEventNote Note { get { return _note; } }
            public float Start { get { return _start; } }
            public float End { get { return _end; } }
            public byte[] Unnamed_6 { get { return __unnamed6; } }
            public uint OfsBlob { get { return _ofsBlob; } }
            public Xmk M_Root { get { return m_root; } }
            public Xmk M_Parent { get { return m_parent; } }
        }
        private XmkHeader _header;
        private List<XmkTempo> _tempos;
        private List<XmkTimeSignature> _timeSignatures;
        private List<XmkEvent> _events;
        private XmkBlobs _blobs;
        private Xmk m_root;
        private KaitaiStruct m_parent;
        private byte[] __raw_blobs;
        public XmkHeader Header { get { return _header; } }
        public List<XmkTempo> Tempos { get { return _tempos; } }
        public List<XmkTimeSignature> TimeSignatures { get { return _timeSignatures; } }
        public List<XmkEvent> Events { get { return _events; } }
        public XmkBlobs Blobs { get { return _blobs; } }
        public Xmk M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
        public byte[] M_RawBlobs { get { return __raw_blobs; } }
    }
}
