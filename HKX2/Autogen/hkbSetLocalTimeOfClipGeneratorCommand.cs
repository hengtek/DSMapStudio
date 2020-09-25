using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbSetLocalTimeOfClipGeneratorCommand : hkReferencedObject
    {
        public ulong m_characterId;
        public float m_localTime;
        public ushort m_nodeId;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_characterId = br.ReadUInt64();
            m_localTime = br.ReadSingle();
            m_nodeId = br.ReadUInt16();
            br.AssertUInt16(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(m_characterId);
            bw.WriteSingle(m_localTime);
            bw.WriteUInt16(m_nodeId);
            bw.WriteUInt16(0);
        }
    }
}
