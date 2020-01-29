using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TimerManager manager;
    public float timeToEnd;
    public GameObject bulletPrefab;
    // public List<Sprite> sprites;

    private RectTransform rectTransform;
    private List<GameObject> _listOfBullets;
    /*public float _currentTime{
        get;
        private set;
    }*/


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // float trans = 0;
        _listOfBullets = new List<GameObject>();
        for (int i = 0; i < timeToEnd / 60.0f + 1; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(rectTransform.position.x + i * .9f, rectTransform.position.y, rectTransform.position.z), Quaternion.Euler(0, 0, 0));
            bullet.transform.parent = transform;
            _listOfBullets.Add(bullet);
        }
    }


    void FixedUpdate()
    {
        // DEBUG dodaj serduszko
        if (Input.GetKeyDown(KeyCode.T))
        {
            timeToEnd += 60;
        }

        if (!manager._playerIsDead) timeToEnd -= Time.fixedDeltaTime;
        if (((timeToEnd) / 60.0f + 1) > _listOfBullets.Count)
        {
            int i = 0;
            while (((timeToEnd) / 60.0f + 1) > _listOfBullets.Count)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                RectTransform rt = bullet.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, i * rt.rect.width, rt.rect.width);
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, i * rt.rect.height, rt.rect.height);
                Debug.Log(bullet.GetComponent<RectTransform>().transform.localPosition);

                // GameObject bullet = Instantiate(bulletPrefab, new Vector3(rectTransform.position.x + i * 1.0f, rectTransform.position.y, rectTransform.position.z), Quaternion.Euler(0, 0, 0));
                _listOfBullets.Add(bullet);
                i++;
            }

        }
        if (((timeToEnd) / 60.0f) < _listOfBullets.Count)
        {

            if (_listOfBullets.Count - 1 > 0)
            {
                Destroy(_listOfBullets[_listOfBullets.Count - 1]);
                _listOfBullets.Remove(_listOfBullets[_listOfBullets.Count - 1]);
            }
        }

        _listOfBullets[_listOfBullets.Count - 1].GetComponent<Image>().fillAmount = (timeToEnd - ((_listOfBullets.Count - 1) * 60)) / 60;
    }
}
