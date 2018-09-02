using OpenTK;

namespace Engine.Graphics.Renderable.Objects
{
    interface ISpriteRenderable : IRenderable
    {
        //TODO: атлас?
        Texture Texture { get; set; }
        Vector3[] MeshData { get; set; }
        Vector3[] TextureData { get; set; }
    }
}
