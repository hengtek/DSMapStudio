using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hknpLodShapeLevelOfDetailInfo : IHavokObject
    {
        public float m_maxDistance;
        public float m_maxShrink;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_maxDistance = br.ReadSingle();
            m_maxShrink = br.ReadSingle();
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteSingle(m_maxDistance);
            bw.WriteSingle(m_maxShrink);
        }
    }
}
