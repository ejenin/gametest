namespace Engine.Shared
{
    public static class Constants
    {
        public static int WINDOW_WIDTH = 1280;
        public static int WINDOW_HEIGHT = 720;
        public static string WINDOW_TITLE = "Engine Test";
        public static double FRAMES_PER_SECOND = 60.0d;
        public static double UPDATES_PER_SECOND = 60.0d;
        public static bool CALC_FPS = false;

        /// <summary>
        /// СЧЁТ ВЕРШИН НАЧИНАЕТСЯ С ВЕРХНЕЙ ЛЕВОЙ ПО ЧАСОВОЙ СТРЕЛКЕ
        /// </summary>
        public static int VERTICES_PER_OBJECT = 4;

        #region Shaders
        public static string BASIC_VERT_SHADER = @"#version 330 core
layout(location = 0) in vec3 coordinate;
layout(location = 1) in vec3 color;

out vec3 outcolor;

uniform mat4 pr_matrix;
uniform mat4 vw_matrix = mat4(1.0);
uniform mat4 ml_matrix = mat4(1.0);

void main()
{
	gl_Position = vec4(coordinate, 1.0) * ml_matrix * vw_matrix * pr_matrix;
	outcolor = color;
}";

        public static string BASIC_FRAG_SHADER = @"#version 330 core
out vec4 color;

in vec3 outcolor;

        uniform sampler2D tex;

void main()
        {
            color = vec4(outcolor, 1.0);
        }";
        #endregion
    }
}
