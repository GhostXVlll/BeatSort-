using UnityEngine;

namespace BeatSort
{
    public class CloseWinScreen : MonoBehaviour
    {
        private WinCanvas _winCanvas;
        private MenuCanvas _menuCanvas;

        public void Click()
        {
            _winCanvas = FindObjectOfType<WinCanvas>();
            _menuCanvas = FindObjectOfType<MenuCanvas>();

            _winCanvas.PlayHide();
            _menuCanvas.PlayShow();
        }
    }
}
