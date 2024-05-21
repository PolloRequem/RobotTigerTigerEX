using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DiplayMIsisons : MonoBehaviour
{
    [SerializeField] private Transform frameTemplate;

    private void Awake()
    {
        frameTemplate.gameObject.SetActive(false);
    }
    public void UpdateVisual(List<Mission> missions)
    {
        foreach (Transform child in transform)
        {
            if (child == frameTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (Mission m in missions)
        {
            Transform frameTranform = Instantiate(frameTemplate, transform);
            frameTranform.gameObject.SetActive(true);
            frameTranform.GetComponent<Records_Mission>().SetUPRecords(m.id, m.nome, m.robot, m.player, m.id);

        }

    }
}
