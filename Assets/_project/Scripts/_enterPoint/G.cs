using UnityEngine;

public static class G
{
    public static Game Game;
    public static UpgradeSystem UpgradeSystem;
}

public class Game : MonoBehaviour
{
    public Wallet Wallet;

    private void Awake()
    {
        G.Game = this;
    }
}