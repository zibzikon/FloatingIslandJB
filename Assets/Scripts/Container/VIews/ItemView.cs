using UnityEngine;
using UnityEngine.UI;

namespace Container.VIews
{
    [CreateAssetMenu(fileName = "ItemView")]
    public class ItemView : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite =>_sprite;
    }
}