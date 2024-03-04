using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> inventory;
    public Item Crust;
    public Item Seasoning1;
    public Item Seasoning2;
    public Item Coating;

    public List<Item> getEquiped() {
        return new List<Item>{Crust, Seasoning1, Seasoning2, Coating};
    }
}
