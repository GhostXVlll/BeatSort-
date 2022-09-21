using System.Collections;
using UnityEngine;

namespace BeatSort
{
    public class ItemAnimateColor : MonoBehaviour
    {
        [SerializeField] private Color _destinationColor = Color.magenta;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _animationTime = 0.3f;

        private bool _isAnimate = false;
        private Material _itemMaterial;
        private Color _itemSrcColor;
        private float _elapsedTime;

        private void Awake()
        {
            _itemMaterial = _meshRenderer.material;
            _itemSrcColor = _itemMaterial.color;
        }

        public void Animate()
        {
            if (_isAnimate)
            {
                return;
            }

            _isAnimate = true;

            _elapsedTime = 0f;
            StartCoroutine(AnimateColor());
        }

        protected IEnumerator AnimateColor()
        {
            while (_elapsedTime < _animationTime)
            {
                yield return new WaitForEndOfFrame();

                _itemMaterial.color = Color.Lerp(_itemSrcColor, _destinationColor,
                    Mathf.PingPong(2 * _elapsedTime / _animationTime, 1));

                _elapsedTime += Time.deltaTime;
            }
            _isAnimate = false;
        }
    }
}
