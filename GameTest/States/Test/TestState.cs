using Engine.Graphics;
using Engine.Graphics.Renderable;
using OpenTK;

namespace GameTest.States.Test
{
    public class TestState : StateBase
    {
        private IRenderableQueue _basicRenderableQueue;

        private Vector3[] testMesh;
        private Vector3[] testMeshColor;

        public TestState (StateHandler stateHandler, Renderer renderer) : base(stateHandler)
        {
            _basicRenderableQueue = renderer.GetRenderableQueue<BasicRenderableQueue>();

            testMesh = new Vector3[8];

            testMesh[0] = new Vector3(-1.0f, 1.0f, 0.0f);
            testMesh[1] = new Vector3(1.0f, 1.0f, 0.0f);
            testMesh[2] = new Vector3(1.0f, -1.0f, 0.0f);
            testMesh[3] = new Vector3(-1.0f, -1.0f, 0.0f);

            testMesh[4] = new Vector3(-3.0f, -2.0f, 0.0f);
            testMesh[5] = new Vector3(-2.0f, -2.0f, 0.0f);
            testMesh[6] = new Vector3(-2.0f, -3.0f, 0.0f);
            testMesh[7] = new Vector3(-3.0f, -3.0f, 0.0f);

            testMeshColor = new Vector3[8];

            testMeshColor[0] = new Vector3(1.0f, 1.0f, 1.0f);
            testMeshColor[1] = new Vector3(1.0f, 1.0f, 1.0f);
            testMeshColor[2] = new Vector3(1.0f, 1.0f, 1.0f);
            testMeshColor[3] = new Vector3(1.0f, 1.0f, 1.0f);

            testMeshColor[4] = new Vector3(1.0f, 0.5f, 0.3f);
            testMeshColor[5] = new Vector3(1.0f, 0.5f, 0.3f);
            testMeshColor[6] = new Vector3(1.0f, 0.5f, 0.3f);
            testMeshColor[7] = new Vector3(1.0f, 0.5f, 0.3f);
        }

        public override void Draw(Renderer renderer)
        {
            _basicRenderableQueue.AppendData(testMesh);
            _basicRenderableQueue.AppendData(testMeshColor);
        }

        public override void Update()
        {
            //Console.WriteLine("update");
        }
    }
}
