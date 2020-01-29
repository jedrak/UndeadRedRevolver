using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TimerManager manager;
    public float timeToEnd;
    public GameObject bulletPrefab;
    private List<GameObject> _listOfBullets;

    void Start()
    {
        _listOfBullets = new List<GameObject>();
        for (int i = 0; i < timeToEnd / 60.0f + 1; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + i * .9f, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            bullet.transform.parent = transform;
            _listOfBullets.Add(bullet);
        }
    }

    void FixedUpdate()
    {
        if (!manager._playerIsDead) timeToEnd -= Time.fixedDeltaTime;

        float heartsCount = (timeToEnd) / 60.0f;

        if ((heartsCount + 1) > _listOfBullets.Count)
        {
            while ((heartsCount + 1) > _listOfBullets.Count)
            {
                GameObject prev = _listOfBullets[_listOfBullets.Count - 1];
                Vector3 v = prev.transform.position;
                prev.GetComponent<Image>().fillAmount = 1.0f;

                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.parent = transform;
                bullet.transform.SetPositionAndRotation(new Vector3(v.x + prev.GetComponent<RectTransform>().rect.width, v.y, v.z), Quaternion.Euler(0, 0, 0));
                _listOfBullets.Add(bullet);
            }
        }

        if (heartsCount < _listOfBullets.Count)
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
