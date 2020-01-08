using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image image;
    public Item item;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(item.name);
    }
    void Update()
    {
        
    }

    public void Use()
    {
        if (item.use())
        {
            //Debug.Log("Item \"" + item.name + "\" used.");
            Destroy(gameObject);
        }
    }
}
