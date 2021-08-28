using UnityEngine;

public class SaveObject
{
    public Vector3 pos;
    public struct tower
    {
        Vector3 pos;
        int range;
        int price;
        int kills;
        int waves;
        float power;
        float attacksPerSecond;
    }
    public struct data
    {
        Turret[] turrets;
        int totalRounds;
        bool victory;
        int level;
        int startMoney;
        int moneyKill;
    }
}
