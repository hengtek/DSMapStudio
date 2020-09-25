using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum VertexIdEncoding
    {
        VERTEX_ID_ENCODING_IS_BASE_A_SHIFT = 7,
        VERTEX_ID_ENCODING_SIN_SIGN_SHIFT = 6,
        VERTEX_ID_ENCODING_COS_SIGN_SHIFT = 5,
        VERTEX_ID_ENCODING_IS_SIN_LESSER_SHIFT = 4,
        VERTEX_ID_ENCODING_VALUE_MASK = 15,
    }
    
    public class hkpCylinderShape : hkpConvexShape
    {
        public float m_cylRadius;
        public float m_cylBaseRadiusFactorForHeightFieldCollisions;
        public Vector4 m_vertexA;
        public Vector4 m_vertexB;
        public Vector4 m_perpendicular1;
        public Vector4 m_perpendicular2;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_cylRadius = br.ReadSingle();
            m_cylBaseRadiusFactorForHeightFieldCollisions = br.ReadSingle();
            m_vertexA = des.ReadVector4(br);
            m_vertexB = des.ReadVector4(br);
            m_perpendicular1 = des.ReadVector4(br);
            m_perpendicular2 = des.ReadVector4(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteSingle(m_cylRadius);
            bw.WriteSingle(m_cylBaseRadiusFactorForHeightFieldCollisions);
        }
    }
}
