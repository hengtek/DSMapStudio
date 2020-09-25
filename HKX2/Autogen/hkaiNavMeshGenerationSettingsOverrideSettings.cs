using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkaiNavMeshGenerationSettingsOverrideSettings : IHavokObject
    {
        public hkaiVolume m_volume;
        public int m_material;
        public CharacterWidthUsage m_characterWidthUsage;
        public float m_maxWalkableSlope;
        public hkaiNavMeshEdgeMatchingParameters m_edgeMatchingParams;
        public hkaiNavMeshSimplificationUtilsSettings m_simplificationSettings;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_volume = des.ReadClassPointer<hkaiVolume>(br);
            m_material = br.ReadInt32();
            m_characterWidthUsage = (CharacterWidthUsage)br.ReadByte();
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_maxWalkableSlope = br.ReadSingle();
            m_edgeMatchingParams = new hkaiNavMeshEdgeMatchingParameters();
            m_edgeMatchingParams.Read(des, br);
            br.AssertUInt32(0);
            m_simplificationSettings = new hkaiNavMeshSimplificationUtilsSettings();
            m_simplificationSettings.Read(des, br);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            // Implement Write
            bw.WriteInt32(m_material);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            bw.WriteSingle(m_maxWalkableSlope);
            m_edgeMatchingParams.Write(bw);
            bw.WriteUInt32(0);
            m_simplificationSettings.Write(bw);
        }
    }
}
