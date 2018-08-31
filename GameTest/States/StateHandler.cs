using Engine.Graphics;
using Engine.Input;
using GameTest.States.Test;

namespace GameTest.States
{
    public class StateHandler
    {
        private StateBase _currentState;
        public KeyboardInput KeyboardInput { get; set; }

        public StateHandler(KeyboardInput keyboardInput)
        {
            KeyboardInput = keyboardInput;

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
