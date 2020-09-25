using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum Bounds
    {
        BOUND_POS_X = 0,
        BOUND_NEG_X = 1,
        BOUND_POS_Y = 2,
        BOUND_NEG_Y = 3,
        BOUND_POS_Z = 4,
        BOUND_NEG_Z = 5,
        NUM_BOUNDS = 6,
    }
    
    public class hkcdPlanarGeometryPlanesCollection : hkReferencedObject
    {
        public Vector4 m_offsetAndScale;
        public List<hkcdPlanarGeometryPrimitivesPlane> m_planes;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_offsetAndScale = des.ReadVector4(br);
            m_planes = des.ReadClassArray<hkcdPlanarGeometryPrimitivesPlane>(br);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
        }
    }
}
