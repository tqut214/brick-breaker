using System.Collections.Generic;
using UnityEngine;
public class DropItem : MonoBehaviour
{
  // List <GameObject> listOfItem;
  [SerializeField] private float randomRate;
  public List <GameObject> Items;
  public void RandomWithDropRate(Transform place)
    {
        Debug.Log("This block be destroy");
        float random = Random.Range(1f, 100f);
        if (random < randomRate)
        {
            randomItem(place);
        }
    }

    private void randomItem(Transform dropPlace)
    {
        int randomItem = Random.Range(0, Items.Count);
        Debug.Log("Drop");
        var newItem = Instantiate(Items[randomItem],dropPlace.position,Quaternion.identity);
        newItem.GetComponent<Rigidbody2D>().AddForce(Vector2.down,ForceMode2D.Impulse);
    }
}
