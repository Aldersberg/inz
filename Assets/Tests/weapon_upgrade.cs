using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class weapon_upgrade
{
    [Test]
    public void weapon_upgradeTest()
    {
        weapon weapon = new weapon();
        weapon.damage = Random.Range(1,1000000);
        float preUpgrade = weapon.damage;
        weaponUpgradeWindow weaponUpgradeWindow = new weaponUpgradeWindow();
        weaponUpgradeWindow.upgradeWeapon(weapon);
        Assert.AreEqual(preUpgrade + 100, weapon.damage);
    }

}
