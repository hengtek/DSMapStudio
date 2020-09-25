using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkMonitorStreamColorTableColorPair : IHavokObject
    {
        public string m_colorName;
        public uint m_color;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_colorName = des.ReadStringPointer(br);
            m_color = br.ReadUInt32();
            br.AssertUInt32(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteUInt32(m_color);
            bw.WriteUInt32(0);
        }
    }
}
