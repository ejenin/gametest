using Engine.Shared;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;

namespace Engine.Graphics
{
    public class Renderer
    {
        //private VertexArray _vertexArray;

        //private Vector3[] testMesh;
        //private Vector3[] testMeshColor;

        //группировать по шейдеру\количеству вершин?
        private ICollection<VertexArray> _vertexArrays;

        public Renderer()
        {
            _vertexArrays = new List<VertexArray>();
            var _vertexArray = new VertexArray();

            _vertexArrays.Add(_vertexArray);
        }
        
        internal void BeforeDraw()
        {
            GL.ClearColor(Color4.Black);
            foreach (var array in _vertexArrays)
            {
                array.InitData();

                var testMesh = new Vector3[8];

                testMesh[0] = new Vector3(-1.0f, 1.0f, 0.0f);
                testMesh[1] = new Vector3(1.0f, 1.0f, 0.0f);
                testMesh[2] = new Vector3(1.0f, -1.0f, 0.0f);
                testMesh[3] = new Vector3(-1.0f, -1.0f, 0.0f);

                testMesh[4] = new Vector3(-3.0f, -2.0f, 0.0f);
                testMesh[5] = new Vector3(-2.0f, -2.0f, 0.0f);
                testMesh[6] = new Vector3(-2.0f, -3.0f, 0.0f);
                testMesh[7] = new Vector3(-3.0f, -3.0f, 0.0f);

                var testMeshColor = new Vector3[8];

                testMeshColor[0] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[1] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[2] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[3] = new Vector3(1.0f, 1.0f, 1.0f);

                testMeshColor[4] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[5] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[6] = new Vector3(1.0f, 1.0f, 1.0f);
                testMeshColor[7] = new Vector3(1.0f, 1.0f, 1.0f);
                array.AppendBuffer(testMesh);
                array.AppendBuffer(testMeshColor);
            }
            //_vertexArray.InitData();
            ShadersLibrary.BASIC.Enable();
            //_vertexArray.AppendBuffer();
        }

        internal void DrawFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            foreach (var array in _vertexArrays)
            {
                array.Bind();
                GL.DrawArrays(PrimitiveType.Quads, 0, 8);
                array.Unbind();
            }
        }

        internal void AfterDraw()
        {
            ShadersLibrary.BASIC.Disable();
            foreach (var array in _vertexArrays)
            {
                array.ClearData();
            }
        }
    }
}
