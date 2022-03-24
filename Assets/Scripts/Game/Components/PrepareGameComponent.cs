using UnityEngine;
using System.Collections;
using Base.Component;

namespace Game.Components
{
    public class PrepareGameComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void PrepareGameChangeDelegate();

        public event PrepareGameChangeDelegate OnLoadingComplete;

        private const float AnimationTime = 1.0f;

        public void Initialize(ComponentContainer componentContainer)
        {
            //TODO Handle PrepareGameComponent
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
        }

        public void OnConstruct()
        {
            StartCoroutine(PlayAnimation());
        }

        public void OnDestruct()
        {
            StopCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            yield return new WaitForSeconds(AnimationTime);

            OnLoadingComplete?.Invoke();
        }
    }
}