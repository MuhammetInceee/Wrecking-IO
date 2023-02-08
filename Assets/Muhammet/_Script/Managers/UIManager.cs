using UnityEngine;
using WreckingOI.Signals;

namespace WreckingOI.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject win;
        [SerializeField] private GameObject lose;

        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void OnDisable()
        {
            UnSubscribeEvent();
        }

        private void SubscribeEvent()
        {
            UISignals.OnLevelFail += LoseScreen;
            UISignals.OnLevelSuccess += WinScreen;
        }

        private void UnSubscribeEvent()
        {
            UISignals.OnLevelFail -= LoseScreen;
            UISignals.OnLevelSuccess -= WinScreen;
        }


        private void LoseScreen()
        {
            lose.SetActive(true);
        }

        private void WinScreen()
        {
            win.SetActive(true);
        }
    }
}
