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
        private ICollection<IBasicRenderable> _renderablesToDraw;
        private List<Vector3> _meshData;
        private List<Vector3> _colorData;

        public BasicRenderableQueue()
        {
            _shader = ShadersLibrary.BASIC;
            _vertexArray = new VertexArray();

            _meshData = new List<Vector3>();
            _colorData = new List<Vector3>();
            _renderablesToDraw = new List<IBasicRenderable>();
        }

        private void AppendData(IBasicRenderable renderable)
        {
            _renderablesToDraw.Add(renderable);
        }

        public void AppendData(IRenderable renderable)
        {
            AppendData(renderable as IBasicRenderable);
        }

        public bool CanRender(IRenderable renderable)
        {
            return renderable is IBasicRenderable;
        }

        public void Clear()
        {
            _vertexArray.ClearData();
            _renderablesToDraw.Clear();
            _meshData.Clear();
            _colorData.Clear();
        }

        public void Draw()
        {
            _shader.Enable();

            _vertexArray.Bind();
            GL.DrawArrays(PrimitiveType.Quads, 0, Constants.VERTICES_PER_OBJECT * _renderablesToDraw.Count);
            _vertexArray.Unbind();

            _shader.Disable();
        }

        public void Prepare()
        {
            _vertexArray.InitData();
            
            foreach (var item in _renderablesToDraw)
            {
                _meshData.AddRange(item.MeshData);
                _colorData.AddRange(item.ColorData);
            }

            _vertexArray.AppendBuffer(_meshData.ToArray(), 0);
            _vertexArray.AppendBuffer(_colorData.ToArray(), 1);
        }
    }
}
