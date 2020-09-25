using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbProjectData : hkReferencedObject
    {
        public Vector4 m_worldUpWS;
        public hkbProjectStringData m_stringData;
        public EventMode m_defaultEventMode;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_worldUpWS = des.ReadVector4(br);
            m_stringData = des.ReadClassPointer<hkbProjectStringData>(br);
            m_defaultEventMode = (EventMode)br.ReadSByte();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
