using System.Collections.Generic;
using UnityEngine;

namespace BeatSort
{
    [CreateAssetMenu(fileName = "VFXClick", menuName = "Game / VFXClkick", order = 1)]

    public class VFXClickPool : ScriptableObject
    {
        [SerializeField] private int _size = 5;
        [SerializeField] private GameObject _vfxPrefab;

        private List<VFXClickItem> _items;

        private Queue<VFXClickItem> _queue;

        private bool _poolIsInitialized = false;

        public void InitializePool()
        {
            if (_poolIsInitialized)
            { return; }

            _items?.Clear();
            _queue?.Clear();

            _items = new List<VFXClickItem>(_size);
            _queue = new Queue<VFXClickItem>();

            for (int i = 0; i < _size; i++)
            {
                CreateItem();
            }
            _poolIsInitialized = true;
        }

        public void ResetPool()
        {
            _items.ForEach(item =>
            {
                if (item != null && item.gameObject != null)
                {
                    Destroy(item);
                }
            });

            _items?.Clear();
            _queue?.Clear();

            _poolIsInitialized = false;
        }

        public VFXClickItem GetFromPool()
        {
            if (_queue.Count == 0)
            {
                ExpandPool();
            }
            VFXClickItem vfxPoolItem = _queue.Dequeue();
            vfxPoolItem.OnGetFromClickPool();
            return vfxPoolItem;
        }
        public void Return2ClickPool(VFXClickItem item)
        {
            _queue.Enqueue(item);
        }

        protected void ExpandPool()
        {
            for (int i = 0; i < _size; i++)
            {
                CreateItem();
            }
        }
        protected VFXClickItem CreateItem()
        {
            GameObject itemInstance = Instantiate(_vfxPrefab);
            itemInstance.SetActive(false);

            VFXClickItem vfxPoolItem = itemInstance.GetComponent<VFXClickItem>();
            vfxPoolItem.Pool = this;

            _items.Add(vfxPoolItem);
            _queue.Enqueue(vfxPoolItem);
            return vfxPoolItem;
        }

    }
}