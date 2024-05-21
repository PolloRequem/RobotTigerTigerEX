using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCollector : MonoBehaviour
{
    

    
    [SerializeField]private GameObject[] materiali;
    [SerializeField]private GameObject bigMaterialImage;
    private bool[] isTaken;

    [field: SerializeField] public Transform targetMaterialTransfoorm;

    

    
    private void Start()
    {
        isTaken = new bool[6];
        GameEventManager.instance.smallMtaken.onSmallMtaken += SmallMtaken_onSmallMtaken;
        GameEventManager.instance.bigMtaken.onBigMtaken += BigMtaken_onBigMtaken;
        for (int i = 0; i < isTaken.Length; i++)
        {
            isTaken[i] = false;
            
        }
        
    }

    private void BigMtaken_onBigMtaken()
    {
        bigMaterialImage.SetActive(true);
    }

    private void SmallMtaken_onSmallMtaken()
    {
       // Instantiate(materialPrefab, playerTransform.position, Quaternion.identity);
     
        for (int i = 0; i< materiali.Length; i++)
        {
          
            if (isTaken[i]==false)
            {
                
                materiali[i].SetActive(true);
                isTaken[i] = true;
                return;
            }
        }
    }

    
    private void Update()
    {

           /// materialPrefab.transform.position = Vector2.MoveTowards(materialPrefab.transform.position, taget.position, 3f * Time.deltaTime);
        
        
    }


 
}