using UnityEngine;

namespace BeatSort
{
    public class VFXClickItem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        public ParticleSystem ParticleSystem => _particleSystem;

        public VFXClickPool Pool { get; set; }

        public void Return2Pool()
        {
            Pool.Return2ClickPool(this);
            gameObject.SetActive(false);
        }

        public void OnGetFromClickPool()
        {
            gameObject.SetActive(true);
        }
    }
}
