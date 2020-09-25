using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclToolNamedObjectReference : IHavokObject
    {
        public string m_pluginName;
        public string m_objectName;
        public uint m_hash;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_pluginName = des.ReadStringPointer(br);
            m_objectName = des.ReadStringPointer(br);
            m_hash = br.ReadUInt32();
            br.AssertUInt32(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteUInt32(m_hash);
            bw.WriteUInt32(0);
        }
    }
}
