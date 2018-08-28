using Engine.Events;
using Engine.Graphics;
using Engine.Shared;
using OpenTK;
using OpenTK.Graphics;

namespace Engine.Main
{
    public class EngineWindow : GameWindow
    {
        private Renderer _renderer;
        public event FrameRender OnFrameRender;
        public event FrameUpdate OnFrameUpdate;

        public EngineWindow()
            : base(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, GraphicsMode.Default, Constants.WINDOW_TITLE)
        {
            InitializeRenderer();

            RenderFrame += EngineWindow_RenderFrame;
            UpdateFrame += EngineWindow_UpdateFrame;
        }

        private void EngineWindow_UpdateFrame(object sender, FrameEventArgs e)
        {
            OnFrameUpdate?.Invoke(this, new Events.EventArgs.UpdateFrameEventArgs());
        }

        private void EngineWindow_RenderFrame(object sender, FrameEventArgs e)
        {
            _renderer.BeforeDraw();
            OnFrameRender?.Invoke(this, new Events.EventArgs.RenderFrameEventArgs(_renderer));
            _renderer.DrawFrame();
            _renderer.AfterDraw();
            (sender as GameWindow).SwapBuffers();
        }

        public void RunEngine()
        {
            Run(Constants.UPDATES_PER_SECOND, Constants.FRAMES_PER_SECOND);
        }

        private void InitializeRenderer()
        {
            _renderer = new Renderer();
        }
    }
}