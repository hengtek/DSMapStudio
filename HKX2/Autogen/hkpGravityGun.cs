using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkpGravityGun : hkpFirstPersonGun
    {
        public int m_maxNumObjectsPicked;
        public float m_maxMassOfObjectPicked;
        public float m_maxDistOfObjectPicked;
        public float m_impulseAppliedWhenObjectNotPicked;
        public float m_throwVelocity;
        public Vector4 m_capturedObjectPosition;
        public Vector4 m_capturedObjectsOffset;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.AssertUInt64(0);
            br.AssertUInt64(0);
            m_maxNumObjectsPicked = br.ReadInt32();
            m_maxMassOfObjectPicked = br.ReadSingle();
            m_maxDistOfObjectPicked = br.ReadSingle();
            m_impulseAppliedWhenObjectNotPicked = br.ReadSingle();
            m_throwVelocity = br.ReadSingle();
            br.AssertUInt32(0);
            m_capturedObjectPosition = des.ReadVector4(br);
            m_capturedObjectsOffset = des.ReadVector4(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteUInt64(0);
            bw.WriteInt32(m_maxNumObjectsPicked);
            bw.WriteSingle(m_maxMassOfObjectPicked);
            bw.WriteSingle(m_maxDistOfObjectPicked);
            bw.WriteSingle(m_impulseAppliedWhenObjectNotPicked);
            bw.WriteSingle(m_throwVelocity);
            bw.WriteUInt32(0);
        }
    }
}
