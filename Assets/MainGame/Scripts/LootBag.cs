using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            // Get the item with the lowest drop chance
            Loot lowestDropChanceItem = possibleItems[0];
            foreach (Loot item in possibleItems)
            {
                if (item.dropChance < lowestDropChanceItem.dropChance)
                {
                    lowestDropChanceItem = item;
                }
            }
            return lowestDropChanceItem;
        }
        Debug.Log("No item dropped");
        return null;
    }


    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootGameObject.name = droppedItem.codeName;


            float dropForce = 25f;
            float dropTorque = 1f;
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * dropForce, ForceMode2D.Impulse);
            lootGameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1f, 1f) * dropTorque, ForceMode2D.Impulse);
        }
    }


}
