using UnityEngine;

namespace BeatSort
{
    public class VFXClickPoolProvider : MonoBehaviour
    {
        [SerializeField] private VFXClickPool _pool;

        public VFXClickPool VFXClickPool => _pool;

        public void Awake()
        {
            VFXClickPool.InitializePool();
        }
    }
}
