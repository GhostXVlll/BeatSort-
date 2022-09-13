using UnityEngine;

namespace BeatSort
{
    public class VFXResetClickPool : MonoBehaviour
    {
        [SerializeField] private VFXClickPool _pool;

        private void OnDisable()
        {
            _pool.ResetPool();
        }
    }
}
