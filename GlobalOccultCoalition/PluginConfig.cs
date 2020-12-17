using Synapse.Config;
using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;

namespace GlobalOccultCoalition
{
    public class PluginConfig : AbstractConfigSection
    {
        [Description("The Chanche that a GOC Physics strike team is spawning instead of an Mtf")]
        public float SpawnChanche = 30f;

        [Description("If the GOC team can hurt them among themselves")]
        public bool ff = false;

        [Description("The Location where they spawn")]
        public SerializedMapPoint GOCSpawn = new SerializedMapPoint
        {
            Room = "Root_*&*Outside Cams",
            X = 189.8241f,
            Y = -5.405029f,
            Z = -90.30247f
        };

        [Description("The Health they have")]
        public int Health = 120;

        [Description("The Amount of Ammo they spawn with")]
        public SerializedAmmo Ammo = new SerializedAmmo();

        [Description("The Color which the GOC display text should have")]
        public string Color = "white";

        [Description("The Items they spawn with")]
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
