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

        }
        else
        {
            mat.SetInt("playerIsDead", 0);
        }
       
    }
}
