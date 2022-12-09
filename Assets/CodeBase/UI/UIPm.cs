using External.Framework;
using UniRx;
using UnityEngine;

namespace CodeBase.UI
{
    public class UIPm : DisposableObject
    {
        public struct Ctx
        {
            public ReactiveProperty<int> buttonClickCounter;
        }

        private Ctx _ctx;
        
        public UIPm(Ctx ctx)
        {
            _ctx = ctx;
            _ctx.buttonClickCounter.Subscribe(ShowClicks);
        }

        private void ShowClicks(int click)
        {
            Debug.Log($"clicks: {click}");
        }
    }
}