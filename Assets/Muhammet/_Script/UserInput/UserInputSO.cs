using UnityEngine;

namespace WreckingOI.UserInput
{
    [CreateAssetMenu(menuName = "WreckingIO/UserInput/UserInputController")]
    public class UserInputSO : ScriptableObject
    {
        [SerializeField] private float movementSpeed;
        public float MovementSpeed => movementSpeed;

        [SerializeField] private float rotateSpeed;
        public float RotateSpeed => rotateSpeed;
    }
}