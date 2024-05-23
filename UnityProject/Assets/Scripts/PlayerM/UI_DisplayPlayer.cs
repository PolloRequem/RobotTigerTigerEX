using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DisplayPlayer : MonoBehaviour
{
    [SerializeField] private Transform frameTemplate;

    private void Awake()
    {
        frameTemplate.gameObject.SetActive(false);
    }
    public void UpdateVisual(List<PlayerBean> players)
    {
        foreach (Transform child in transform)
        {
            if (child == frameTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (PlayerBean p in players)
        {
            Transform frameTranform = Instantiate(frameTemplate, transform);
            frameTranform.gameObject.SetActive(true);
            frameTranform.GetComponent<Record_Player>().SetUPRecords(p.id, p.username, p.role, p.email);

        }

    }
}