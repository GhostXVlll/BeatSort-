using UnityEngine;

namespace BeatSort
{
    public class WinCanvasNextButton : MonoBehaviour
    {
        private WinCanvas _winCanvas;
        private LoadLevel _loadLevel;

        public void Show()
        {
            _winCanvas = FindObjectOfType<WinCanvas>();
            _loadLevel = FindObjectOfType<LoadLevel>();

            _loadLevel.NextLevel();
            _winCanvas.PlayHide();
        }
    }
}
