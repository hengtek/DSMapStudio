using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclSkinSetupObject : hclOperatorSetupObject
    {
        public string m_name;
        public hclTransformSetSetupObject m_transformSetSetup;
        public hclBufferSetupObject m_referenceBufferSetup;
        public hclBufferSetupObject m_outputBufferSetup;
        public hclVertexSelectionInput m_vertexSelection;
        public bool m_skinNormals;
        public bool m_skinTangents;
        public bool m_skinBiTangents;
        public bool m_useDualQuaternionMethod;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_name = des.ReadStringPointer(br);
            m_transformSetSetup = des.ReadClassPointer<hclTransformSetSetupObject>(br);
            m_referenceBufferSetup = des.ReadClassPointer<hclBufferSetupObject>(br);
            m_outputBufferSetup = des.ReadClassPointer<hclBufferSetupObject>(br);
            m_vertexSelection = new hclVertexSelectionInput();
            m_vertexSelection.Read(des, br);
            m_skinNormals = br.ReadBoolean();
            m_skinTangents = br.ReadBoolean();
            m_skinBiTangents = br.ReadBoolean();
            m_useDualQuaternionMethod = br.ReadBoolean();
            br.AssertUInt32(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
            // Implement Write
            // Implement Write
            m_vertexSelection.Write(bw);
            bw.WriteBoolean(m_skinNormals);
            bw.WriteBoolean(m_skinTangents);
            bw.WriteBoolean(m_skinBiTangents);
            bw.WriteBoolean(m_useDualQuaternionMethod);
            bw.WriteUInt32(0);
        }
    }
}
