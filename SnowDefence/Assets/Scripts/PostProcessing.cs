using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessing : MonoBehaviour
{
    public Volume volume;
    Vignette vignette;

    private void Start()
    {
        volume.profile.TryGet<Vignette>(out vignette);
    }
    
    public void vignetteDamage()
    {
        vignette.intensity.value = Mathf.Lerp(0f, 0.45f, 0.05f * Time.deltaTime);
    }
}
