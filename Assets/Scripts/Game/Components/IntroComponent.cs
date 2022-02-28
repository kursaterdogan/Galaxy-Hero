using UnityEngine;
using System.Collections;
using Base.Component;

namespace Game.Components
{
    public class IntroComponent : MonoBehaviour, IComponent, IConstructable
    {
        public delegate void IntroChangeDelegate();

        public event IntroChangeDelegate OnIntroAnimationStart;
        public event IntroChangeDelegate OnIntroAnimationComplete;

        private readonly float animationTime = 1.0f;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>IntroComponent initialized!</color>");
        }

        public void OnConstruct()
        {
            StartCoroutine(PlayAnimation());
        }

        public float GetAnimationTime()
        {
            return animationTime;
        }

        private IEnumerator PlayAnimation()
        {
            OnIntroAnimationStart?.Invoke();

            yield return new WaitForSeconds(animationTime);

            OnIntroAnimationComplete?.Invoke();
        }
    }
}