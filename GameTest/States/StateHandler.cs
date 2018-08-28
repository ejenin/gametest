using Engine.Graphics;
using GameTest.States.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.States
{
    public class StateHandler
    {
        private StateBase _currentState;

        public StateHandler()
        {
            _currentState = new TestState(this);
        }

        public void Draw(Renderer renderer)
        {
            _currentState.Draw(renderer);
        }

        public void Update()
        {
            _currentState.Update();
        }
    }
}
