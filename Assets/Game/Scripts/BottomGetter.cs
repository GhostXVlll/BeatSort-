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
            Destroy(_cube.gameObject);
        }
    }
}
