using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Main_Profile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI profile_Nome;
    [SerializeField] private TextMeshProUGUI profile_Role;


    private void Start()
    {
        profile_Nome.text = PlayerPrefsManger.PP_LoginUsername();
        profile_Role.text = PlayerPrefsManger.PP_LoginRole();
    }
}
