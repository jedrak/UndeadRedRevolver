using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        /* itemName = "Revolver";
        Sprite sprite = Resources.Load("Weapons/revolver") as Sprite; */
        itemName = "Obrzyn";

        /* byte[] bytes = UnityEngine.Windows.File.ReadAllBytes("Assets/Resources/Weapons/obrzyn.png");
        Texture2D imgTexture = new Texture2D(256, 164);
        imgTexture.filterMode = FilterMode.Point;
        imgTexture.LoadImage(bytes);
        Sprite sprite = Sprite.Create(imgTexture, new Rect(0, 0, 256, 164), new Vector2(0f, 0f), 1.0f);
        Debug.Log(sprite); */

        // spriteRenderer.sprite = sprite;
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
            //spriteRenderer.enabled = false;
            // użytkownik musi go dostać w ekwipunku czy coś
            if (other.gameObject.GetComponent<PlayerInventory>().addItem(this))
            {
                
                other.gameObject.GetComponent<Shooting>().weapon = itemName;
                Destroy(gameObject);
            }
        }
    }
}