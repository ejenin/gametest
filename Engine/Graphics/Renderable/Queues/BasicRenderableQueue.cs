using Engine.Graphics.Renderable.Objects;
using Engine.Shared;
using OpenTK;
using OpenTK.Graphics.ES20;
using System.Collections.Generic;

namespace Engine.Graphics.Renderable.Queues
{
    public class BasicRenderableQueue : IRenderableQueue
    {
        private VertexArray _vertexArray;
        private Shader _shader;

        public BasicRenderableQueue()
        {
            _shader = ShadersLibrary.BASIC;
            _vertexArray = new VertexArray();

            RenderablesToDraw = new List<IBasicRenderable>();
        }

        private ICollection<IBasicRenderable> RenderablesToDraw { get; set; }

        private List<Vector3> MeshData = new List<Vector3>();
        private List<Vector3> ColorData = new List<Vector3>();

        private void AppendData(IBasicRenderable renderable)
        {
            RenderablesToDraw.Add(renderable);
        }

        public void AppendData(IRenderable renderable)
        {
            AppendData(renderable as IBasicRenderable);
        }

        public bool CanRender(IRenderable renderable)
        {
            if (renderable is IBasicRenderable)
                return true;
            return false;
        }

        public void Clear()
        {
            _vertexArray.ClearData();
            RenderablesToDraw.Clear();
            MeshData.Clear();
            ColorData.Clear();
        }

        public void Draw()
        {
            _shader.Enable();

            _vertexArray.Bind();
            GL.DrawArrays(PrimitiveType.Quads, 0, Constants.VERTICES_PER_OBJECT * RenderablesToDraw.Count);
            _vertexArray.Unbind();

            _shader.Disable();
        }

        public void Prepare()
        {
            _vertexArray.InitData();
            
            foreach (var item in RenderablesToDraw)
            {
                MeshData.AddRange(item.MeshData);
                ColorData.AddRange(item.ColorData);
            }

            _vertexArray.AppendBuffer(MeshData.ToArray(), 0);
            _vertexArray.AppendBuffer(ColorData.ToArray(), 1);
        }
    }
}
