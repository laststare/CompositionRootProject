using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIviewWithButton : MonoBehaviour
    {
        public struct Ctx
        {
            public ReactiveProperty<int> buttonClickCounter;
        }

        private Ctx _ctx;
        [SerializeField] private Button button;

        public void Init(Ctx ctx)
        {
            _ctx = ctx;
            button.onClick.AddListener( () => _ctx.buttonClickCounter.Value++);
        }
    }
}