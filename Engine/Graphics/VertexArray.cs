using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Engine.Graphics
{
    public class VertexArray
    {
        private int _vao;
        private ICollection<int> _vbos;

        public VertexArray()
        {
            _vbos = new List<int>();
        }

        public void AppendBuffer(Vector3[] data, int index)
        {
            Bind();
            int bufferId = index;
            int vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * data.Length), data, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(bufferId);
            GL.VertexAttribPointer(bufferId, 3, VertexAttribPointerType.Float, false, 0, 0);
            _vbos.Add(vbo);
            Unbind();
        }

        public void InitData()
        {
            _vao = GL.GenVertexArray();
        }

        public void ClearData()
        {
            foreach (var vbo in _vbos)
            {
                GL.DeleteBuffer(vbo);
            }
            _vbos.Clear();

            GL.DeleteVertexArray(_vao);
        }

        public void Bind()
        {
            GL.BindVertexArray(_vao);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }
    }
}
