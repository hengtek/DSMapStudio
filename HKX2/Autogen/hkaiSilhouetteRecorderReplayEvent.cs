using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum ReplayEventType
    {
        EVENT_CONNECT_TO_WORLD = 0,
        EVENT_INSTANCE_LOADED = 1,
        EVENT_INSTANCE_UNLOADED = 2,
        EVENT_STEP_SILHOUETTES = 3,
        EVENT_VOLUME_LOADED = 4,
        EVENT_VOLUME_UNLOADED = 5,
        EVENT_GRAPH_LOADED = 6,
        EVENT_GRAPH_UNLOADED = 7,
    }
    
    public class hkaiSilhouetteRecorderReplayEvent : hkReferencedObject
    {
        public ReplayEventType m_eventType;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_eventType = (ReplayEventType)br.ReadByte();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
