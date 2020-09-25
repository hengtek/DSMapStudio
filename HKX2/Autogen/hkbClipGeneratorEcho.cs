using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbClipGeneratorEcho : IHavokObject
    {
        public float m_offsetLocalTime;
        public float m_weight;
        public float m_dwdt;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_offsetLocalTime = br.ReadSingle();
            m_weight = br.ReadSingle();
            m_dwdt = br.ReadSingle();
            br.AssertUInt32(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteSingle(m_offsetLocalTime);
            bw.WriteSingle(m_weight);
            bw.WriteSingle(m_dwdt);
            bw.WriteUInt32(0);
        }
    }
}
