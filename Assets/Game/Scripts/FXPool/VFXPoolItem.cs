using UnityEngine;

namespace BeatSort
{
    public class VFXPoolItem : MonoBehaviour

    {
        [SerializeField] private ParticleSystem _particleSystem;
        public ParticleSystem ParticleSystem => _particleSystem;

        public VFXPool Pool { get; set; }

        private void OnParticleSystemStopped()
        {
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            Pool.ReturnToPool(this);
            gameObject.SetActive(false);
        }
        public void OnGetFromPool()
        {
            gameObject.SetActive(true);
        }
    }
}
