using UnityEngine;
using System.Runtime.InteropServices;

public class RateGame : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGames();

    public void RateGameButton()
    {
        RateGames();
    }
}   