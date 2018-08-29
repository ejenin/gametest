using OpenTK;

namespace Engine.Graphics.Renderable.Objects
{
    public class BasicRenderable : IBasicRenderable
    {
        public Vector3[] MeshData { get; set; }
        public Vector3[] ColorData { get; set; }

        public BasicRenderable(Vector3[] meshData, Vector3[] colorData)
        {
            MeshData = meshData;
            ColorData = colorData;
        }

        public void PassData(IRenderableQueue queue)
        {
            queue.AppendData(this);
        }
    }
}
