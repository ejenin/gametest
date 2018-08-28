using Engine.Events.EventArgs;

namespace Engine.Events
{
    public delegate void FrameRender(object sender, RenderFrameEventArgs args);
    public delegate void FrameUpdate(object sender, UpdateFrameEventArgs args);
}