using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hknpRefMaterial : hkReferencedObject
    {
        public hknpMaterial m_material;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_material = new hknpMaterial();
            m_material.Read(des, br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            m_material.Write(bw);
        }
    }
}
