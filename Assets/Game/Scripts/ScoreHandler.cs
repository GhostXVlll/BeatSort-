using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] _getters;
        public UnityEvent onFull;
        public static bool _stopSpawn = false;

        LoadLevel _loadLevel;
        //WinCanvas _canvas;
        CharAnimationPlayer _player;

        private void Start()
        {
            //_canvas = GetComponent<WinCanvas>();//
            _loadLevel = GetComponent<LoadLevel>();
            _player = GetComponent<CharAnimationPlayer>();

            _stopSpawn = false;
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
                //_canvas.PlayShow();
                _stopSpawn = true;
                _player.PlayDancing();
                //_loadLevel.NextLevel(); //

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