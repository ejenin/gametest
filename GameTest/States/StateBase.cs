using Engine.Graphics;
using Engine.Input;

namespace GameTest.States
{
    public abstract class StateBase
    {
        private StateHandler _stateHandler;
        protected KeyboardInput KeyboardInput { get => _stateHandler.KeyboardInput; }

        protected StateBase(StateHandler stateHandler)
        {
            _stateHandler = stateHandler;
        }

        public abstract void Draw(Renderer renderer);
        public abstract void Update();
    }
}
