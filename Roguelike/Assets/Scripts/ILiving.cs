using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiving
{
    void takeDamage(int value);

    void die();
}
