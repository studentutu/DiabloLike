﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DoT伤害的触发，技能到时间销毁
/// </summary>
public class aRPG_DoT : MonoBehaviour {
    
    SkillData skill;
    string casterTagThis;
    aRPG_Master ms;

    int enemyID;
    aRPG_EnemyStats enemyStats;
    //bool do_DotDmg = true;
    bool doDamageToPlayer = false;

    Dictionary<int, bool> dot_enemy_Dictionary = new Dictionary<int, bool>();

    void Start()
    {
        if (skill != null && skill.spawnAtCastPoint == false)
        {
            Destroy(gameObject, (float)skill.lifetime);//回收
        }
    }
    
    public void SendObjects(aRPG_Master receivedScript , SkillData passedSkill, string casterTag)
    {
        skill = passedSkill;
        casterTagThis = casterTag;
        ms = receivedScript;
    }
    
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "enemy" && casterTagThis == "Player")
        {
            enemyID = enemy.GetInstanceID();
            if (!dot_enemy_Dictionary.ContainsKey(enemyID))
            {
                dot_enemy_Dictionary.Add(enemyID, false);
            }

            if (dot_enemy_Dictionary[enemyID] == false)
            {
                dot_enemy_Dictionary[enemyID] = true;
                enemyStats = enemy.GetComponent<aRPG_EnemyStats>();
                StartCoroutine(DotDmg(enemyID, enemyStats, CalculateDmg(), (float)skill.damageFrequency));
            }
        }
        if (enemy.tag == "Player" && casterTagThis == "enemy")
        {
            doDamageToPlayer = true;
            StartCoroutine(DotDmg(CalculateDmg(), (float)skill.damageFrequency));
        }
   }

    void OnTriggerExit(Collider enemy)
    {
        if (enemy.tag == "enemy" && casterTagThis == "Player")
        {
            dot_enemy_Dictionary[enemy.GetInstanceID()] = false;
        }
        if (enemy.tag == "Player" && casterTagThis == "enemy")
        {
            doDamageToPlayer = false;
        }
    }

    float CalculateDmg()
    {
        return (float)(skill.dps * skill.damageFrequency);
    }

    IEnumerator DotDmg(float dmgPerTick, float dmgFrequency)
    {
        while (doDamageToPlayer)
        {
            ms.psStats.curAttr.Health -= (long)dmgPerTick;
            yield return new WaitForSeconds(dmgFrequency);
        }
    }

    IEnumerator DotDmg(int enemyID, aRPG_EnemyStats enemyScript, float dmgPerTick, float dmgFrequency)
    {
        while (dot_enemy_Dictionary[enemyID])
        {
            enemyScript.ReceiveDamage( damageType.Physical, dmgPerTick);//.curAttr.Health -= (long);
            yield return new WaitForSeconds(dmgFrequency);
        }
    }
}
