using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BeatSort
{
    public class ItemClickFX : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameObject _circleFXPrefab;
        public UnityEvent OnClick;

        public void OnPointerDown(PointerEventData eventData)
        {
            Instantiate(_circleFXPrefab, transform.position, Quaternion.identity, null);
            OnClick.Invoke();
        }
    }
}