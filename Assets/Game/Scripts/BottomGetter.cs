using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeatSort
{
    public class BottomGetter : MonoBehaviour
    {
        private DragItem _cube;
        private void OnTriggerEnter(Collider other)
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();
            _cube = item;
            TryGetItem();

        }

        private void TryGetItem()
        {
            //Debug.Log("ITEM: " + _cube + " LOSED.");
            Destroy(_cube.gameObject);
        }
    }
}
