using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tartaruga_Enemy : Hittable
{
    protected override void GetHit()
    {
        Die();
    }
}
