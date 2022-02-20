using UnityEngine;
using Base.Component;
using Game.Gameplay;
using Game.UserInterfaces.InGame;

namespace Game.Components
{
    public class GameplayComponent : MonoBehaviour, IComponent, IStartable, IExitable
    {
        [SerializeField] private GameObject[] parallaxBackgroundPrefabs;
        [SerializeField] private ProjectilePool projectilePoolPrefab;
        [SerializeField] private Player playerPrefab;

        private GameObject _parallaxBackground;
        private ProjectilePool _projectilePool;
        private Player _player;

        private UIComponent _uiComponent;
        private InGameCanvas _inGameCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>GameplayComponent initialized!</color>");

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;

            _inGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.InGame) as InGameCanvas;
        }

        public void CallStart()
        {
            //TODO Method
            _parallaxBackground = Instantiate(parallaxBackgroundPrefabs[0]);
            _projectilePool = Instantiate(projectilePoolPrefab);
            _player = Instantiate(playerPrefab);
        }

        public void CallExit()
        {
            //TODO Method
            Destroy(_player.gameObject);
            Destroy(_projectilePool.gameObject);
            Destroy(_parallaxBackground.gameObject);
        }
    }
}