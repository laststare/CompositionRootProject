using CodeBase.Data;
using External.Framework;
using UniRx;
using UnityEngine;

namespace CodeBase.Cube
{
    public class CubeEntity : DisposableObject
    {
        public struct Ctx
        {
            public ContentProvider contentProvider;
            public ReactiveProperty<int> buttonClickCounter;

        }

        private Ctx _ctx;
        private CubePm _pm;
        private CubeView _view;
        private readonly ReactiveProperty<float> _rotateAngle = new ReactiveProperty<float>();
        
        public CubeEntity(Ctx ctx)
        {
            _ctx = ctx;
            CreatePm();
            CreteView();
        }

        private void CreatePm()
        {
            var cubePmCtx = new CubePm.Ctx()
            {
                buttonClickCounter = _ctx.buttonClickCounter,
                rotateAngle = _rotateAngle
            };
            _pm = new CubePm(cubePmCtx);
            AddToDisposables(_pm);
        }

        private void CreteView()
        {
            _view = Object.Instantiate(_ctx.contentProvider.cubeView, Vector3.zero, Quaternion.identity);
            _view.Init(new CubeView.Ctx()
            {
                rotateAngle = _rotateAngle
            });
        }
        
        protected override void OnDispose()
        {
            base.OnDispose();
            if(_view != null)
                Object.Destroy(_view.gameObject);
        }
    }
}