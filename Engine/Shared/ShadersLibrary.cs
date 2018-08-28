using Engine.Graphics;

namespace Engine.Shared
{
    public static class ShadersLibrary
    {
        static ShadersLibrary()
        {
            LoadAllShaders();
        }

        public static Shader BASIC { get; set; }

        private static void LoadAllShaders()
        {
            BASIC = new Shader(Constants.BASIC_FRAG_SHADER, Constants.BASIC_VERT_SHADER);
        }

        public static void ClearAllShaders()
        {
            BASIC.ClearData();
        }
    }
}
