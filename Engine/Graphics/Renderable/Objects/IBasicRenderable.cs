using OpenTK;

namespace Engine.Graphics.Renderable.Objects
{
    public interface IBasicRenderable : IRenderable
    {
        Vector3[] MeshData { get; set; }
        Vector3[] ColorData { get; set; }
    }
}
