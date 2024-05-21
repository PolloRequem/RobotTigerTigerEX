using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UI_DispalyFindings : MonoBehaviour
{
    [SerializeField] private Transform frameTemplate;

    private void Awake()
    {
        frameTemplate.gameObject.SetActive(false);
    }
    public void UpdateVisual(List<Ritrovamenti> ritrovamentis)
    {
        foreach (Transform child in transform)
        {
            if (child == frameTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (Ritrovamenti r in ritrovamentis)
        {
            Transform frameTranform = Instantiate(frameTemplate, transform);
            frameTranform.gameObject.SetActive(true);
            frameTranform.GetComponent<Records_Ritrovamenti>().SetUPRecords(r.missione, r.materiale, System.DateTime.Today.ToShortDateString(), r.parziali);

        }

    }
}
