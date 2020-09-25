using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbDampingModifierInternalState : hkReferencedObject
    {
        public Vector4 m_dampedVector;
        public Vector4 m_vecErrorSum;
        public Vector4 m_vecPreviousError;
        public float m_dampedValue;
        public float m_errorSum;
        public float m_previousError;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_dampedVector = des.ReadVector4(br);
            m_vecErrorSum = des.ReadVector4(br);
            m_vecPreviousError = des.ReadVector4(br);
            m_dampedValue = br.ReadSingle();
            m_errorSum = br.ReadSingle();
            m_previousError = br.ReadSingle();
            br.AssertUInt32(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteSingle(m_dampedValue);
            bw.WriteSingle(m_errorSum);
            bw.WriteSingle(m_previousError);
            bw.WriteUInt32(0);
        }
    }
}
