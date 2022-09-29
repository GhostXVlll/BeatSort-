using UnityEngine;

namespace BeatSort
{
    public class PlayCanvas : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");

        public void PlayShow()
        {
            _animator.SetTrigger(Open);
        }

        public void PlayHide()
        {
            _animator.SetTrigger(Close);
        }
    }
}