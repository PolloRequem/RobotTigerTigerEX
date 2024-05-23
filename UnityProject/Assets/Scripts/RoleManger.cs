using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static  class RoleManger 
{
   
    public static bool isPlayerAdmin()
    {
        if (PlayerPrefs.GetString("Login_Role") == "admin")
        {
            return true;
        }
        return false;
        
    }

}
