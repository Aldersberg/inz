using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class player_tests
{
    [Test]
    public void player_HealTest()
    {
        Player player = new Player();
        player.maxHp = 100;
        player.hp = 0;
        player.healPlayer(10);
        Assert.AreEqual(10, player.hp);

    }
    [Test]
    public void player_OverhealTest()
    {
        Player player = new Player();
        player.maxHp = 10;
        player.hp = 0;
        player.healPlayer(100);
        Assert.AreEqual(10, player.hp);
    }
    [Test]
    public void player_damageTest()
    {
        Player player = new Player();
        player.maxHp = 100;
        player.hp = 100;
        player.receiveDamage(10);
        Assert.AreEqual(90, player.hp);
    }

}
