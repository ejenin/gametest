using Engine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
