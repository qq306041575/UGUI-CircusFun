using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    const int BarrierCount = 3;
    const float BarrierInterval = 1195f;

    List<BarrierComponent> _barriers;

    void Awake()
    {
        var go = Resources.Load<GameObject>("Barrier");
        _barriers = new List<BarrierComponent>();
        for (int i = 0; i < BarrierCount; i++)
        {
            var barrier = Instantiate(go);
            barrier.transform.SetParent(transform, false);
            _barriers.Add(barrier.GetComponent<BarrierComponent>());
        }
        enabled = false;
    }

    void OnEnable()
    {
        for (int i = 0; i < _barriers.Count; i++)
        {
            _barriers[i].ResetPosition();
        }
        StartCoroutine(MoveBarrier());
    }

    void OnDisable()
    {
        for (int i = 0; i < _barriers.Count; i++)
        {
            _barriers[i].enabled = false;
        }
    }

    IEnumerator MoveBarrier()
    {
        for (int i = 0; i < _barriers.Count; i++)
        {
            _barriers[i].enabled = true;
            if (i + 1 == _barriers.Count)
            {
                break;
            }
            var panel = _barriers[i].GetComponent<RectTransform>();
            while (panel.anchoredPosition.x + BarrierInterval > 0)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void AddSpeed()
    {
        for (int i = 0; i < _barriers.Count; i++)
        {
            _barriers[i].AddSpeed();
        }
    }
}
