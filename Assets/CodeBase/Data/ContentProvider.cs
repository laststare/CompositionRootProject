using CodeBase.Cube;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "GameData/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
       public UIviewWithButton uIviewWithButton;
       public CubeView cubeView;
    }
}