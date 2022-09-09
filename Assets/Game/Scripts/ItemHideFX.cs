using UnityEngine;

namespace BeatSort
{
    public class ItemHideFX : MonoBehaviour
    {
        //[SerializeField] private GameObject _hideFxPrefab;
        [SerializeField] private VFXPoolProvider _poolProvider;

        public void Hide()
        {
            //Instantiate(_hideFxPrefab, transform.position, Quaternion.identity, null);

            VFXPoolItem poolItem = _poolProvider.VFXPool.GetFromPool();
            poolItem.transform.position = transform.position;
            poolItem.ParticleSystem.Play();
            Destroy(this.gameObject);
        }
    }
}
