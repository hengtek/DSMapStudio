using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hknpVehicleInstanceWheelInfo : IHavokObject
    {
        public hkContactPoint m_contactPoint;
        public float m_contactFriction;
        public uint m_contactShapeKey;
        public Vector4 m_hardPointWs;
        public Vector4 m_rayEndPointWs;
        public float m_currentSuspensionLength;
        public Vector4 m_suspensionDirectionWs;
        public Vector4 m_spinAxisChassisSpace;
        public Vector4 m_spinAxisWs;
        public Quaternion m_steeringOrientationChassisSpace;
        public float m_spinVelocity;
        public float m_noSlipIdealSpinVelocity;
        public float m_spinAngle;
        public float m_skidEnergyDensity;
        public float m_sideForce;
        public float m_forwardSlipVelocity;
        public float m_sideSlipVelocity;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_contactPoint = new hkContactPoint();
            m_contactPoint.Read(des, br);
            m_contactFriction = br.ReadSingle();
            br.AssertUInt32(0);
            m_contactShapeKey = br.ReadUInt32();
            br.AssertUInt32(0);
            m_hardPointWs = des.ReadVector4(br);
            m_rayEndPointWs = des.ReadVector4(br);
            m_currentSuspensionLength = br.ReadSingle();
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            m_suspensionDirectionWs = des.ReadVector4(br);
            m_spinAxisChassisSpace = des.ReadVector4(br);
            m_spinAxisWs = des.ReadVector4(br);
            m_steeringOrientationChassisSpace = des.ReadQuaternion(br);
            m_spinVelocity = br.ReadSingle();
            m_noSlipIdealSpinVelocity = br.ReadSingle();
            m_spinAngle = br.ReadSingle();
            m_skidEnergyDensity = br.ReadSingle();
            m_sideForce = br.ReadSingle();
            m_forwardSlipVelocity = br.ReadSingle();
            m_sideSlipVelocity = br.ReadSingle();
            br.AssertUInt32(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            m_contactPoint.Write(bw);
            bw.WriteSingle(m_contactFriction);
            bw.WriteUInt32(0);
            bw.WriteUInt32(m_contactShapeKey);
            bw.WriteUInt32(0);
            bw.WriteSingle(m_currentSuspensionLength);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteSingle(m_spinVelocity);
            bw.WriteSingle(m_noSlipIdealSpinVelocity);
            bw.WriteSingle(m_spinAngle);
            bw.WriteSingle(m_skidEnergyDensity);
            bw.WriteSingle(m_sideForce);
            bw.WriteSingle(m_forwardSlipVelocity);
            bw.WriteSingle(m_sideSlipVelocity);
            bw.WriteUInt32(0);
        }
    }
}
