﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionFish : MonoBehaviour {
    Material mat;
    public Texture emissive;
    private GameObject mainCharacter;
    public float leftLimit;
    public float rightLimit;
    private string name;
    public float timeDestroy;
    // Use this for initialization
    void Start()
    {
        name = gameObject.transform.parent.gameObject.name.Replace("(Clone)", "");
        
        emissive = Resources.Load<Texture>(name);
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        mat.SetTexture("_EmissionMap", emissive);
        mat.SetColor("_EmissionColor", Color.white);
        mainCharacter = GameObject.Find("spot_light");

        timeDestroy = 5;
        StartCoroutine(DestroyGamObject());

        
    }

    // Update is called once per frame
    void Update () {
		
	}
    IEnumerator DestroyGamObject()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
