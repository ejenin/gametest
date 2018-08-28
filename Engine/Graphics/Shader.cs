using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Engine.Graphics
{
    public class Shader
    {
        private int _id;

        public void ClearData()
        {
            GL.DeleteProgram(_id);
        }

        public Shader(string fragShader, string vertShader)
        {
            _id = GL.CreateProgram();
            int frag = GL.CreateShader(ShaderType.FragmentShader);
            int vert = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(frag, fragShader);
            GL.ShaderSource(vert, vertShader);
            GL.CompileShader(frag);
            Console.WriteLine(GL.GetShaderInfoLog(frag));
            GL.CompileShader(vert);
            Console.WriteLine(GL.GetShaderInfoLog(vert));
            GL.AttachShader(_id, frag);
            GL.AttachShader(_id, vert);
            GL.LinkProgram(_id);
            GL.ValidateProgram(_id);
            LoadUniformMat4f("pr_matrix", Matrix4.CreateOrthographic(16.0f, 9.0f, -1.0f, 1.0f));
        }

        public void Enable()
        {
            GL.UseProgram(_id);
        }

        public void Disable()
        {
            GL.UseProgram(0);
        }

        public void LoadUniformMat4f(string name, Matrix4 matrix)
        {
            int loc = GL.GetUniformLocation(_id, name);
            Enable();
            GL.UniformMatrix4(loc, true, ref matrix);
            Disable();
        }
    }
}
