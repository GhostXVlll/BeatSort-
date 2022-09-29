using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] _getters;
        public UnityEvent onFull;
        public static bool _stopSpawn = false;

        private CharAnimationPlayer _player; ///  Remove some later
        private WinCanvas _winCanvas;

        private PlayCanvas _playCanvas;     //  Relocate to State Machine
        private MenuCanvas _menuCanvas;     //  Relocate to State Machine

        private void Start()
        {
            _playCanvas = FindObjectOfType<PlayCanvas>();   //  Relocate to State Machine
            _menuCanvas = FindObjectOfType<MenuCanvas>();        //  Relocate to State Macine

            _winCanvas = FindObjectOfType<WinCanvas>();
            _player = FindObjectOfType<CharAnimationPlayer>();

            _stopSpawn = false;

            _playCanvas.PlayShow();     // Relocate to State Machine
            _menuCanvas.PlayHide();     // Relocate to State Machine

            if (_getters == null)
            {
                Debug.LogError("Getters is NULL");
                return;
            }
            foreach (var getter in _getters)
            {
                getter.getter.SetCount(getter.taggetCount);
                getter.getter.onCountChanged.AddListener(OnCountChanged);
            }
        }
        private void OnCountChanged(WallGetter getter)
        {
            for (int i = 0; i < _getters.Length; i++)
            {
                ref var item = ref _getters[i];

                if (item.getter != getter)
                { continue; }
                item.count++;
            }

            bool full = true;
            foreach (GetterParameters item in _getters)
            {
                if (item.count < item.taggetCount)
                {
                    full = false;

                    break;
                }
                else
                {
                    full = true;
                }
            }
            if (full)
            {
                _playCanvas.PlayHide();
                _winCanvas.PlayShow(); // Relocate to State Machine

                _stopSpawn = true;

                _player.PlayDancing();  /// Remove some later

                onFull.Invoke();
            }
        }

        private void OnDestroy()
        {
            foreach (var getter in _getters)
            {
                getter.getter.onCountChanged.RemoveListener(OnCountChanged);
            }
        }
    }
    [System.Serializable]
    public struct GetterParameters
    {
        public WallGetter getter;
        public int taggetCount;
        [HideInInspector] public int count;
    }
}