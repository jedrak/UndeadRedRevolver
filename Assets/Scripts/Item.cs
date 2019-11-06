using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }
    void Update()
    {
        //Debug.Log(spriteRenderer.enabled);
    }
    public void Show()
    {
        //spriteRenderer.enabled = true;
        //spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);    
            //spriteRenderer.enabled = false;
            // użytkownik musi go dostać w ekwipunku czy coś
            other.gameObject.GetComponent<PlayerInventory>().addItem(this);
            // ..
        }
    }
}