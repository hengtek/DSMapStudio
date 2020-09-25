using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum MotorType
    {
        TYPE_INVALID = 0,
        TYPE_POSITION = 1,
        TYPE_VELOCITY = 2,
        TYPE_SPRING_DAMPER = 3,
        TYPE_CALLBACK = 4,
        TYPE_MAX = 5,
    }
    
    public class hkpConstraintMotor : hkReferencedObject
    {
        public MotorType m_type;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_type = (MotorType)br.ReadSByte();
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
