using Engine.Graphics;
using Engine.Graphics.Renderable.Objects;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameTest.States.Test
{
    public class TestState : StateBase
    {
        private ICollection<BasicRenderable> objects;

        public TestState (StateHandler stateHandler) : base(stateHandler)
        {
            Random rnd = new Random();
            objects = new List<BasicRenderable>();
            for (int i = 0; i < 2; i++)
            {
                //-8.0f  - 8.0d
                //-4.5f  - 4.5f
                float x = rnd.Next(-8000, 8000) / 1000.0f;
                float y = rnd.Next(-4500, 4500) / 1000.0f;

                float r = (float)rnd.NextDouble();
                float g = (float)rnd.NextDouble();
                float b = (float)rnd.NextDouble();

                var testMesh = new Vector3[4];

                testMesh[0] = new Vector3(x + -1.0f, y + 1.0f, 0.0f);
                testMesh[1] = new Vector3(x + 1.0f, y + 1.0f, 0.0f);
                testMesh[2] = new Vector3(x + 1.0f, y + -1.0f, 0.0f);
                testMesh[3] = new Vector3(x + -1.0f, y + -1.0f, 0.0f);

                var testMeshColor = new Vector3[4];

                testMeshColor[0] = new Vector3(r, g, b);
                testMeshColor[1] = new Vector3(r, g, b);
                testMeshColor[2] = new Vector3(r, g, b);
                testMeshColor[3] = new Vector3(r, g, b);
                objects.Add(new BasicRenderable(testMesh, testMeshColor));
            }

            objects.Add(new BasicRenderable(0.5f, 0.5f, 1.0f, 0.0f, Color.AliceBlue));
        }

        public override void Draw(Renderer renderer)
        {
            foreach (var item in objects)
            {
                renderer.AppendRenderable(item);
            }
        }

        public override void Update()
        {
        }
    }
}
