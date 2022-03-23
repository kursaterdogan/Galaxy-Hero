using UnityEngine;
using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class InventoryCanvas : BaseCanvas
    {
        public delegate void InventoryRequestDelegate();

        public event InventoryRequestDelegate OnReturnToMainMenuRequest;

        [SerializeField] private Animator saturnCardAnimator;
        [SerializeField] private Animator marsCardAnimator;

        [SerializeField] private GameObject saturnDescriptionText;
        [SerializeField] private GameObject saturnUnlockText;
        [SerializeField] private GameObject marsDescriptionText;
        [SerializeField] private GameObject marsUnlockText;

        private readonly int _open = Animator.StringToHash("Open");
        private readonly int _shake = Animator.StringToHash("Shake");

        #region Changes

        public void StartSaturnCardOpen()
        {
            saturnCardAnimator.SetBool(_open, true);
            saturnDescriptionText.SetActive(true);
        }

        public void StartSaturnCardShake()
        {
            saturnCardAnimator.SetBool(_shake, true);
            saturnUnlockText.SetActive(true);
        }

        public void EndSaturnCardOpen()
        {
            saturnCardAnimator.SetBool(_open, false);
            saturnDescriptionText.SetActive(false);
        }

        public void EndSaturnCardShake()
        {
            saturnCardAnimator.SetBool(_shake, false);
            saturnUnlockText.SetActive(false);
        }

        public void StartMarsCardOpen()
        {
            marsCardAnimator.SetBool(_open, true);
            marsDescriptionText.SetActive(true);
        }

        public void StartMarsCardShake()
        {
            marsCardAnimator.SetBool(_shake, true);
            marsUnlockText.SetActive(true);
        }

        public void EndMarsCardOpen()
        {
            marsCardAnimator.SetBool(_open, false);
            marsDescriptionText.SetActive(false);
        }

        public void EndMarsCardShake()
        {
            marsCardAnimator.SetBool(_shake, false);
            marsUnlockText.SetActive(false);
        }

        #endregion

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}