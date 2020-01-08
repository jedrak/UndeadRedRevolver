using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isOpen;
    public Map map;
    public uint roomIndexX;
    public uint roomIndexY;
    [SerializeField]
    private AmmoObject ammoPrefab;
    [SerializeField]
    private ItemObject itemPrefab;
    [SerializeField]
    private WeaponObject weaponPrefab;
    private Animator anim;
    public Transform itemPlace;

    void Start()
    {
        map = GetComponentInParent<Map>();
        anim = GetComponent<Animator>();
        anim.SetBool("open", false);
        isOpen = false;
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = map._playerX == roomIndexX && map._playerY == roomIndexY;
        GetComponent<BoxCollider2D>().enabled = map._playerX == roomIndexX && map._playerY == roomIndexY;
        foreach (SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>())
        {
            sp.enabled = map._playerX == roomIndexX && map._playerY == roomIndexY;
        }
        foreach (BoxCollider2D col in this.GetComponentsInChildren<BoxCollider2D>())
        {
            col.enabled = map._playerX == roomIndexX && map._playerY == roomIndexY;
        }
        foreach (ParticleSystem pc in this.GetComponentsInChildren<ParticleSystem>())
        {
            pc.gameObject.SetActive(map._playerX == roomIndexX && map._playerY == roomIndexY);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isOpen && other.gameObject.tag == "Player")
        {
            int rand = UnityEngine.Random.Range(1, 100);
            if (rand < 40)
            {
                ItemObject io = Instantiate(itemPrefab, itemPlace.position, itemPlace.rotation, transform);
                io.item = RandItem(other.gameObject);
            }
            else if (rand < 81)
            {
                AmmoObject io = Instantiate(ammoPrefab, itemPlace.position, itemPlace.rotation, transform);
                if (rand < 70) io.ammoType = AmmoType.BOUNCY;
                else io.ammoType = AmmoType.PENETRATING;
                io.bulletCount = rand;
            }
            else
            {
                WeaponObject io = Instantiate(weaponPrefab, itemPlace.position, itemPlace.rotation, transform);
                io.weapon = RandWeapon();
            }

            //anim.SetBool("open", true);
            // set state
            isOpen = true;
        }
    }

    private Item RandItem(GameObject player)
    {
        Item item;

        int rand = UnityEngine.Random.Range(1, 50);

        if (rand < 10) item = new ItemShield(player);
        else if (rand < 20) item = new ItemTime(player);
        // TODO more items
        else item = new ItemShield(player);
        return item;

        /*return new ItemTime(player.GetComponentInParent<TimerManager>().timer);*/
    }

    private Weapon RandWeapon()
    {
        Weapon weapon;

        int rand = UnityEngine.Random.Range(1, 40);

        if (rand < 10) weapon = new Revolver();
        else if (rand < 20) weapon = new Shotgun();
        else if (rand < 30) weapon = new Riffle();
        else weapon = new Revolver();

        return weapon;
    }
}
