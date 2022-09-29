using UnityEngine;

namespace BeatSort
{
    public class CharAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int Rejected = Animator.StringToHash("Rejected");
        private static readonly int Dancing = Animator.StringToHash("Dancing");

        public void PlayRejected()
        {
            _animator.SetTrigger(Rejected);
        }

        public void PlayDancing()
        {
            _animator.SetTrigger(Dancing);
        }
    }
}