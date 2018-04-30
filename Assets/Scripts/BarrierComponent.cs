using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierComponent : MonoBehaviour
{
    const float HorizontalMovement = 2880f + 704f;

    public float MoveSpeed;

    GameObject _fireRingObject;
    GameObject _firePanObject;
    GameObject[] _groupObjects;
    GameObject _coinObject;
    Canvas _ringCanvas;
    RectTransform _panel;
    Vector2 _position;
    float _speedLevel;

    void Awake()
    {
        _fireRingObject = transform.Find("FireRing").gameObject;
        _firePanObject = transform.Find("FirePan").gameObject;
        var coins = transform.Find("Coins");
        _groupObjects = new GameObject[coins.childCount];
        for (int i = 0; i < _groupObjects.Length; i++)
        {
            _groupObjects[i] = coins.GetChild(i).gameObject;
        }
        _coinObject = transform.Find("CoinCollider").gameObject;
        _ringCanvas = transform.Find("FireRing/RightImage").GetComponent<Canvas>();
        _panel = GetComponent<RectTransform>();
        _position = _panel.anchoredPosition;
        SetBarrier();
    }

    void OnEnable()
    {
        _ringCanvas.overrideSorting = true;
    }

    void OnDisable()
    {
        _ringCanvas.overrideSorting = false;
    }

    void Update()
    {
        _position.x -= MoveSpeed + _speedLevel;
        if (_position.x + HorizontalMovement < 0)
        {
            _position.x += HorizontalMovement;
            SetBarrier();
        }
        _panel.anchoredPosition = _position;
    }

    void SetBarrier()
    {
        var x = Random.Range(0, 4);
        _fireRingObject.SetActive(0 == x || 1 == x);
        _firePanObject.SetActive(2 == x || 3 == x);
        for (int i = 0; i < _groupObjects.Length; i++)
        {
            _groupObjects[i].SetActive(0 == x || 2 == x);
        }
        _coinObject.SetActive(true);
    }

    public void ResetPosition()
    {
        if (!_panel)
        {
            return;
        }
        _speedLevel = 0;
        _position.x = 0;
        _panel.anchoredPosition = _position;
        SetBarrier();
    }

    public void AddSpeed()
    {
        _speedLevel++;
    }
}
