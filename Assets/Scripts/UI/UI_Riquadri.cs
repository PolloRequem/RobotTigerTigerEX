using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Riquadri : MonoBehaviour
{
   
    [SerializeField] private Transform frameTemplate;
    public static string robotSelected;


    //private IEnumerator Start()
    //{
    //    yield return new  WaitForEndOfFrame();
    //    UpdateVisual();
    //}

    private void Awake()
    {
        frameTemplate.gameObject.SetActive(false);
    }
    public void UpdateVisual(Robot[] robotsData)
    {
      foreach(Transform child in transform)
        {
            if (child == frameTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (Robot robot in robotsData)
        {
           Transform frameTranform =  Instantiate(frameTemplate, transform);
            frameTranform.gameObject.SetActive(true);
          frameTranform.GetComponent<Riquadri_Body>().SetRiquadro(robot);

        }

    }



}
