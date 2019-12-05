using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private int magazinesize;
    private float lastFire;
    public float FireDelay;
    public string weapon ;
    public float ReloadDelay;
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    public int Magazinesize { get => magazinesize; set => magazinesize = value; }
    public abstract void Shoot(CameraShake camShake, Transform firePoint);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
