using System.Collections.Generic;
using UnityEngine;

public class ResetGlobalData : MonoBehaviour
{
    void Start()
    {
        GlobalData.bossDisponiveis = new List<string>{
            "Harlequin",
            "Pierrot",
            "Jester"
        };

        GlobalData.cenasBossFights = new Dictionary<string, string>{
            {"Harlequin", "Harlequim Boss Fight"},
            {"Pierrot", "Pierrot Boss Fight"},
            {"Jester", "Jester Boss Fight"}
        };

        GlobalData.ultimoBoss = "Harlequin";

        GlobalData.armaEquipada = "Martelo";
        GlobalData.poderEquipado = "CospeFogo";
        GlobalData.pocaoEquipada = "HP";
        GlobalData.playerCanTakeDamage=true;
        GlobalData.harlequimIdle=false;
        GlobalData.primeiraVezJackpot=true;

        GlobalData.level = 0;
    }

}
