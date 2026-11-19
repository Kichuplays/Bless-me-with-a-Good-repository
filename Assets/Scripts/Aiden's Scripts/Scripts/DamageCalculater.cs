using UnityEngine;

public static class DamageCalculater  
{
    public static int CalculateDamage(
         PlayerCombat player,
         SummonController summonController,
         EnemeyCombat enemy,
         SkillData skill)
    {
        int attackPower;

        if (skill.element == ElementType.pychical)
        {
            attackPower =
                summonController.GetAttack(player);
        }
        else
        {
            attackPower =
                summonController.GetMagic(player);
        }

        int damage =
            attackPower +
            skill.SkillDamage -
            enemy.data.defense;

        damage = Mathf.Max(1, damage);

        elementResistence resistance =
            GetResistance(
                enemy.data,
                skill.element
            );

        switch (resistance)
        {
            case elementResistence.Weak:

                damage = Mathf.RoundToInt(
                    damage * 1.5f
                );

                Debug.Log("WEAK!");

                break;

            case elementResistence.Resist:

                damage = Mathf.RoundToInt(
                    damage * 0.5f
                );

                Debug.Log("RESIST!");

                break;

            case elementResistence.Null:

                damage = 0;

                Debug.Log("NULL!");

                break;
        }

        return damage;
    }

    private static elementResistence GetResistance(
        EnemyData enemy,
        ElementType element)
    {
        switch (element)
        {
            case ElementType.fire:
                return enemy.fire;

            case ElementType.water:
                return enemy.water;

            case ElementType.earth:
                return enemy.earth;

            case ElementType.Wind:
                return enemy.wind;
            case ElementType ice:
                return enemy.ice;

            default:
                return elementResistence.Normal;
        }
    }



}
