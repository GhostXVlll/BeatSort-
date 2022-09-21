using UnityEngine;

namespace BeatSort
{
    public class WinCanvas : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");

        public void PlayShow()
        {
            _animator.SetTrigger(Open);
            //Debug.Log("Canvas OPEN"); //
        }

        public void PlayHide()
        {
            _animator.SetTrigger(Close);
            //Debug.Log("Canvas HIDE");
        }
    }
}