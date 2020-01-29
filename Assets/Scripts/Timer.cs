using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TimerManager manager;
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
        for(int i = 0; i < timeToEnd/60.0f+1; i++)
        {
           
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + i*.9f, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            bullet.transform.parent = transform;
            _listOfBullets.Add(bullet);
        }
    }


    void FixedUpdate()
    {
        if(!manager._playerIsDead) timeToEnd -= Time.fixedDeltaTime;
        if(((timeToEnd) / 60.0f+1) > _listOfBullets.Count){
            while(((timeToEnd) / 60.0f+1) > _listOfBullets.Count){

                //_listOfBullets[_listOfBullets.Count-1].GetComponent<SpriteRenderer>().sprite = sprites[sprites.Count-1];
               
                GameObject bullet = Instantiate(bulletPrefab);
                
                //bullet.transform.parent = transform;
                RectTransform rt = bullet.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, rt.rect.width);
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                Debug.Log(bullet.GetComponent<RectTransform>().transform.localPosition);
                _listOfBullets.Add(bullet);
            }
                
        }
        if(((timeToEnd) / 60.0f) < _listOfBullets.Count)
        {

            if(_listOfBullets.Count - 1 > 0){
                Destroy(_listOfBullets[_listOfBullets.Count - 1]);
                _listOfBullets.Remove(_listOfBullets[_listOfBullets.Count - 1]);
            }
        }
        //int nr_of_sp = ((int)timeToEnd - ((_listOfBullets.Count - 1) * 60)) / 10;
        //if (nr_of_sp < 0) nr_of_sp = 0;
        //Debug.Log(nr_of_sp);
        _listOfBullets[_listOfBullets.Count - 1].GetComponent<Image>().fillAmount = (timeToEnd - ((_listOfBullets.Count - 1) * 60)) / 60 ;



    }
}
