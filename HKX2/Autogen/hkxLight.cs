using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum LightType
    {
        POINT_LIGHT = 0,
        DIRECTIONAL_LIGHT = 1,
        SPOT_LIGHT = 2,
    }
    
    public class hkxLight : hkReferencedObject
    {
        public LightType m_type;
        public Vector4 m_position;
        public Vector4 m_direction;
        public uint m_color;
        public float m_angle;
        public float m_range;
        public float m_fadeStart;
        public float m_fadeEnd;
        public short m_decayRate;
        public float m_intensity;
        public bool m_shadowCaster;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_type = (LightType)br.ReadSByte();
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_position = des.ReadVector4(br);
            m_direction = des.ReadVector4(br);
            m_color = br.ReadUInt32();
            m_angle = br.ReadSingle();
            m_range = br.ReadSingle();
            m_fadeStart = br.ReadSingle();
            m_fadeEnd = br.ReadSingle();
            m_decayRate = br.ReadInt16();
            br.AssertUInt16(0);
            m_intensity = br.ReadSingle();
            m_shadowCaster = br.ReadBoolean();
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            bw.WriteUInt32(m_color);
            bw.WriteSingle(m_angle);
            bw.WriteSingle(m_range);
            bw.WriteSingle(m_fadeStart);
            bw.WriteSingle(m_fadeEnd);
            bw.WriteInt16(m_decayRate);
            bw.WriteUInt16(0);
            bw.WriteSingle(m_intensity);
            bw.WriteBoolean(m_shadowCaster);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
