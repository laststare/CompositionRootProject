using CodeBase.Data;
using External.Framework;
using UniRx;
using UnityEngine;

namespace CodeBase.UI
{
    public class UIEntity : DisposableObject
    {
        public struct Ctx
        {
            public ContentProvider contentProvider;
            public RectTransform uiRoot;
            public ReactiveProperty<int> buttonClickCounter;
        }

        private readonly Ctx _ctx;
        private UIPm _pm;
        private UIviewWithButton _view;
        
        public UIEntity(Ctx ctx)
        {
            _ctx = ctx;
            CreatePm();
            CreateView();
        }

        private void CreatePm()
        {
            var uiPmCtx = new UIPm.Ctx()
            {
                buttonClickCounter = _ctx.buttonClickCounter
            };
            _pm = new UIPm(uiPmCtx);
            AddToDisposables(_pm);
        }

        private void CreateView()
        {
            _view = Object.Instantiate(_ctx.contentProvider.uIviewWithButton, _ctx.uiRoot);
            _view.Init(new UIviewWithButton.Ctx()
            {
                buttonClickCounter = _ctx.buttonClickCounter
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