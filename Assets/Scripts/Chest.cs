using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isOpen;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openSprite, closeSprite;
    [SerializeField]
    private Item itemPrefab;
    private GameObject itemGO;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        spriteRenderer.sprite = closeSprite;
        //Instantiate(itemPrefab, transform.position, transform.rotation, transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isOpen && other.gameObject.tag == "Player")
        {
            // play animation / change sprite
            spriteRenderer.sprite = openSprite;
            // show item
            //itemGO.GetComponent<Item>().Show();
            Instantiate(itemPrefab, transform.position, transform.rotation, transform);
            // set state
            isOpen = true;
        }
    }
}
