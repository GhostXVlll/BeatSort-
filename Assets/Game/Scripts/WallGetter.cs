using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    public class WallGetter : MonoBehaviour
    {
        [SerializeField] private ItemType type;
        private DragItem _item;
        private Material _material;
        private Color _defaultColor;
        private bool active = true;

        private int targetCount = 1;
        private int count = 0;

        public UnityEvent<WallGetter> onCountChanged;
        public UnityEvent OnClick;

        AnimateVolumeWieght _flash;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
            _flash = GetComponent<AnimateVolumeWieght>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (active)
            {
                OnClick.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!active)
            {
                return;
            }
            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (item != null && item.isDraggable == true)
            {
                _item = item;

                if (_item.Type == type)
                {  //Correct cube swipe
                    _material.color = Color.green;
                    _flash.Animate();
                }
                else
                {       //Incorrect cube swipe     
                    _material.color = Color.red;
                }
                return;
            }
            if (item.isDraggable == false && _item == item)
            {
                _item = null;

                return;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!active)
                return;

            var item = other.attachedRigidbody.GetComponent<DragItem>();
            if (_item == item)
            {
                _material.color = _defaultColor;

                if (item.isDraggable == false)
                {
                    DelItem();
                    _item.OnHideRequest.Invoke();
                }
                _item = null;
            }
        }

        private void DelItem()
        {
            Destroy(_item.gameObject);

            if (_item.Type == type)
            {
                count++;
                onCountChanged.Invoke(this);
            }

            if (count >= targetCount)
            {
                _material.color = Color.cyan;
                active = false;
            }
        }

        public void SetCount(int value)
        {
            targetCount = value;
            if (count >= targetCount)
            {
                _material.color = Color.cyan;
                active = false;
            }
        }
    }
}