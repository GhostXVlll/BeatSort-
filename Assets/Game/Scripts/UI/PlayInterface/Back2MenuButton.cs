using UnityEngine;

namespace BeatSort
{
    public class Back2MenuButton : MonoBehaviour
    {
        private MenuCanvas _menuCanvas;
        private LoadLevel _loadLevel;
        private PlayCanvas _playCanvas;

        public void ClickBack()
        {
            _menuCanvas = FindObjectOfType<MenuCanvas>();
            _loadLevel = FindObjectOfType<LoadLevel>();
            _playCanvas = FindObjectOfType<PlayCanvas>();

            _menuCanvas.PlayShow();
            _playCanvas.PlayHide();
            _loadLevel.DestroyCurrentLevel();
        }
    }
}
