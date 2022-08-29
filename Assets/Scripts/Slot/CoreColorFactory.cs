using UnityEngine;

public class CoreColorFactory
{
    public Color Get(Core core) =>
    
        core.Stats.Type switch
        {
            ElementType.Fire => new Color(200, 0, 0, 255),
            ElementType.Ice => new Color(0, 0, 200, 255),
            _ => new Color(0, 0, 0, 255),
        };

}