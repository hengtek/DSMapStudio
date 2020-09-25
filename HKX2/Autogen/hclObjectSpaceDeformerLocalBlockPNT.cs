using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclObjectSpaceDeformerLocalBlockPNT : IHavokObject
    {
        public short m_localPosition;
        public short m_localNormal;
        public short m_localTangent;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_localPosition = br.ReadInt16();
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            m_localNormal = br.ReadInt16();
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            m_localTangent = br.ReadInt16();
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteInt16(m_localPosition);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteInt16(m_localNormal);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteInt16(m_localTangent);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
        }
    }
}
