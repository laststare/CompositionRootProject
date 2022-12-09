using CodeBase.Cube;
using CodeBase.Data;
using CodeBase.UI;
using External.Framework;
using UniRx;
using UnityEngine;

namespace CodeBase.Game
{
    public class GameEntity : DisposableObject
    {
        public struct Ctx
        {
            public ContentProvider contentProvider;
            public RectTransform uiRoot;
        }
        
        private readonly Ctx _ctx;
        private UIEntity _uiEntity;
        private CubeEntity _cubeEntity;
        private readonly ReactiveProperty<int> _buttonClickCounter = new ReactiveProperty<int>();

        
        public GameEntity(Ctx ctx)
        {
            _ctx = ctx;
            CreateUIEntity();
            CreteCubeEntity();
        }

        private void CreateUIEntity()
        {
            var UIEntityCtx = new UIEntity.Ctx()
            {
                contentProvider = _ctx.contentProvider,
                uiRoot = _ctx.uiRoot,
                buttonClickCounter = _buttonClickCounter
            };
            _uiEntity = new UIEntity(UIEntityCtx);
            AddToDisposables(_uiEntity);
        }

        private void CreteCubeEntity()
        {
            var cubeEntityCtx = new CubeEntity.Ctx()
            {
                contentProvider = _ctx.contentProvider,
                buttonClickCounter = _buttonClickCounter
            };
            _cubeEntity = new CubeEntity(cubeEntityCtx);
            AddToDisposables(_cubeEntity);
        }
    }
}