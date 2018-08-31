namespace Engine.Events.EventArgs
{
    public class UpdateFrameEventArgs
    {
        public UpdateFrameEventArgs(double elapsed)
        {
            Elapsed = elapsed;
        }

        public double Elapsed { get; set; }
    }
}
