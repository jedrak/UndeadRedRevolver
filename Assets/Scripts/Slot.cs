using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private PlayerInventory inv;
    public int slotIndex;
    [SerializeField]
    private ItemObject itemPrefab;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (transform.childCount < 2)      // 1 = cross, 2 = cross + item
        {
            inv.isItem[slotIndex] = false;
        }
    }

    public void DropItem()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().setUiClicked(true);
        // spawn on map
        if (inv.isItem[slotIndex])
        {
            Vector2 itemPos = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - 2, GameObject.FindGameObjectWithTag("Player").transform.position.y);
            ItemObject io = Instantiate(itemPrefab, itemPos, Quaternion.identity);
            io.item = GetComponentInChildren<ItemButton>().item;
            GameObject.Destroy(GetComponentInChildren<ItemButton>().gameObject);
        }
    }
}
