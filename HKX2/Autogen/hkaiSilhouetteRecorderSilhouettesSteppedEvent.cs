using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkaiSilhouetteRecorderSilhouettesSteppedEvent : hkaiSilhouetteRecorderReplayEvent
    {
        public StepThreading m_stepThreading;
        public List<hkaiSilhouetteGenerator> m_generators;
        public List<Matrix4x4> m_instanceTransforms;
        public List<hkaiOverlapManagerSection> m_overlapManagerSections;
        public hkBitField m_updatedSections;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_stepThreading = (StepThreading)br.ReadUInt32();
            br.AssertUInt32(0);
            m_generators = des.ReadClassPointerArray<hkaiSilhouetteGenerator>(br);
            m_instanceTransforms = des.ReadTransformArray(br);
            m_overlapManagerSections = des.ReadClassArray<hkaiOverlapManagerSection>(br);
            m_updatedSections = new hkBitField();
            m_updatedSections.Read(des, br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt32(0);
            m_updatedSections.Write(bw);
        }
    }
}
