using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player ActivePlayer;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }
}
