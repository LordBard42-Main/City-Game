using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Flags]
public enum ConsumableType { Mixture = (1 << 0), Ingredient = (1 << 1), Topping = (1 << 2), Special = (1 << 3), Product = (1 << 4) }

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Inventory/Consumable")]
public class ConsumableItem : Item
{

    [Header("Consumable Useage Info")]
    public bool isConsumable = true;
    [SerializeField] private ConsumableType consumableType;
    
    private bool isRecipe;
    private Items mixture;
    private Items ingredient;
    private Items topping;

    private ItemQuality mixtureQuality;

    public ConsumableType ConsumableType { get => consumableType; set => consumableType = value; }
    public Items Mixture { get => mixture; set => mixture = value; }
    public Items Ingredient { get => ingredient; set => ingredient = value; }
    public Items Topping { get => topping; set => topping = value; }
    public bool IsRecipe { get => isRecipe; set => isRecipe = value; }
    public ItemQuality MixtureQuality { get => mixtureQuality; set => mixtureQuality = value; }

    public virtual void Use( )
    {
        //Use Item
        //Something might happpen
        Debug.Log("Using Item" + name);

    }
    
}

[CustomEditor(typeof(ConsumableItem))]
public class ConsumableItemEditor : Editor
{

    private bool isMixture;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ///This refrences the script being edited.
        var myScript = target as ConsumableItem;

        EditorGUI.BeginChangeCheck();
        ///This is a custom toggle group, it greys it out instead of hiding it
        ///
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Mixture Information: ", EditorStyles.boldLabel);
        isMixture = (myScript.ConsumableType == ConsumableType.Mixture);
        EditorGUILayout.BeginToggleGroup("Is Mixture: ", isMixture);
        myScript.MixtureQuality = (ItemQuality)EditorGUILayout.EnumPopup("Mixture Quality: ", myScript.MixtureQuality);
        EditorGUILayout.EndToggleGroup();


        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Recipe Information: ", EditorStyles.boldLabel);
        myScript.IsRecipe = EditorGUILayout.BeginToggleGroup("Is Recipe: ", myScript.IsRecipe);
        myScript.Mixture = (Items)EditorGUILayout.EnumPopup("Mixture: ", myScript.Mixture);
        myScript.Ingredient = (Items)EditorGUILayout.EnumPopup("Ingredient: ", myScript.Ingredient);
        myScript.Topping = (Items)EditorGUILayout.EnumPopup("Topping: ", myScript.Topping);
        myScript.MixtureQuality = (ItemQuality)EditorGUILayout.EnumPopup("Mixture Quality Used: ", myScript.MixtureQuality);
        EditorGUILayout.EndToggleGroup();
        bool somethingChanged = EditorGUI.EndChangeCheck();

        EditorUtility.SetDirty(myScript);


    }
}

