using UnityEngine;

namespace BeatSort
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] protected RectTransform _rectTransformAmount;

        [Range(0, 1)]
        [SerializeField] protected float _amount = 0.5f;

        private float _initialWidth;
        private Vector2 _initialOffset;

        public float Amount
        {
            get => _amount;
            set
            {
                _amount = value;

                _amount = Mathf.Clamp(_amount, 0, 1);

                Refresh(_amount);
            }
        }
        private void Awake()
        {
            _initialWidth = _rectTransformAmount.rect.width;
            _initialOffset = _rectTransformAmount.offsetMax;
        }
        public void Refresh(float value)
        {
            float width = value * _initialWidth - _initialWidth + _initialOffset.x;
            _rectTransformAmount.offsetMax = new Vector2(width, _initialOffset.y);

        }
        private void Start()
        {
            Refresh(_amount);
        }
    }
}