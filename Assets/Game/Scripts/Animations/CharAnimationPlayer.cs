using UnityEngine;

namespace BeatSort
{
    public class CharAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _anim;

        private static readonly int Rejected = Animator.StringToHash("Rejected");
        private static readonly int Dancing = Animator.StringToHash("Dancing");

        private void Start()
        {
            //PlayRejected();
        }

        public void PlayRejected()
        {
            _anim.SetTrigger(Rejected);
            Debug.Log("Rejected");
        }

        public void PlayDancing()
        {
            _anim.SetTrigger(Dancing);
            Debug.Log("Dancing");
        }
    }
}