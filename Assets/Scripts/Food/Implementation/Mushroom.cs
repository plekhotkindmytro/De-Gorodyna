using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, IFood
{
    public FoodType Type { get => FoodType.Mushroom; }

}
