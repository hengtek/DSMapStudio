using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum SpuFlagsEnum
    {
        FORCE_NARROW_PHASE_PPU = 1,
    }
    
    public class hknpBody : IHavokObject
    {
        public enum Flags
        {
            IS_STATIC = 1,
            IS_DYNAMIC = 2,
            IS_KEYFRAMED = 4,
            IS_ACTIVE = 8,
        }
        
        public Matrix4x4 m_transform;
        public int m_flags;
        public uint m_collisionFilterInfo;
        public hknpShape m_shape;
        public hkAabb16 m_aabb;
        public uint m_id;
        public uint m_nextAttachedBodyId;
        public uint m_motionId;
        public uint m_broadPhaseId;
        public ushort m_materialId;
        public byte m_qualityId;
        public byte m_timAngle;
        public ushort m_maxTimDistance;
        public ushort m_maxContactDistance;
        public uint m_indexIntoActiveListOrDeactivatedIslandId;
        public short m_radiusOfComCenteredBoundingSphere;
        public byte m_spuFlags;
        public byte m_shapeSizeDiv16;
        public short m_motionToBodyRotation;
        public ulong m_userData;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_transform = des.ReadTransform(br);
            m_flags = br.ReadInt32();
            m_collisionFilterInfo = br.ReadUInt32();
            m_shape = des.ReadClassPointer<hknpShape>(br);
            m_aabb = new hkAabb16();
            m_aabb.Read(des, br);
            m_id = br.ReadUInt32();
            m_nextAttachedBodyId = br.ReadUInt32();
            m_motionId = br.ReadUInt32();
            m_broadPhaseId = br.ReadUInt32();
            m_materialId = br.ReadUInt16();
            m_qualityId = br.ReadByte();
            m_timAngle = br.ReadByte();
            m_maxTimDistance = br.ReadUInt16();
            m_maxContactDistance = br.ReadUInt16();
            m_indexIntoActiveListOrDeactivatedIslandId = br.ReadUInt32();
            m_radiusOfComCenteredBoundingSphere = br.ReadInt16();
            m_spuFlags = br.ReadByte();
            m_shapeSizeDiv16 = br.ReadByte();
            m_motionToBodyRotation = br.ReadInt16();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            m_userData = br.ReadUInt64();
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteInt32(m_flags);
            bw.WriteUInt32(m_collisionFilterInfo);
            // Implement Write
            m_aabb.Write(bw);
            bw.WriteUInt32(m_id);
            bw.WriteUInt32(m_nextAttachedBodyId);
            bw.WriteUInt32(m_motionId);
            bw.WriteUInt32(m_broadPhaseId);
            bw.WriteUInt16(m_materialId);
            bw.WriteByte(m_qualityId);
            bw.WriteByte(m_timAngle);
            bw.WriteUInt16(m_maxTimDistance);
            bw.WriteUInt16(m_maxContactDistance);
            bw.WriteUInt32(m_indexIntoActiveListOrDeactivatedIslandId);
            bw.WriteInt16(m_radiusOfComCenteredBoundingSphere);
            bw.WriteByte(m_shapeSizeDiv16);
            bw.WriteInt16(m_motionToBodyRotation);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteUInt64(m_userData);
        }
    }
}
