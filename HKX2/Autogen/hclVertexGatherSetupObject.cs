using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum Direction
    {
        SIMULATION_TO_DISPLAY = 0,
        DISPLAY_TO_SIMULATION = 1,
    }
    
    public class hclVertexGatherSetupObject : hclOperatorSetupObject
    {
        public string m_name;
        public Direction m_direction;
        public hclSimClothBufferSetupObject m_simulationBuffer;
        public hclVertexSelectionInput m_simulationParticleSelection;
        public hclBufferSetupObject m_displayBuffer;
        public hclVertexSelectionInput m_displayVertexSelection;
        public float m_gatherAllThreshold;
        public bool m_gatherNormals;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_name = des.ReadStringPointer(br);
            m_direction = (Direction)br.ReadUInt32();
            br.AssertUInt32(0);
            m_simulationBuffer = des.ReadClassPointer<hclSimClothBufferSetupObject>(br);
            m_simulationParticleSelection = new hclVertexSelectionInput();
            m_simulationParticleSelection.Read(des, br);
            m_displayBuffer = des.ReadClassPointer<hclBufferSetupObject>(br);
            m_displayVertexSelection = new hclVertexSelectionInput();
            m_displayVertexSelection.Read(des, br);
            m_gatherAllThreshold = br.ReadSingle();
            m_gatherNormals = br.ReadBoolean();
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt32(0);
            // Implement Write
            m_simulationParticleSelection.Write(bw);
            // Implement Write
            m_displayVertexSelection.Write(bw);
            bw.WriteSingle(m_gatherAllThreshold);
            bw.WriteBoolean(m_gatherNormals);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
