using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkMassProperties : IHavokObject
    {
        public float m_volume;
        public float m_mass;
        public Vector4 m_centerOfMass;
        public Matrix4x4 m_inertiaTensor;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_volume = br.ReadSingle();
            m_mass = br.ReadSingle();
            br.AssertUInt64(0);
            m_centerOfMass = des.ReadVector4(br);
            m_inertiaTensor = des.ReadMatrix3(br);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteSingle(m_volume);
            bw.WriteSingle(m_mass);
            bw.WriteUInt64(0);
        }
    }
}
