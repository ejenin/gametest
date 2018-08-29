using Engine.Graphics;
using GameTest.States.Test;

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
