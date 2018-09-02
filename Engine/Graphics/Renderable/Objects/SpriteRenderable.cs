using Engine.Helpers;
using OpenTK;
using System.Drawing;

namespace Engine.Graphics.Renderable.Objects
{
    public class SpriteRenderable : ISpriteRenderable
    {
        public Texture Texture { get; set; }
        public Vector3[] MeshData { get; set ; }
        public Vector3[] TextureData { get; set; }

        public SpriteRenderable(float width, float height, float x, float y, Bitmap texture)
        {
            CreateMesh(width, height, x, y);
            Texture = new Texture(texture);

            TextureData = new Vector3[4];
            TextureData[0] = new Vector3(0.0f, 0.0f, 0.0f);
            TextureData[1] = new Vector3(1.0f, 0.0f, 0.0f);
            TextureData[2] = new Vector3(1.0f, 1.0f, 0.0f);
            TextureData[3] = new Vector3(0.0f, 1.0f, 0.0f);
        }

        private void CreateMesh(float width, float height, float x = 0.0f, float y = 0.0f)
        {
            MeshData = new Vector3[4];

            UpdateMesh(width, height, x, y);
        }

        private void UpdateMesh(float width, float height, float x, float y)
        {
            MeshMathHelper.CalculateMeshData(MeshData, width, height, x, y);
        }

        public void PassData(IRenderableQueue queue)
        {
            queue.AppendData(this);
        }
    }
}
