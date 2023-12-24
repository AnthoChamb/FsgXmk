namespace FsgXmk.Core.Enums
{
    public enum EventType : byte
    {
        Section = 0b0000_0011,
        HopoDetection = 0b0000_0100,
        Highway = 0b0100_1110,
        Casual = 0b0000_0000,
        Easy = 0b0000_1000,
        Medium = 0b0001_0000,
        Hard = 0b0001_1000,
        Expert = 0b0010_0000,
        Sustain = 0b0100_0000,
        SustainEasy = Sustain | Easy,
        SustainMedium = Sustain | Medium,
        SustainHard = Sustain | Hard,
        SustainExpert = Sustain | Expert,
        Hopo = 0b1000_0000,
        HopoEasy = Hopo | Easy,
        HopoMedium = Hopo | Medium,
        HopoHard = Hopo | Hard,
        HopoExpert = Hopo | Expert,
        HopoSustainEasy = Hopo | Sustain | Easy,
        HopoSustainMedium = Hopo | Sustain | Medium,
        HopoSustainHard = Hopo | Sustain | Hard,
        HopoSustainExpert = Hopo | Sustain | Expert
    }
}
