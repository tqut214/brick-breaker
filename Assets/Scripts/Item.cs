using UnityEngine;

namespace DefaultNamespace
{
    //[CreateAssetMenu(fileName = "Prefabs", menuName = "PickableITem", order = 0)]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite itemSprite;
    }
}