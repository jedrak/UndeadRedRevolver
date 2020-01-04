using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Item item;
    public GameObject itemButton;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(item.name);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.gameObject.GetComponent<PlayerInventory>();
            for (int i = 0; i < inv.itemSlots.Length; i++)
            {
                if (inv.isItem[i] == false)
                {
                    inv.isItem[i] = true;
                    GameObject go = Instantiate(itemButton, inv.itemSlots[i].transform, false);
                    go.GetComponent<ItemButton>().item = item;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
