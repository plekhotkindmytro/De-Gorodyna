using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IFood
{
    public FoodType Type { get => FoodType.Fish; }

}
