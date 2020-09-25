using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public enum TriggerType
    {
        TRIGGER_TYPE_NONE = 0,
        TRIGGER_TYPE_BROAD_PHASE = 1,
        TRIGGER_TYPE_NARROW_PHASE = 2,
        TRIGGER_TYPE_CONTACT_SOLVER = 3,
    }
    
    public enum CombinePolicy
    {
        COMBINE_AVG = 0,
        COMBINE_MIN = 1,
        COMBINE_MAX = 2,
    }
    
    public enum MassChangerCategory
    {
        MASS_CHANGER_IGNORE = 0,
        MASS_CHANGER_DEBRIS = 1,
        MASS_CHANGER_HEAVY = 2,
    }
    
    public class hknpMaterial : IHavokObject
    {
        public string m_name;
        public uint m_isExclusive;
        public int m_flags;
        public TriggerType m_triggerType;
        public hkUFloat8 m_triggerManifoldTolerance;
        public short m_dynamicFriction;
        public short m_staticFriction;
        public short m_restitution;
        public CombinePolicy m_frictionCombinePolicy;
        public CombinePolicy m_restitutionCombinePolicy;
        public short m_weldingTolerance;
        public float m_maxContactImpulse;
        public float m_fractionOfClippedImpulseToApply;
        public MassChangerCategory m_massChangerCategory;
        public short m_massChangerHeavyObjectFactor;
        public short m_softContactForceFactor;
        public short m_softContactDampFactor;
        public hkUFloat8 m_softContactSeperationVelocity;
        public hknpSurfaceVelocity m_surfaceVelocity;
        public short m_disablingCollisionsBetweenCvxCvxDynamicObjectsDistance;
        public ulong m_userData;
        public bool m_isShared;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_name = des.ReadStringPointer(br);
            m_isExclusive = br.ReadUInt32();
            m_flags = br.ReadInt32();
            m_triggerType = (TriggerType)br.ReadByte();
            m_triggerManifoldTolerance = new hkUFloat8();
            m_triggerManifoldTolerance.Read(des, br);
            m_dynamicFriction = br.ReadInt16();
            m_staticFriction = br.ReadInt16();
            m_restitution = br.ReadInt16();
            m_frictionCombinePolicy = (CombinePolicy)br.ReadByte();
            m_restitutionCombinePolicy = (CombinePolicy)br.ReadByte();
            m_weldingTolerance = br.ReadInt16();
            m_maxContactImpulse = br.ReadSingle();
            m_fractionOfClippedImpulseToApply = br.ReadSingle();
            m_massChangerCategory = (MassChangerCategory)br.ReadByte();
            br.AssertByte(0);
            m_massChangerHeavyObjectFactor = br.ReadInt16();
            m_softContactForceFactor = br.ReadInt16();
            m_softContactDampFactor = br.ReadInt16();
            m_softContactSeperationVelocity = new hkUFloat8();
            m_softContactSeperationVelocity.Read(des, br);
            br.AssertUInt16(0);
            br.AssertByte(0);
            m_surfaceVelocity = des.ReadClassPointer<hknpSurfaceVelocity>(br);
            m_disablingCollisionsBetweenCvxCvxDynamicObjectsDistance = br.ReadInt16();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            m_userData = br.ReadUInt64();
            m_isShared = br.ReadBoolean();
            br.AssertUInt32(0);
            br.AssertUInt16(0);
            br.AssertByte(0);
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteUInt32(m_isExclusive);
            bw.WriteInt32(m_flags);
            m_triggerManifoldTolerance.Write(bw);
            bw.WriteInt16(m_dynamicFriction);
            bw.WriteInt16(m_staticFriction);
            bw.WriteInt16(m_restitution);
            bw.WriteInt16(m_weldingTolerance);
            bw.WriteSingle(m_maxContactImpulse);
            bw.WriteSingle(m_fractionOfClippedImpulseToApply);
            bw.WriteByte(0);
            bw.WriteInt16(m_massChangerHeavyObjectFactor);
            bw.WriteInt16(m_softContactForceFactor);
            bw.WriteInt16(m_softContactDampFactor);
            m_softContactSeperationVelocity.Write(bw);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            // Implement Write
            bw.WriteInt16(m_disablingCollisionsBetweenCvxCvxDynamicObjectsDistance);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteUInt64(m_userData);
            bw.WriteBoolean(m_isShared);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
        }
    }
}
