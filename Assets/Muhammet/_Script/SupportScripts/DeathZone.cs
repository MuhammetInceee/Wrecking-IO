using UnityEngine;
using WreckingOI.Character;
using WreckingOI.Signals;

namespace WreckingOI.SupportScripts.Collisions
{
    public class DeathZone : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Character.Character character))
            {
                CoreGameSignals.OnDeath.Invoke(character.gameObject);
                character.DestroyYourself(); 
                CoreGameSignals.OnLevelCheck.Invoke();
            }
        }
    }
}
