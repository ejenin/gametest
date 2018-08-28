using Engine.Graphics;

namespace Engine.Events.EventArgs
{
    public class RenderFrameEventArgs
    {
        public RenderFrameEventArgs(Renderer renderer)
        {
            Renderer = renderer;
        }

        public Renderer Renderer { get; }
    }
}
