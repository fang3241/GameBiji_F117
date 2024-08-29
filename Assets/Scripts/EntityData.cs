using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    //
    //Each inside of stats of entity
    public struct Plantables
    {
        public int id;
        public string Name;
        public string Desc;
        public int HP;
        public int Atk;
        public int Spd;
        public bool isAoe;
    }

    //The stats of the entity itself
    //
    public Plantables[] Plantable = new Plantables[4]
    {
        new Plantables{
            id = 1,
            Name = "Cabai",
            Desc = "pedes",
            HP = 5,
            Atk = 0,
            Spd = 0,
            isAoe = false
        },
        new Plantables{
            id = 2,
            Name = "Tomat",
            Desc = "merah bulet",
            HP = 5,
            Atk = 3,
            Spd = 3,
            isAoe = false
        },
        new Plantables{
            id = 3,
            Name = "Kedelai",
            Desc = "bisa jadi susu",
            HP = 5,
            Atk = 1,
            Spd = 5,
            isAoe = false
        },
        new Plantables{
            id = 4,
            Name = "Semangka",
            Desc = "Ijo bulet",
            HP = 5,
            Atk = 5,
            Spd = 1,
            isAoe = false
        }
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
