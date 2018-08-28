using System;
using Engine.Graphics;

namespace GameTest.States.Test
{
    public class TestState : StateBase
    {
        public TestState (StateHandler stateHandler) : base(stateHandler)
        {
        }

        public override void Draw(Renderer renderer)
        {
            //renderer.SayHello();
        }

        public override void Update()
        {
            //Console.WriteLine("update");
        }
    }
}
