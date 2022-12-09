using External.Framework;
using UniRx;

namespace CodeBase.Cube
{
    public class CubePm : DisposableObject
    {
        public struct Ctx
        {
            public ReactiveProperty<float> rotateAngle;
            public ReactiveProperty<int> buttonClickCounter;
        }

        private Ctx _ctx;
        
        public CubePm(Ctx ctx)
        {
            _ctx = ctx;
            AddToDisposables(_ctx.buttonClickCounter.Subscribe(AddRotationAngle));
        }

        private void AddRotationAngle(int clickCount)
        {
            _ctx.rotateAngle.Value = clickCount * 30;
        }
    }
}