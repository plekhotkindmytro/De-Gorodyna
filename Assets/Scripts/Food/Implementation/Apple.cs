using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IFood
{
    public FoodType Type { get => FoodType.Apple; }

}
