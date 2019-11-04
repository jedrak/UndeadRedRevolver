using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.enabled = false;
    }
    void Update()
    {

    }
    public void Show()
    {
        spriteRenderer.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            // użytkownik musi go dostać w ekwipunku czy coś
            // other.gameObject.GetComponent("Player").addItem(itemName);
            // ..
        }
    }
}