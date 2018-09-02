using OpenTK;

namespace Engine.Helpers
{
    public static class MeshMathHelper
    {
        public static void CalculateMeshData(Vector3[] mesh, float width, float height, float x, float y)
        {
            mesh[0] = new Vector3(x - width * 0.5f, y + height * 0.5f, 0.0f);
            mesh[1] = new Vector3(x + width * 0.5f, y + height * 0.5f, 0.0f);
            mesh[2] = new Vector3(x + width * 0.5f, y - height * 0.5f, 0.0f);
            mesh[3] = new Vector3(x - width * 0.5f, y - height * 0.5f, 0.0f);
        }
    }
}
