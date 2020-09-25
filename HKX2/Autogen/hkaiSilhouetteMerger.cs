using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum MergeType
    {
        UNUSED_MERGING_SIMPLE = 0,
        UNUSED_MERGING_CONVEX_HULL = 1,
    }
    
    public class hkaiSilhouetteMerger : hkReferencedObject
    {
        public MergeType m_mergeType;
        public hkaiSilhouetteGenerationParameters m_mergeParams;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_mergeType = (MergeType)br.ReadByte();
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_mergeParams = new hkaiSilhouetteGenerationParameters();
            m_mergeParams.Read(des, br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            m_mergeParams.Write(bw);
        }
    }
}
