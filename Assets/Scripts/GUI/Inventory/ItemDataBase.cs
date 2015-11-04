using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using LitJson;

public class ItemDataBase : MonoBehaviour {

    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/items.json"));
        ConstructItemDatabase();
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            //database.Add(new Item((int) itemData[i]["id"], itemData[i]["title"].ToString(), (int) itemData[i]["value"]));
        }
    }
    
}
