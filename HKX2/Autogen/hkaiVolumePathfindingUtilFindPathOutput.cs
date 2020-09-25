using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkaiVolumePathfindingUtilFindPathOutput : hkReferencedObject
    {
        public List<uint> m_visitedCells;
        public List<hkaiPathPathPoint> m_pathOut;
        public hkaiAstarOutputParameters m_outputParameters;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_visitedCells = des.ReadUInt32Array(br);
            m_pathOut = des.ReadClassArray<hkaiPathPathPoint>(br);
            m_outputParameters = new hkaiAstarOutputParameters();
            m_outputParameters.Read(des, br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            m_outputParameters.Write(bw);
        }
    }
}
