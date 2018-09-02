using Engine.Graphics.Renderable.Objects;
using Engine.Shared;
using OpenTK;
using OpenTK.Graphics.ES20;
using System.Collections.Generic;

namespace Engine.Graphics.Renderable.Queues
{
    public class SpriteRenderableQueue : IRenderableQueue
    {
        private IList<ISpriteRenderable> Renderables { get; set; }
        private Shader _shader;

        //SUPER-BAD, PEREDELAT
        private IList<VertexArray> _vas { get; set; }

        public SpriteRenderableQueue()
        {
            _vas = new List<VertexArray>();
            _shader = ShadersLibrary.TEXTURE;
            Renderables = new List<ISpriteRenderable>();
        }

        public void AppendData(IRenderable renderable)
        {
            var sprite = renderable as ISpriteRenderable;
            Renderables.Add(sprite);

            var vertexArray = new VertexArray();
            _vas.Add(vertexArray);
        }

        public bool CanRender(IRenderable renderable)
        {
            if (renderable is ISpriteRenderable)
                return true;
            return false;
        }

        public void Clear()
        {
            Renderables.Clear();
            foreach (var item in _vas)
            {
                item.ClearData();
            }
            _vas.Clear();
        }

        public void Draw()
        {
            _shader.Enable();
            for (int i = 0; i < Renderables.Count; i++)
            {
                Renderables[i].Texture.Bind();
                _vas[i].Bind();
                GL.DrawArrays(PrimitiveType.Quads, 0, Constants.VERTICES_PER_OBJECT);
                _vas[i].Unbind();
            }
            _shader.Disable();
        }

        public void Prepare()
        {
            for (int i = 0; i < Renderables.Count; i++)
            {
                var sprite = Renderables[i];
                _vas[i].InitData();
                _vas[i].AppendBuffer(sprite.MeshData, 0);
                _vas[i].AppendBuffer(sprite.TextureData, 1);
            }
        }
    }
}
