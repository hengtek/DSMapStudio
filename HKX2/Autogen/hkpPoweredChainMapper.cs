using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkpPoweredChainMapper : hkReferencedObject
    {
        public List<hkpPoweredChainMapperLinkInfo> m_links;
        public List<hkpPoweredChainMapperTarget> m_targets;
        public List<hkpConstraintChainInstance> m_chains;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_links = des.ReadClassArray<hkpPoweredChainMapperLinkInfo>(br);
            m_targets = des.ReadClassArray<hkpPoweredChainMapperTarget>(br);
            m_chains = des.ReadClassPointerArray<hkpConstraintChainInstance>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
        }
    }
}
