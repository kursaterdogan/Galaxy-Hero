using UnityEngine;
using System.Collections;
using Base.Component;

namespace Game.Components
{
    public class IntroComponent : MonoBehaviour, IComponent, IConstructable
    {
        public delegate void IntroTimeChangeDelegate(float time);

        public event IntroTimeChangeDelegate OnIntroAnimationStart;

        public delegate void IntroChangeDelegate();

        public event IntroChangeDelegate OnIntroAnimationComplete;

        private const float AnimationTime = 1.0f;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
        }

        public void OnConstruct()
        {
            StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            OnIntroAnimationStart?.Invoke(AnimationTime);

            yield return new WaitForSeconds(AnimationTime);

            OnIntroAnimationComplete?.Invoke();
        }
    }
}