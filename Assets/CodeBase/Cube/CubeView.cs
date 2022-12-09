using UniRx;
using UnityEngine;

namespace CodeBase.Cube
{
    public class CubeView: MonoBehaviour
    {
        public struct Ctx
        {
            public ReactiveProperty<float> rotateAngle;
        }

        private Ctx _ctx;

        public void Init(Ctx ctx)
        {
            _ctx = ctx;
            _ctx.rotateAngle.Subscribe(RotateMe).AddTo(this);
        }

        private void RotateMe(float angle)
        {
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}