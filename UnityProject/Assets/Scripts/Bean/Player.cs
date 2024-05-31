using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBean 
{
    public int id {  get;  set; }
    public string username { get;set; }
    public string role  { get;  set; }
    public string email { get;  set; }
     
    public int totalPoints { get; set; }

    public int missionsCompleted { get; set; }

    public string toString()
    {
        return "Player{" + "id=" + id + ", username=" + username + ", role=" + role + ", email=" + email + ", ToTpoints=" + totalPoints + ", missionsCompleted=" + missionsCompleted + '}';

    }

}
