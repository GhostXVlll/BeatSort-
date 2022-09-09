using UnityEngine;

namespace BeatSort
{
    public class VFXResetPool : MonoBehaviour
    {
        [SerializeField] private VFXPool _vfxpool;

        private void OnDisable()
        {
            _vfxpool.ResetPool();
        }
    }
}
