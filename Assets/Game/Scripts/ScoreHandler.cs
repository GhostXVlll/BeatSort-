using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] _getters;
        public UnityEvent onFull;
        public static bool _stopSpawn = false;

        private void Start()
        {
            _stopSpawn = false;
            if (_getters == null)
            {
                Debug.LogError("<color=orange>Getters is NULL</color>");
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
                    //Debug.Log("<color=yellow>NOT FULL</color>");

                    break;
                }
                else
                {
                    full = true;
                    //Debug.Log("<color=black>FULL</color>");
                }
            }
            if (full)
            {
                onFull.Invoke();
                _stopSpawn = true;
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
