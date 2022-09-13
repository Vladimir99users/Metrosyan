using UnityEngine;

public class ProjectaleFactory
{
    public Projectale Get(EntityStats stats)
    {
        return new Projectale(stats.Damage, stats.Type, stats.Name);
    }
  
}
