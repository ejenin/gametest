using Engine.Graphics.Renderable;
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
        }
        
        internal void BeforeDraw()
        {
            GL.ClearColor(Color4.Black);
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
            ShadersLibrary.BASIC.Disable();
            foreach (var queue in _queues)
            {
                queue.Clear();
            }
        }

        public IRenderableQueue GetRenderableQueue<T>()
        {
            var queue = _queues.Where(q => q is T).FirstOrDefault();
            return queue;
        }
    }
}
