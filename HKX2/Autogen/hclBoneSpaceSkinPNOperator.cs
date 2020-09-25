using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclBoneSpaceSkinPNOperator : hclBoneSpaceSkinOperator
    {
        public List<hclBoneSpaceDeformerLocalBlockPN> m_localPNs;
        public List<hclBoneSpaceDeformerLocalBlockUnpackedPN> m_localUnpackedPNs;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_localPNs = des.ReadClassArray<hclBoneSpaceDeformerLocalBlockPN>(br);
            m_localUnpackedPNs = des.ReadClassArray<hclBoneSpaceDeformerLocalBlockUnpackedPN>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
        }
    }
}
