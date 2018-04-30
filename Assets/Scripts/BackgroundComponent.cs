using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundComponent : MonoBehaviour
{
    public float MoveSpeed;

    Material _backgroundMaterial;
    float _time;

    void Awake()
    {
        _backgroundMaterial = GetComponent<Image>().material;
    }

    void Update()
    {
        _time += Time.deltaTime;
        var move = Vector2.right * Mathf.Repeat(_time * MoveSpeed, 1);
        _backgroundMaterial.SetTextureOffset("_MainTex", move);
    }
}
