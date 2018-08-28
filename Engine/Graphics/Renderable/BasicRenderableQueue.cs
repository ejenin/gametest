using Engine.Shared;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace Engine.Graphics.Renderable
{
    public class BasicRenderableQueue : IRenderableQueue
    {
        private VertexArray _vertexArray;
        private Shader _shader;

        public BasicRenderableQueue()
        {
            _shader = ShadersLibrary.BASIC;
            _vertexArray = new VertexArray();
        }

        public void AppendData(Vector3[] data)
        {
            _vertexArray.AppendBuffer(data);
        }

        public void Clear()
        {
            _vertexArray.ClearData();
        }

        public void Draw()
        {
            _shader.Enable();

            _vertexArray.Bind();
            GL.DrawArrays(PrimitiveType.Quads, 0, 8);
            _vertexArray.Unbind();

            _shader.Disable();
        }

        public void Prepare()
        {
            _vertexArray.InitData();
        }
    }
}
