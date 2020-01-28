using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcess : MonoBehaviour
{
    public Material mat;
    public TimerManager tm;
   
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }

    private void Update() {
        if(tm._playerIsDead){
            mat.SetInt("playerIsDead", 1);
            mat.SetFloat("startTime", Time.time);
        }
        else
        {
            mat.SetInt("playerIsDead", 0);
        }
        Debug.Log(mat.GetFloat("startTime") + " " + Time.time);
       
    }
}
