using OpenTK;

namespace Engine.Graphics.Renderable
{
    public interface IRenderableQueue
    {
        //todo: абстрагировать от Vector3
        void AppendData(Vector3[] data);
        void Prepare();
        void Draw();
        void Clear();
    }
}
