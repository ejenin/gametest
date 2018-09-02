using Engine.Graphics;
using Engine.Graphics.Renderable.Objects;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameTest.States.Test
{
    public class TestState : StateBase
    {
        private ICollection<BasicRenderable> objects;
        private BasicRenderable ControllableObject;
        private ICollection<SpriteRenderable> SpriteRenderables;

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

                objects.Add(new BasicRenderable(1.0f, 1.0f, x, y, Color.FromArgb((int)(r * 255.0f), (int)(g * 255.0f), (int)(b * 255.0f))));
            }

            objects.Add(new BasicRenderable(0.5f, 0.5f, 1.0f, 0.0f, Color.AliceBlue));
            objects.Add(new BasicRenderable(0.25f, 0.25f, -8.0f, 0.0f, Color.LimeGreen));

            ControllableObject = new BasicRenderable(2.0f, 2.0f, Color.BlanchedAlmond);

            SpriteRenderables = new List<SpriteRenderable>();

            for(int i = 0; i < 4; i++)
            {
                float x = rnd.Next(-8000, 8000) / 1000.0f;
                float y = rnd.Next(-4500, 4500) / 1000.0f;

                SpriteRenderables.Add(new SpriteRenderable(1.3f, 2.0f, x, y, (Bitmap)Bitmap.FromFile("Textures//tex.png")));
            }
        }

        public override void Draw(Renderer renderer)
        {
            foreach (var item in objects)
            {
                renderer.AppendRenderable(item);
            }
            renderer.AppendRenderable(ControllableObject);

            foreach (var item in SpriteRenderables)
            {
                renderer.AppendRenderable(item);
            }
        }

        bool moving = false;

        public override void Update()
        {
            if (KeyboardInput.IsKeyDown(Key.Up))
            {
                ControllableObject.MoveTo(ControllableObject.X, ControllableObject.Y + 0.05f);
            }
            if (KeyboardInput.IsKeyDown(Key.Down))
            {
                ControllableObject.MoveTo(ControllableObject.X, ControllableObject.Y - 0.05f);
            }
            if (KeyboardInput.IsKeyDown(Key.Left))
            {
                ControllableObject.MoveTo(ControllableObject.X - 0.05f, ControllableObject.Y);
            }
            if (KeyboardInput.IsKeyDown(Key.Right))
            {
                ControllableObject.MoveTo(ControllableObject.X + 0.05f, ControllableObject.Y);
            }

            if (KeyboardInput.IsKeyPressed(Key.Space))
            {
                moving = !moving;
            }

            if (moving)
            {
                foreach (var item in objects)
                {
                    var x = item.X + 0.1f;

                    if (x > 8.0f)
                    {
                        x = -8.0f;
                    }

                    var y = (float)Math.Sin(x);

                    item.MoveTo(x, y);
                }
            }
        }
    }
}
