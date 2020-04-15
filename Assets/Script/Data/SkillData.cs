﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    //("General")]
    // skill archetype defines the skill. If you choose a Melee Sweep only variables from under Melee Sweep header will affect skill.
    //技能原型定义了技能。如果你选择一个近战扫荡只有变量从下面的近战扫荡头将影响技能。
    public int Id;
    public int skillArchetype;
    public string UNIQUE_skillName;
    public string sprite;//技能图标
    public string spriteNoMana;//没蓝时的技能图标
    public bool hasLimitedNoOfUses = false;//投掷物，是否消耗子弹
    public int ammo_amount;//弹药消耗

    //=======Melee Sweep=======
    public float damageModifierPercent;//伤害是武器伤害的，加成比 1是无加成
    public float arcWidth;//身前宽度，这是一半，左右各一半
    public float arcLength;//身前长度，
    //=======Melee Sweep=======

    //=======Consumable=======
    public int sttChange;//要改变的属性
    public float sttChangeDuration;//改变的时间//如果sttChangeDuration为0，则更改将是永久的。
    public float sttChangeAmount;//改变的数值
    public float sttChangeUseDelay;//使用间隔，即CD
    //public int sttNoOfUses;
    //=======Consumable=======

    //=======Projectile=======
    public string prefabFireballVFX;//特效
    public int addtionalProjectiles = 0;//附加的投射物
    public float damageProjectile;//投射物的伤害
    public int damageTypeProjectile;//伤害类型
    public float manaCostProjectile;//蓝量消耗
    public string castPointLocalPosProjectile;//相对于投掷点的位置
    public float speedProjectile;//投掷物速度
    public float lifetimeProjectile;//投掷物生命周期
    public bool rigidbodyMovement = true;//移动方式，rigidBody或Translate
    public float piercing = 0f;//穿透概率，0-100，不在这个范围内，就是一定能穿透
    public int linkedSkillProjectile1;
    public bool linkOnEndOfLife = true;
    //=======Projectile=======

    //=======AoE=======
    public float AoEdamageDelay;//延迟后算伤害
    public float AoEdamage;//伤害
    public int AoEdamageType;//伤害类型
    public float AoEradius;//伤害范围
    public string AoEprefabVFX;//特效
    public float AoEmanaCost;//蓝量消耗
    //=======AoE=======

    //=======Collider-DoT=======
    public string instantiatePrefab;//特效
    public float dps = 11f;//伤害
    public double damageFrequency = 0.02f;//伤害频率，每次伤害11*0.02，每0.02秒再伤害一次
    public float manaCostPerSecOrUse = 11f;//蓝量消耗，每秒或者一次
    public float lifetime = 1.5f;//技能生命周期
    public bool spawnAtCastPoint = true;//是否产生在发射点，如果是，就是射线哪样的特效持续的。不然就是直接出现在鼠标位置。移动端不支持出现在鼠标位置
    //=======Collider-DoT=======

}