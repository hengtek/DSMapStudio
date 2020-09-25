using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum Mode
    {
        MODE_MATCH = 0,
        MODE_PLAY = 1,
    }
    
    public class hkbPoseMatchingGenerator : hkbBlenderGenerator
    {
        public Quaternion m_worldFromModelRotation;
        public float m_blendSpeed;
        public float m_minSpeedToSwitch;
        public float m_minSwitchTimeNoError;
        public float m_minSwitchTimeFullError;
        public int m_startPlayingEventId;
        public int m_startMatchingEventId;
        public short m_rootBoneIndex;
        public short m_otherBoneIndex;
        public short m_anotherBoneIndex;
        public short m_pelvisIndex;
        public Mode m_mode;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_worldFromModelRotation = des.ReadQuaternion(br);
            m_blendSpeed = br.ReadSingle();
            m_minSpeedToSwitch = br.ReadSingle();
            m_minSwitchTimeNoError = br.ReadSingle();
            m_minSwitchTimeFullError = br.ReadSingle();
            m_startPlayingEventId = br.ReadInt32();
            m_startMatchingEventId = br.ReadInt32();
            m_rootBoneIndex = br.ReadInt16();
            m_otherBoneIndex = br.ReadInt16();
            m_anotherBoneIndex = br.ReadInt16();
            m_pelvisIndex = br.ReadInt16();
            m_mode = (Mode)br.ReadSByte();
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteSingle(m_blendSpeed);
            bw.WriteSingle(m_minSpeedToSwitch);
            bw.WriteSingle(m_minSwitchTimeNoError);
            bw.WriteSingle(m_minSwitchTimeFullError);
            bw.WriteInt32(m_startPlayingEventId);
            bw.WriteInt32(m_startMatchingEventId);
            bw.WriteInt16(m_rootBoneIndex);
            bw.WriteInt16(m_otherBoneIndex);
            bw.WriteInt16(m_anotherBoneIndex);
            bw.WriteInt16(m_pelvisIndex);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
