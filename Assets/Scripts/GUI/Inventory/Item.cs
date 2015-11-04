using System;
using UnityEngine;
using System.Collections;

public class Item
{

    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int health { get; set; }
    public int power { get; set; }
    public int haste { get; set; }
    public int recover { get; set; }
    public bool stackable { get; set; }
    public string slug { get; set; }

    public Item(int id, string title, int value, int health, int power, int haste, int recover, bool stackable, string slug)
    {
        ID = id;
        Title = title;
        Value = value;
        this.health = health;
        this.power = power;
        this.haste = haste;
        this.recover = recover;
        this.stackable = stackable;
        this.slug = slug;
    }


    public Item()
    {
        ID = -1;
    }
}
