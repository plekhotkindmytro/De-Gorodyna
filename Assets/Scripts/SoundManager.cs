using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{

    public GameState gameState;
    public AudioSource findOrange;
    public AudioSource findEggplant;
    public AudioSource findBanana;
    public AudioSource findBroccoli;
    public AudioSource findRoll;
    public AudioSource findPumpkin;
    public AudioSource findGrapefruit;
    public AudioSource findAvocado;
    public AudioSource findMushroom;
    public AudioSource findPear;
    public AudioSource findWatermelon;
    public AudioSource findCabbage;
    public AudioSource findCoconut;
    public AudioSource findCorn;
    public AudioSource findCucumber;
    public AudioSource findPepper;
    public AudioSource findTomato;
    public AudioSource findFish;
    public AudioSource findOnion;
    public AudioSource findApple;
    public AudioSource findCroissant;

    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public AudioSource noThinkMoreSound;

    public AudioSource more1;
    public AudioSource more2;
    public AudioSource more3;
    public AudioSource more4;
    public AudioSource more5;
    public AudioSource more6;

    public AudioSource yes1;
    public AudioSource yes2;
    public AudioSource yes3;
    public AudioSource yes4;
    public AudioSource yes5;
    public AudioSource yes6;
    public AudioSource yes7;
    public AudioSource yes8;
    public AudioSource yes9;
    public AudioSource yes10;

    private AudioSource[] yesArray;
    private AudioSource[] moreArray;
    private int incorrectCounter = 0;
    private AudioSource currentYesSound = null;
    private AudioSource currentMoreSound = null;
    private AudioSource currentQuestionSound = null;


    /* private AudioSource[] soundObjects;
     // TODO make Class field
     private Dictionary<string, AudioSource> objectTagToAudioSourceMap;*/
    void Start()
    {

        yesArray = new AudioSource[] { yes1, yes2, yes3, yes4, yes5, yes6, yes7, yes8, yes9, yes10};

        moreArray = new AudioSource[] { more1, more2, more3, more4, more5, more6 };

        /* soundObjects = transform.GetComponentsInChildren<AudioSource>();
         objectNameToAudioSourceMap = new Dictionary<string, AudioSource>();

         string allTileNames = "";
         Debug.Log("cHILD COUNT: " + tileMasterPrefab.transform.childCount);
         for (int i = 0; i < tileMasterPrefab.transform.childCount; i++)
         {
             allTileNames += tileMasterPrefab.transform.GetChild(i).name + " ";
             //  Debug.Log("Tile: " + allTileNames);
         }

         Debug.Log("All: " + allTileNames);

         */


        //   FoodFreeBread02 FoodFreeBread05 FoodFreeFish01 FoodFreeFish014 FoodFreeFish016 FoodFreeFish018 FoodFreeFruit01 FoodFreeFruit02 FoodFreeFruit03 FoodFreeFruit09 FoodFreeFruit013 FoodFreeFruit014 FoodFreeFruit015 FoodFreeFruit22 FoodFreeFruit23 FoodFreeFruit26 FoodFreeFruit27 FoodFreeFruit48 FoodFreeFruit49 FoodFreeMushroom04 FoodFreeMushroom06 FoodFreeMushroom011 FoodFreeVeg02 FoodFreeVeg03 FoodFreeVeg013 FoodFreeVeg019 FoodFreeVeg023 FoodFreeVeg24 FoodFreeVeg25 FoodFreeVeg27 FoodFreeVeg31 FoodFreeVeg34
    }

    internal void PlayMoreSound()
    {
        float delaySeconds = 1f;
        if (currentMoreSound != null)
        {
            currentMoreSound.Stop();
            currentMoreSound = null;
        }

        currentMoreSound = moreArray[UnityEngine.Random.Range(0, moreArray.Length)];
        currentMoreSound.PlayDelayed(delaySeconds);
    }

    internal void PlayIncorrectSound()
    {
        incorrectSound.Stop();
        incorrectSound.Play();
        PlayNoThinkMoreSound();
    }

    internal void PlayCorrectSound()
    {
        correctSound.Play();


        float delaySeconds = 0.5f;
        if (currentYesSound != null)
        {
            currentYesSound.Stop();
            currentYesSound = null;
        }

        noThinkMoreSound.Stop();
        if (currentMoreSound != null)
        {

            currentMoreSound.Stop();
            currentMoreSound = null;
        }

        if (currentQuestionSound != null)
        {
            currentQuestionSound.Stop();
            //currentQuestionSound = null;
        }

        currentYesSound = yesArray[UnityEngine.Random.Range(0, yesArray.Length)];
        currentYesSound.PlayDelayed(delaySeconds);

    }

    private void PlayNoThinkMoreSound()
    {
        
        float delaySeconds = 0.5f;
        if (incorrectCounter == 0 || incorrectCounter == 2)
        {
            noThinkMoreSound.Stop();
            noThinkMoreSound.PlayDelayed(delaySeconds);
        }
        else if (incorrectCounter % 2 != 0)
        {
            // Play nothing for odd counter
        }
        else if (incorrectCounter == 4)
        {
            PlayQuestionSound();
        }

        incorrectCounter = incorrectCounter > 4? 0: incorrectCounter + 1;
    }


    internal IFood PlayQuestionSound()
    {
        IFood currentFood = gameState.TargetFoodList[0];

        if (currentQuestionSound != null)
        {
            currentQuestionSound.Stop();
            currentQuestionSound = null;
        }

        if (currentFood.Type.Equals(FoodType.Roll))
        {
            currentQuestionSound = findRoll;
        }
        else if (currentFood.Type.Equals(FoodType.Croissant))
        {
            currentQuestionSound = findCroissant;
        }
        else if (currentFood.Type.Equals(FoodType.Pear))
        {
            currentQuestionSound = findPear;
        }
        else if (currentFood.Type.Equals(FoodType.Watermelon))
        {
            currentQuestionSound = findWatermelon;
        }
        else if (currentFood.Type.Equals(FoodType.Apple))
        {
            currentQuestionSound = findApple;
        }
        else if (currentFood.Type.Equals(FoodType.Orange))
        {
            currentQuestionSound = findOrange;
        }
        else if (currentFood.Type.Equals(FoodType.Grapefruit))
        {
            currentQuestionSound = findGrapefruit;
        }
        else if (currentFood.Type.Equals(FoodType.Banana))
        {
            currentQuestionSound = findBanana;
        }
        else if (currentFood.Type.Equals(FoodType.Coconut))
        {
            currentQuestionSound = findCoconut;
        }
        else if (currentFood.Type.Equals(FoodType.Avocado))
        {
            currentQuestionSound = findAvocado;
        }
        else if (currentFood.Type.Equals(FoodType.Mushroom))
        {
            currentQuestionSound = findMushroom;
        }
        else if (currentFood.Type.Equals(FoodType.Onion))
        {
            currentQuestionSound = findOnion;
        }
        else if (currentFood.Type.Equals(FoodType.Cabbage))
        {
            currentQuestionSound = findCabbage;
        }
        else if (currentFood.Type.Equals(FoodType.Broccoli))
        {
            currentQuestionSound = findBroccoli;
        }
        else if (currentFood.Type.Equals(FoodType.Tomato))
        {
            currentQuestionSound = findTomato;
        }
        else if (currentFood.Type.Equals(FoodType.Pepper))
        {
            currentQuestionSound = findPepper;
        }
        else if (currentFood.Type.Equals(FoodType.Eggplant))
        {
            currentQuestionSound = findEggplant;
        }
        else if (currentFood.Type.Equals(FoodType.Cucumber))
        {
            currentQuestionSound = findCucumber;
        }
        else if (currentFood.Type.Equals(FoodType.Pumpkin))
        {
            currentQuestionSound = findPumpkin;
        }
        else if (currentFood.Type.Equals(FoodType.Corn))
        {
            currentQuestionSound = findCorn;
        }
        else if (currentFood.Type.Equals(FoodType.Fish))
        {
            currentQuestionSound = findFish;
        }
        else
        {
            Debug.LogError("Current Food type does not have audio for a question:" + currentFood.Type);
        }

        currentQuestionSound.PlayDelayed(1);

        return currentFood;
    }
}
