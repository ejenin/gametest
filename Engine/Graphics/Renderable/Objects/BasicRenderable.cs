using Engine.Helpers;
using OpenTK;
using System;
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

        public float X { get; private set; } = 0.0f;
        public float Y { get; private set; } = 0.0f;
        public float Width { get; private set; } = 0.0f;
        public float Height { get; private set; } = 0.0f;

        public BasicRenderable(float width, float height)
        {
            CreateMesh(width, height);
            CreateColor(DEFAULT_COLOR);
        }

        public BasicRenderable(float width, float height, Color color)
        {
            CreateMesh(width, height);
            CreateColor(color);
        }

        public BasicRenderable(float width, float height, float x, float y)
        {
            CreateMesh(width, height, x, y);
            CreateColor(DEFAULT_COLOR);
        }

        public BasicRenderable(float width, float height, float x, float y, Color color)
        {
            CreateMesh(width, height, x, y);
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

        public void MoveTo(float x, float y)
        {
            UpdateMesh(x, y);

            X = x;
            Y = y;
        }

        private void CreateMesh(float width, float height, float x = 0.0f, float y = 0.0f)
        {
            MeshData = new Vector3[4];

            UpdateMesh(x, y, width, height);

            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        private void UpdateMesh(float x, float y)
        {
            UpdateMesh(x, y, Width, Height);
        }

        private void UpdateMesh(float x, float y, float width, float height)
        {
            MeshMathHelper.CalculateMeshData(MeshData, width, height, x, y);
        }

        [Obsolete("Can't work stable due to unknown Width and Height")]
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