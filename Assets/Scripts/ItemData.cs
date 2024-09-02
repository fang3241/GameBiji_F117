using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public class Item{
        public int id;
        public string name;
        public Sprite sprite;
        public string desc;
        public int price;
        public int hp;
        public int atk;
        public int spd;
        public int grow;
        public int atkRadius;
        public int atkRange;

        public Item(int _id, string _name, Sprite _sprite, string _desc, int _price, int _hp, int _atk, int _spd, int _grow, int _atkRadius, int _atkRange){
            id = _id;
            name = _name;
            sprite = _sprite;
            desc = _desc;
            price = _price;
            hp = _hp;
            atk = _atk;
            spd = _spd; 
            grow = _grow;
            atkRadius = _atkRadius;
            atkRange = _atkRange;
        }
    }

    public Item[] items;

    // Start is called before the first frame update
    void Awake()
    {
        Sprite loadedSprite = Resources.Load<Sprite>("Sprite/Inventory/Cabe");

        if (loadedSprite != null)
        {
            Debug.Log("Sprite loaded successfully: " + loadedSprite.name);

            // Optionally, set the sprite to the GameObject's SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = loadedSprite;
            }
        }
        else
        {
            Debug.LogError("Sprite not found at path: " + "Sprite/Inventory/Cabe");
        }
        //
        items = new Item[7];
        items[0] = new Item(0, "Biji Cabe", Resources.Load<Sprite>("Sprite/Inventory/Cabe"), "Biji Cabe Untuk Ditanam", 5, 5, 0, 0, 1, 0, 0);
        items[1] = new Item(1, "Biji Tomat", null, "Biji Tomat Untuk Ditanam", 10, 5, 3, 3, 0, 1, 3);
        items[2] = new Item(2, "Biji Anggur", null, "Biji Anggur Untuk Ditanam", 20, 5, 2, 5, 4, 1, 3);
        items[3] = new Item(3, "Biji Semangka", null, "Biji Semangka Untuk Ditanam", 30, 5, 5, 2, 5, 2, 3);
        items[4] = new Item(4, "Pagar", null, "Pagar#", 15, 15, 0, 0, 0, 0, 0);
        items[5] = new Item(5, "Pupuk", null, "Untuk mempercepat pertumbuhan tanaman", 10, 0, 0, 0, 0, 0, 0);
        items[6] = new Item(6, "Potion", null, "Untuk menyembuhkan tanaman", 10, 0, 0, 0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
