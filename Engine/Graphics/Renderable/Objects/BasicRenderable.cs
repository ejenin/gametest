using OpenTK;
using System.Drawing;

namespace Engine.Graphics.Renderable.Objects
{
    public class BasicRenderable : IBasicRenderable
    {
        #region CONSTANTS
        private static Color DEFAULT_COLOR = Color.White;
        #endregion

        public Vector3[] MeshData { get; set; }
        public Vector3[] ColorData { get; set; }

        public BasicRenderable(float width, float height, float x, float y)
        {
            CreateGeometry(width, height, x, y);
            CreateColor(DEFAULT_COLOR);
        }

        public BasicRenderable(float width, float height, float x, float y, Color color)
        {
            CreateGeometry(width, height, x, y);
            CreateColor(color);
        }

        private void CreateColor(Color color)
        {
            ColorData = new Vector3[4];

            Vector3 colorVec = new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);

            ColorData[0] = colorVec;
            ColorData[1] = colorVec;
            ColorData[2] = colorVec;
            ColorData[3] = colorVec;
        }

        private void CreateGeometry(float width, float height, float x, float y)
        {
            MeshData = new Vector3[4];

            MeshData[0] = new Vector3(x - width * 0.5f, y + height * 0.5f, 0.0f);
            MeshData[1] = new Vector3(x + width * 0.5f, y + height * 0.5f, 0.0f);
            MeshData[2] = new Vector3(x + width * 0.5f, y - height * 0.5f, 0.0f);
            MeshData[3] = new Vector3(x - width * 0.5f, y - height * 0.5f, 0.0f);
        }

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
