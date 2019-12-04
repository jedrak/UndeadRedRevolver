using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToEnd;
    public GameObject bulletPrefab;
    public List<Sprite> sprites;
    
    private List<GameObject> _listOfBullets;

    /*public float _currentTime{
        get;
        private set;
    }*/
    

    void Start()
    {
        float trans = 0;
        _listOfBullets = new List<GameObject>();
        for(int i = 0; i < timeToEnd/60.0f; i++)
        {

            trans += .8f; 

            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + trans, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            bullet.transform.parent = transform;
            _listOfBullets.Add(bullet);
        }
    }


    void FixedUpdate()
    {
        timeToEnd -= Time.fixedDeltaTime;
        if(((timeToEnd) / 60.0f)+1 > _listOfBullets.Count){
            float trans = 0;
            while(((timeToEnd) / 60.0f)+1 > _listOfBullets.Count){
                if(_listOfBullets.Count % 6 != 0)
                {
                    trans = .3f;
                }
                else
                {
                    trans = .6f;
                }
                GameObject bullet = Instantiate(bulletPrefab,
                new Vector3(_listOfBullets[_listOfBullets.Count-1].transform.position.x + trans,
                    _listOfBullets[_listOfBullets.Count-1].transform.position.y,
                    _listOfBullets[_listOfBullets.Count-1].transform.position.z),
                    Quaternion.Euler(0, 0, 0));
                bullet.transform.parent = transform;
                _listOfBullets.Add(bullet);
            }
                
        }
        if(((timeToEnd) / 60.0f) + 1.0 < _listOfBullets.Count)
        {
            //Debug.Log(((timeToEnd - _currentTime) / 10.0f), this);
            if(_listOfBullets.Count - 1 > 0){
                Destroy(_listOfBullets[_listOfBullets.Count - 1]);
                _listOfBullets.Remove(_listOfBullets[_listOfBullets.Count - 1]);
            }
        }

         _listOfBullets[_listOfBullets.Count - 1].GetComponent<SpriteRenderer>().sprite = sprites[(int)(timeToEnd - ((_listOfBullets.Count - 1) * 60))/10];

    }
}
