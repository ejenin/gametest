using Engine.Graphics;

namespace GameTest.States
{
    public abstract class StateBase
    {
        private StateHandler _stateHandler;

        protected StateBase(StateHandler stateHandler)
        {
            _stateHandler = stateHandler;
        }

        public abstract void Draw(Renderer renderer);
        public abstract void Update();
    }
}
