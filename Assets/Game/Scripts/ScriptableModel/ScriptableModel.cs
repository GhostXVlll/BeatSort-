using UnityEngine;
using System.Collections.Generic;

namespace BeatSort
{
    public class ScriptableModel<TModel> : ScriptableObject where TModel : Model, new()
    {
        [SerializeField] protected TModel _model;

        public TModel Model
        {
            get => _model;
            set
            {
                _model = value;
            }
        }
    }
}
