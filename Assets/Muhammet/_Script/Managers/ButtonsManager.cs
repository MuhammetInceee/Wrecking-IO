using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WreckingOI.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
