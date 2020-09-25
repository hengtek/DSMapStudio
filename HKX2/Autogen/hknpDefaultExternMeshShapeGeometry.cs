using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hknpDefaultExternMeshShapeGeometry : hknpExternMeshShapeGeometry
    {
        public hkGeometry m_geometry;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_geometry = des.ReadClassPointer<hkGeometry>(br);
            br.AssertUInt64(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
            bw.WriteUInt64(0);
        }
    }
}
