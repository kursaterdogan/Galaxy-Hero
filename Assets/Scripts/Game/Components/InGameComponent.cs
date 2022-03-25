using UnityEngine;
using Base.Component;
using Game.Gameplay;
using Game.Gameplay.Player;

namespace Game.Components
{
    public class InGameComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        [SerializeField] private GameObject[] parallaxBackgroundPrefabs;
        [SerializeField] private ProjectilePool projectilePoolPrefab;
        [SerializeField] private Player playerPrefab;

        private GameObject _parallaxBackground;
        private ProjectilePool _projectilePool;
        private Player _player;

        private UIComponent _uiComponent;
        private DataComponent _dataComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            //TODO Method
            int selectedPlanet = _dataComponent.PlanetData.selectedPlanet;
            _parallaxBackground = Instantiate(parallaxBackgroundPrefabs[selectedPlanet]);
            _projectilePool = Instantiate(projectilePoolPrefab);
            _player = Instantiate(playerPrefab);
        }

        public void OnDestruct()
        {
            //TODO Method
            Destroy(_player.gameObject);
            Destroy(_projectilePool.gameObject);
            Destroy(_parallaxBackground.gameObject);
        }
    }
}