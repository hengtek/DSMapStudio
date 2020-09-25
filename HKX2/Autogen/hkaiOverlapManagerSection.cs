using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkaiOverlapManagerSection : IHavokObject
    {
        public int m_numOriginalFaces;
        public List<hkaiOverlapManagerSectionGeneratorData> m_generatorData;
        public hkSetIntFloatPair m_facePriorities;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            br.AssertUInt64(0);
            m_numOriginalFaces = br.ReadInt32();
            br.AssertUInt32(0);
            m_generatorData = des.ReadClassPointerArray<hkaiOverlapManagerSectionGeneratorData>(br);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            m_facePriorities = new hkSetIntFloatPair();
            m_facePriorities.Read(des, br);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteUInt64(0);
            bw.WriteInt32(m_numOriginalFaces);
            bw.WriteUInt32(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            m_facePriorities.Write(bw);
        }
    }
}
