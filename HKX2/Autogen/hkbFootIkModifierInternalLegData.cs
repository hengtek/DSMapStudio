using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbFootIkModifierInternalLegData : IHavokObject
    {
        public Vector4 m_groundPosition;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_groundPosition = des.ReadVector4(br);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
        }
    }
}
