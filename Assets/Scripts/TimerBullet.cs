using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBullet : MonoBehaviour
{
    private void Start() {
       
    }
    private void OnEnable() {
        Debug.Log("Stworzono kule", this);
    }
    private void OnDestroy() {
        Debug.Log("Zniszcono kule", this);
    }
}
