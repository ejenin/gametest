using Engine.Events.EventArgs;
using Engine.Main;
using GameTest.States;

namespace GameTest.Main
{
    public class Game
    {
        private EngineWindow _engine;
        private StateHandler _stateHandler;

        public Game()
        {
            _engine = new EngineWindow();
            _stateHandler = new StateHandler();

            _engine.OnFrameRender += OnFrameRender;
            _engine.OnFrameUpdate += OnFrameUpdate;
        }

        private void OnFrameUpdate(object sender, UpdateFrameEventArgs args)
        {
            _stateHandler.Update();
        }

        private void OnFrameRender(object sender, RenderFrameEventArgs args)
        {
            _stateHandler.Draw(args.Renderer);
        }

        public void Run()
        {
            _engine.RunEngine();
        }
    }
}