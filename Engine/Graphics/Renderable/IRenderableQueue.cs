namespace Engine.Graphics.Renderable
{
    public interface IRenderableQueue
    {
        bool CanRender(IRenderable renderable);
        void AppendData(IRenderable renderable);
        void Prepare();
        void Draw();
        void Clear();
    }
}
