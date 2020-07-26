﻿using System;
using System.Collections.Generic;
using System.Text;
using Veldrid;
using Veldrid.Utilities;

namespace StudioCore.Scene
{
    /// <summary>
    /// Contains if the component is visible/valid. Valid means that there's an actual
    /// renderable in this slot, while visible means it should be rendered
    /// </summary>
    public struct VisibleValidComponent
    {
        public bool _valid;
        public bool _visible;
    }

    /// <summary>
    /// All the components needed by the indirect draw encoder to render a mesh.
    /// Batch them all together for locality
    /// </summary>
    public struct MeshDrawParametersComponent
    {
        public Renderer.IndirectDrawIndexedArgumentsPacked _indirectArgs;
        public Pipeline _pipeline;
        public ResourceSet _objectResourceSet;
        public IndexFormat _indexFormat;
        public int _bufferIndex;
    }

    /// <summary>
    /// Data oriented structure that contains renderables. This is basically a structure
    /// of arrays intended of containing all the renderables for a certain mesh. Management
    /// of how this is populated is left to a higher level system
    /// </summary>
    public class Renderables
    {
        protected const int SYSTEM_SIZE = 26000;

        private int _topIndex = 0;

        /// <summary>
        /// Component for if the renderable is visible or active
        /// </summary>
        public VisibleValidComponent[] cVisible = new VisibleValidComponent[SYSTEM_SIZE];
        public RenderKey[] cRenderKeys = new RenderKey[SYSTEM_SIZE];

        protected int GetNextInvalidIndex()
        {
            for (int i = 0; i < SYSTEM_SIZE; i++)
            {
                if (!cVisible[i]._valid)
                {
                    return i;
                }
            }
            throw new Exception("Renderable system full");
        }

        protected int AllocateValidAndVisibleRenderable()
        {
            int next = GetNextInvalidIndex();
            cVisible[next]._valid = true;
            cVisible[next]._visible = true;
            cRenderKeys[next] = new RenderKey(0);
            return next;
        }

        public void RemoveRenderable(int renderable)
        {
            cVisible[renderable]._valid = false;
        }
    }

    /// <summary>
    /// Structure for mesh renderables and all the information needed to render a single static mesh
    /// </summary>
    public class MeshRenderables : Renderables
    {
        public BoundingBox[] cBounds = new BoundingBox[SYSTEM_SIZE];
        public MeshDrawParametersComponent[] cDrawParameters = new MeshDrawParametersComponent[SYSTEM_SIZE];
        public bool[] cCulled = new bool[SYSTEM_SIZE];

        public int CreateMesh(ref BoundingBox bounds, ref MeshDrawParametersComponent drawArgs)
        {
            int idx = AllocateValidAndVisibleRenderable();
            cBounds[idx] = bounds;
            cDrawParameters[idx] = drawArgs;
            return idx;
        }

        public void CullRenderables(BoundingFrustum frustum)
        {
            for (int i = 0; i < SYSTEM_SIZE; i++)
            {
                if (!cVisible[i]._valid)
                {
                    continue;
                }
                var intersect = frustum.Contains(ref cBounds[i]);
                if (intersect == ContainmentType.Contains || intersect == ContainmentType.Intersects)
                {
                    cCulled[i] = !cVisible[i]._valid || !cVisible[i]._visible;
                }
                else
                {
                    cCulled[i] = true;
                }
            }
        }

        public void SubmitRenderables(Renderer.RenderQueue queue)
        {
            for (int i = 0; i < SYSTEM_SIZE; i++)
            {
                if (cVisible[i]._valid && !cCulled[i])
                {
                    queue.Add(i, cRenderKeys[i]);
                }
            }
        }
    }
}
