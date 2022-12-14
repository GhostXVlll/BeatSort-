using UnityEngine;

namespace BeatSort
{
    public class ItemMove : MonoBehaviour
    {
        [SerializeField] Vector3 direction;
        [SerializeField] float speed = 1;

        void FixedUpdate()
        {
            transform.Translate(direction.normalized * speed);
        }
    }
}
