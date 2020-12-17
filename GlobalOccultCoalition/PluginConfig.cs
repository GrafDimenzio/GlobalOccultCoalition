using Synapse.Config;
using UnityEngine;
using System.Collections.Generic;

namespace GlobalOccultCoalition
{
    public class PluginConfig : AbstractConfigSection
    {
        public float SpawnChanche = 30f;

        public bool ff = false;

        public SerializedMapPoint GOCSpawn = new SerializedMapPoint
        {
            Room = "Root_*&*Outside Cams",
            X = 189.8241f,
            Y = -5.405029f,
            Z = -90.30247f
        };

        public int Health = 120;

        public SerializedAmmo Ammo = new SerializedAmmo();

        public string Color = "white";

        public List<SerializedItem> Inventory = new List<SerializedItem>
        {
            new SerializedItem((int)ItemType.KeycardChaosInsurgency,0f,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.GunE11SR,40f,4,4,1,Vector3.one),
            new SerializedItem((int)ItemType.GrenadeFrag,0f,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Radio,100f,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Disarmer,0f,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Medkit,0f,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Painkillers,0f,0,0,0,Vector3.one)
        };
    }

    public class SerializedAmmo
    {
        public uint Ammo9 = 80;
        public uint Ammo7 = 80;
        public uint Ammo5 = 80;
    }
}
