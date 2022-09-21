using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BeatSort
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private ItemType type;
        public UnityEvent OnHideRequest;
        public ItemType Type { get => type; }
        private Rigidbody _rigidbody;
        public bool isDraggable { get; private set; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                isDraggable = false;
                return;
            }
            var pos = eventData.pointerCurrentRaycast.worldPosition;
            var delta = pos - transform.position;
            delta.y = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            isDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _rigidbody.isKinematic = false;
            isDraggable = false;
        }
    }
}
