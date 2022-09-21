using UnityEngine;

namespace BeatSort
{
    public class ItemHideFX : MonoBehaviour
    {
        [SerializeField] private VFXPoolProvider _poolProvider;

        public void Hide()
        {
            VFXPoolItem poolItem = _poolProvider.VFXPool.GetFromPool();
            poolItem.transform.position = transform.position;
            poolItem.ParticleSystem.Play();
            Destroy(this.gameObject);
        }
    }
}
