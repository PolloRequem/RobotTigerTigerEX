using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Script : MonoBehaviour
{
    public GameObject targetPosition;

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.transform.position, 3f * Time.deltaTime);
    }

    

}
