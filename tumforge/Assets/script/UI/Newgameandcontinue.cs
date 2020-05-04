using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newgameandcontinue : MonoBehaviour
{
    public void Continue()
    {
        PlayerData data = Code_savesystem.loadPlayer();
        Code_staticDataHolder.highestLV = data.level;
    }
    public void Newgame()
    {
        Code_staticDataHolder.highestLV = 0;
    }


}
