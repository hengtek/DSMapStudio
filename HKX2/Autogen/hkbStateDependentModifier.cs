using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbStateDependentModifier : hkbModifier
    {
        public bool m_applyModifierDuringTransition;
        public List<int> m_stateIds;
        public hkbModifier m_modifier;
        public bool m_isActive;
        public hkbStateMachine m_stateMachine;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_applyModifierDuringTransition = br.ReadBoolean();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_stateIds = des.ReadInt32Array(br);
            m_modifier = des.ReadClassPointer<hkbModifier>(br);
            m_isActive = br.ReadBoolean();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_stateMachine = des.ReadClassPointer<hkbStateMachine>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteBoolean(m_applyModifierDuringTransition);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            // Implement Write
            bw.WriteBoolean(m_isActive);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            // Implement Write
        }
    }
}
