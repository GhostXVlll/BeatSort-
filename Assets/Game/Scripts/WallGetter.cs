using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Write cube destroy on triggers is full!

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

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
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

                if (_item.Type == type)             //Correct cube swipe
                {
                    _material.color = Color.green;
                    //Debug.Log("<color=green> NICE! </color>");
                }
                else
                {                                   //Incorrect cube swipe     
                    //Debug.Log("<color=red> INCORRECT! </color>");
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


        //------------------------Selfwritting methodS----------------//

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