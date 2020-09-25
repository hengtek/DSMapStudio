using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbTwistModifier : hkbModifier
    {
        public enum SetAngleMethod
        {
            LINEAR = 0,
            RAMPED = 1,
        }
        
        public enum RotationAxisCoordinates
        {
            ROTATION_AXIS_IN_MODEL_COORDINATES = 0,
            ROTATION_AXIS_IN_PARENT_COORDINATES = 1,
            ROTATION_AXIS_IN_LOCAL_COORDINATES = 2,
        }
        
        public Vector4 m_axisOfRotation;
        public float m_twistAngle;
        public short m_startBoneIndex;
        public short m_endBoneIndex;
        public SetAngleMethod m_setAngleMethod;
        public RotationAxisCoordinates m_rotationAxisCoordinates;
        public bool m_isAdditive;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.AssertUInt64(0);
            m_axisOfRotation = des.ReadVector4(br);
            m_twistAngle = br.ReadSingle();
            m_startBoneIndex = br.ReadInt16();
            m_endBoneIndex = br.ReadInt16();
            m_setAngleMethod = (SetAngleMethod)br.ReadSByte();
            m_rotationAxisCoordinates = (RotationAxisCoordinates)br.ReadSByte();
            m_isAdditive = br.ReadBoolean();
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteSingle(m_twistAngle);
            bw.WriteInt16(m_startBoneIndex);
            bw.WriteInt16(m_endBoneIndex);
            bw.WriteBoolean(m_isAdditive);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteByte(0);
        }
    }
}
