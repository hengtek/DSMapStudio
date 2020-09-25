using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbKeyframeBonesModifier : hkbModifier
    {
        public List<hkbKeyframeBonesModifierKeyframeInfo> m_keyframeInfo;
        public hkbBoneIndexArray m_keyframedBonesList;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_keyframeInfo = des.ReadClassArray<hkbKeyframeBonesModifierKeyframeInfo>(br);
            m_keyframedBonesList = des.ReadClassPointer<hkbBoneIndexArray>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
        }
    }
}
