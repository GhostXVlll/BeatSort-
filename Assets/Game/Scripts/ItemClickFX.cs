using UnityEngine;
using UnityEngine.EventSystems;

namespace BeatSort
{
    public class ItemClickFX : MonoBehaviour, IPointerDownHandler
    {
        //[SerializeField] private VFXClickPoolProvider _poolProvider;

        //public void Click()
        //{
        //    VFXClickItem poolItem = _poolProvider.VFXClickPool.GetFromPool();
        //    poolItem.transform.position = transform.position;
        //    poolItem.ParticleSystem.Play();
        //    //Destroy(this.gameObject);
        //}
        [SerializeField] private GameObject _circleFXPrefab;

        public void OnPointerDown(PointerEventData eventData)
        {
            Instantiate(_circleFXPrefab, transform.position, Quaternion.identity, null);
        }
    }
}