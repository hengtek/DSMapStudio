using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum MaterialType
    {
        MATERIAL_NONE = 0,
        MATERIAL_SINGLE_VALUE_PER_CHUNK = 1,
        MATERIAL_ONE_BYTE_PER_TRIANGLE = 2,
        MATERIAL_TWO_BYTES_PER_TRIANGLE = 3,
        MATERIAL_FOUR_BYTES_PER_TRIANGLE = 4,
    }
    
    public class hkpCompressedMeshShape : hkpShapeCollection
    {
        public int m_bitsPerIndex;
        public int m_bitsPerWIndex;
        public int m_wIndexMask;
        public int m_indexMask;
        public float m_radius;
        public WeldingType m_weldingType;
        public MaterialType m_materialType;
        public List<uint> m_materials;
        public List<ushort> m_materials16;
        public List<byte> m_materials8;
        public List<Matrix4x4> m_transforms;
        public List<Vector4> m_bigVertices;
        public List<hkpCompressedMeshShapeBigTriangle> m_bigTriangles;
        public List<hkpCompressedMeshShapeChunk> m_chunks;
        public List<hkpCompressedMeshShapeConvexPiece> m_convexPieces;
        public float m_error;
        public hkAabb m_bounds;
        public uint m_defaultCollisionFilterInfo;
        public ushort m_materialStriding;
        public ushort m_numMaterials;
        public List<hkpNamedMeshMaterial> m_namedMaterials;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_bitsPerIndex = br.ReadInt32();
            m_bitsPerWIndex = br.ReadInt32();
            m_wIndexMask = br.ReadInt32();
            m_indexMask = br.ReadInt32();
            m_radius = br.ReadSingle();
            m_weldingType = (WeldingType)br.ReadByte();
            m_materialType = (MaterialType)br.ReadByte();
            br.AssertUInt16(0);
            m_materials = des.ReadUInt32Array(br);
            m_materials16 = des.ReadUInt16Array(br);
            m_materials8 = des.ReadByteArray(br);
            m_transforms = des.ReadQSTransformArray(br);
            m_bigVertices = des.ReadVector4Array(br);
            m_bigTriangles = des.ReadClassArray<hkpCompressedMeshShapeBigTriangle>(br);
            m_chunks = des.ReadClassArray<hkpCompressedMeshShapeChunk>(br);
            m_convexPieces = des.ReadClassArray<hkpCompressedMeshShapeConvexPiece>(br);
            m_error = br.ReadSingle();
            br.AssertUInt32(0);
            m_bounds = new hkAabb();
            m_bounds.Read(des, br);
            m_defaultCollisionFilterInfo = br.ReadUInt32();
            br.AssertUInt64(0);
            br.AssertUInt32(0);
            m_materialStriding = br.ReadUInt16();
            m_numMaterials = br.ReadUInt16();
            br.AssertUInt32(0);
            m_namedMaterials = des.ReadClassArray<hkpNamedMeshMaterial>(br);
            br.AssertUInt64(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteInt32(m_bitsPerIndex);
            bw.WriteInt32(m_bitsPerWIndex);
            bw.WriteInt32(m_wIndexMask);
            bw.WriteInt32(m_indexMask);
            bw.WriteSingle(m_radius);
            bw.WriteUInt16(0);
            bw.WriteSingle(m_error);
            bw.WriteUInt32(0);
            m_bounds.Write(bw);
            bw.WriteUInt32(m_defaultCollisionFilterInfo);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(m_materialStriding);
            bw.WriteUInt16(m_numMaterials);
            bw.WriteUInt32(0);
            bw.WriteUInt64(0);
        }
    }
}
