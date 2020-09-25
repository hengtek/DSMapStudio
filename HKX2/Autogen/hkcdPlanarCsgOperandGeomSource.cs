using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkcdPlanarCsgOperandGeomSource : IHavokObject
    {
        public hkcdPlanarGeometry m_geometry;
        public int m_materialOffset;
        public int m_numMaterialIds;
        public uint m_flipPolygons;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_geometry = des.ReadClassPointer<hkcdPlanarGeometry>(br);
            m_materialOffset = br.ReadInt32();
            m_numMaterialIds = br.ReadInt32();
            m_flipPolygons = br.ReadUInt32();
            br.AssertUInt32(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            // Implement Write
            bw.WriteInt32(m_materialOffset);
            bw.WriteInt32(m_numMaterialIds);
            bw.WriteUInt32(m_flipPolygons);
            bw.WriteUInt32(0);
        }
    }
}
