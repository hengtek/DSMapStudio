using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkpSerializedSubTrack1nInfo : hkpSerializedTrack1nInfo
    {
        public int m_sectorIndex;
        public int m_offsetInSector;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_sectorIndex = br.ReadInt32();
            m_offsetInSector = br.ReadInt32();
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteInt32(m_sectorIndex);
            bw.WriteInt32(m_offsetInSector);
        }
    }
}
