using Engine.Graphics.Renderable;
using Engine.Graphics.Renderable.Queues;
using Engine.Shared;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Graphics
{
    public class Renderer
    {
        //группировать по шейдеру\количеству вершин?
        private ICollection<IRenderableQueue> _queues;

        public Renderer()
        {
            _queues = new List<IRenderableQueue>();

            _queues.Add(new BasicRenderableQueue());
            _queues.Add(new SpriteRenderableQueue());
            GL.ClearColor(Color4.Black);
        }
        
        internal void BeforeDraw()
        {
            foreach (var queue in _queues)
            {
                queue.Prepare();
            }
        }

        internal void DrawFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            foreach (var queue in _queues)
            {
                queue.Draw();
            }
        }

        internal void AfterDraw()
        {
            foreach (var queue in _queues)
            {
                queue.Clear();
            }
        }

        public void AppendRenderable(IRenderable renderable)
        {
            var queue = _queues.Where(q => q.CanRender(renderable)).FirstOrDefault();
            if (queue != null)
            {
                queue.AppendData(renderable);
            }
        }

        public void AppendRenderableTo<T>(IRenderable renderable)
            where T : IRenderableQueue
        {
            var queue = _queues.Where(q => q is T).FirstOrDefault();
            queue.AppendData(renderable);
        }
    }
}
