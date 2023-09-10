using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Elements
{
    [Serializable]
    public class ItemsCreator<TItem> where TItem : MonoBehaviour 
    {
        [SerializeField] private Transform _parent;

        [SerializeField] private TItem _prefab;

        private List<TItem> _created = new List<TItem>();

        public TItem Create()
        {
            TItem item = Object.Instantiate(_prefab, _parent);

            _created.Add(item);
            
            return item;
        }

        public void DestroyAll()
        {
            foreach (TItem createdItem in _created)
            {
                Object.Destroy(createdItem.gameObject);
            }
            
            _created.Clear();
        }
    }
}