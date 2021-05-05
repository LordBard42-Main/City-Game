using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logic
{

    public static bool WillBuyProduct(Disposition ingredientDisposition, Disposition toppingDisposition, ItemQuality mixtureQuality, CharacterTraits characterTrait,
        Disposition playerStanding, int baseCostOfProduct, int costOfProduct)
    {
        int mixtureModifier = RetrieveBaseValueFromMixtureQuality(mixtureQuality);
        int currentRating = 0;

        //Debug.Log("MMODIFIERS Rating: " + mixtureModifier);

        currentRating += (ModifierByDisposition(ingredientDisposition) * mixtureModifier);
        currentRating += (ModifierByDisposition(toppingDisposition) * mixtureModifier);
        currentRating += RetrieveNPCTraitModifier(characterTrait);

        currentRating *= RetrievePlayerStandingModifier(playerStanding);

        //Debug.Log("Current Rating: " + currentRating);

        //Debug.Log("Cost - BaseCost: " + (costOfProduct - baseCostOfProduct));


        return (currentRating >= (costOfProduct - baseCostOfProduct));
    }

    /// <summary>
    /// Retrieve the number which need to be met in order for NPC to buy item
    /// </summary>
    /// <param name="characterTrait"></param>
    /// <returns></returns>
    private static int RetrieveNPCTraitModifier(CharacterTraits characterTrait)
    {
        int successFloor = 0;
        switch (characterTrait)
        {
            case CharacterTraits.Neutral:
                successFloor = 0;
                break;
            case CharacterTraits.Easygoing:
                successFloor = 5;
                break;
            case CharacterTraits.Hardball:
                successFloor = -5;
                break;
            default:
                break;
        }
         
        return successFloor;
    }


    /// <summary>
    /// Retrieves values based on how much an npc likes an ingredient
    /// </summary>
    /// <param name="disposition"></param>
    /// <returns></returns>
    private static int ModifierByDisposition(Disposition disposition)
    {
        int value = 0;

        switch (disposition)
        {
            case Disposition.Neutral:
                value = 1;
                break;
            case Disposition.Hate:
                value = -42;
                break;
            case Disposition.Dislike:
                value = -2;
                break;
            case Disposition.Like:
                value = 2;
                break;
            case Disposition.Love:
                value = 21;
                break;
            default:
                break;
        }

        return value;
    }
    
    private static int RetrieveBaseValueFromMixtureQuality(ItemQuality itemQuality)
    {
        int value = 0;

        switch (itemQuality)
        {
            case ItemQuality.Low:
                value = 2;
                break;
            case ItemQuality.Medium:
                value = 5;
                break;
            case ItemQuality.High:
                value = 6;
                break;
            case ItemQuality.Legendary:
                value = 10;
                break;
            default:
                break;
        }

        return value;
    }

    private static int RetrievePlayerStandingModifier(Disposition playerStanding)
    {

        int value = 0;

        switch (playerStanding)
        {
            case Disposition.Neutral:
                value = 1;
                break;
            case Disposition.Hate:
                value = -4;
                break;
            case Disposition.Dislike:
                value = -2;
                break;
            case Disposition.Like:
                value = 2;
                break;
            case Disposition.Love:
                value = 4;
                break;
            default:
                break;
        }
        return value;

    }
}
