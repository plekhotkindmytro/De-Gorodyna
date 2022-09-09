using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, IFood
{
    public FoodType Type { get => FoodType.Banana; }

}
