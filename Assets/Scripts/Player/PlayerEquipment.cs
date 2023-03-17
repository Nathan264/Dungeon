using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    [SerializeField] private PlayerLoadout loadout;

    private void Equip(Equipment newEquipment)
    {
        switch (newEquipment.type)
        {
            case "Weapon":
                Unequip(loadout.weapon);
                loadout.weapon = newEquipment;
                break;

            case "Armor":
                Unequip(loadout.armor);
                loadout.armor = newEquipment;
                break;

            case "Helmet":
                Unequip(loadout.helmet);
                loadout.helmet = newEquipment;
                break;

            case "Boots":
                Unequip(loadout.boots);
                loadout.boots = newEquipment;
                break;
        }

        pStats.hp += newEquipment.hp;
        pStats.sp += newEquipment.sp;
        pStats.atk += newEquipment.atk;
        pStats.def += newEquipment.def;
        pStats.spd += newEquipment.spd;
    }

    private void Unequip(Equipment oldEquipment)
    {
        switch (oldEquipment.type)
        {
            case "Weapon":
                loadout.weapon = null;
                break;

            case "Armor":
                loadout.armor = null;
                break;

            case "Helmet":
                loadout.helmet = null;
                break;

            case "Boots":
                loadout.boots = null;
                break;

        }

        pStats.hp -= oldEquipment.hp;
        pStats.sp -= oldEquipment.sp;
        pStats.atk -= oldEquipment.atk;
        pStats.def -= oldEquipment.def;
        pStats.spd -= oldEquipment.spd;
    }
}
