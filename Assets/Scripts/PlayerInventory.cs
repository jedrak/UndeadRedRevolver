using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private const int ITEM_SLOTS = 6;

    public bool[] isItem;
    public GameObject[] itemSlots;

    private GameObject shield;
    private float shieldLifeTime = 5.0f;

    private void Start()
    {
        shield = GameObject.FindGameObjectWithTag("Shield");
        shield.SetActive(false);
        // DEBUG
        // shield.SetActive(true);
        for (int i = 2; i < ITEM_SLOTS; i++)
        {
            itemSlots[i].SetActive(false);
        }
    }

    public bool activateShield()
    {
        shield.SetActive(true);
        StartCoroutine(ShieldTime());
        return true;
    }
    IEnumerator ShieldTime()
    {
        yield return new WaitForSeconds(shieldLifeTime);
        shield.SetActive(false);
    }

    public void activeNewItemSlot()
    {
        for (int i = 0; i < ITEM_SLOTS; i++)
        {
            if (itemSlots[i].activeSelf == false)
            {
                isItem[i] = false;
                itemSlots[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    public bool UseSlot(int slotIndex)
    {
        if (isItem[slotIndex]) return itemSlots[slotIndex].GetComponentInChildren<ItemButton>().item.use();
        else return false;
    }

}
