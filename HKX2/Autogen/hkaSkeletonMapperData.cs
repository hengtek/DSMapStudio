using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum MappingType
    {
        HK_RAGDOLL_MAPPING = 0,
        HK_RETARGETING_MAPPING = 1,
    }
    
    public class hkaSkeletonMapperData : IHavokObject
    {
        public hkaSkeleton m_skeletonA;
        public hkaSkeleton m_skeletonB;
        public List<short> m_partitionMap;
        public List<hkaSkeletonMapperDataPartitionMappingRange> m_simpleMappingPartitionRanges;
        public List<hkaSkeletonMapperDataPartitionMappingRange> m_chainMappingPartitionRanges;
        public List<hkaSkeletonMapperDataSimpleMapping> m_simpleMappings;
        public List<hkaSkeletonMapperDataChainMapping> m_chainMappings;
        public List<short> m_unmappedBones;
        public Matrix4x4 m_extractedMotionMapping;
        public bool m_keepUnmappedLocal;
        public MappingType m_mappingType;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_skeletonA = des.ReadClassPointer<hkaSkeleton>(br);
            m_skeletonB = des.ReadClassPointer<hkaSkeleton>(br);
            m_partitionMap = des.ReadInt16Array(br);
            m_simpleMappingPartitionRanges = des.ReadClassArray<hkaSkeletonMapperDataPartitionMappingRange>(br);
            m_chainMappingPartitionRanges = des.ReadClassArray<hkaSkeletonMapperDataPartitionMappingRange>(br);
            m_simpleMappings = des.ReadClassArray<hkaSkeletonMapperDataSimpleMapping>(br);
            m_chainMappings = des.ReadClassArray<hkaSkeletonMapperDataChainMapping>(br);
            m_unmappedBones = des.ReadInt16Array(br);
            m_extractedMotionMapping = des.ReadQSTransform(br);
            m_keepUnmappedLocal = br.ReadBoolean();
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_mappingType = (MappingType)br.ReadInt32();
            br.AssertUInt64(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            // Implement Write
            // Implement Write
            bw.WriteBoolean(m_keepUnmappedLocal);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            bw.WriteUInt64(0);
        }
    }
}
