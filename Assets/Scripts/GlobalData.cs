using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static bool useGlobalData = false;

    public static KeyCode
        attackButton = KeyCode.A,
        powerButton = KeyCode.S,
        potionButton = KeyCode.D,
        roletaButton = KeyCode.Space,
        pauseButton = KeyCode.Escape,
        dashButton = KeyCode.LeftShift;

    public static List<string> bossDisponiveis = new List<string>{
        "Harlequin",
        "Pierrot",
        "Jester"
    };

    public static Dictionary<string, string> cenasBossFights = new Dictionary<string, string>{
        {"Harlequin", "Harlequim Boss Fight"},
        {"Pierrot", "Pierrot Boss Fight"},
        {"Jester", "Jester Boss Fight"}
    };

    public static string ultimoBoss = "Harlequin";

    public static string armaEquipada = "Martelo", poderEquipado = "CospeFogo", pocaoEquipada = "HP";
    public static bool playerCanTakeDamage=true, harlequimIdle=false, primeiraVezJackpot=true;

    public static int level = 0;

    public static Dictionary<string, float[]> playerData = new Dictionary<string, float[]>
    {
        // Level 0 | Level 1 | Level 2 | Level 3 | Level 4
        {"HP", new float[] { 6, 12, 14, 16, 18 }},
        {"Agilidade", new float[] { 1, 1.1f, 1.2f, 1.35f, 1.5f }},
        {"PowerCD", new float[] { 1, 1.05f, 1.1f, 1.2f, 1.3f }},
    };

    public static Dictionary<string, float[]> weaponsData = new Dictionary<string, float[]>
    {
        // Level 0 | Level 1 | Level 2 | Level 3 | Level 4 | Hits / seg
        {"Martelo", new float[] { 25, 27, 30, 33, 36, 1 }},
        {"Florzinha", new float[] { 15, 17, 20, 23, 26, 0.8f }},
        {"Espada", new float[] { 25, 27, 30, 33, 36, 0.9f }},
        {"Canhao", new float[] { 30, 32, 35, 38, 41, 0.5f }},
        {"Malabares", new float[] { 30, 32, 35, 38, 41, 1.4f }},
    };

    public static Dictionary<string, float[]> skillsData = new Dictionary<string, float[]>
    {
        // CD Base - seg | Dano base | Duração
        {"CospeFogo", new float[] { 25, 50 }},
        {"Coelhos", new float[] { 30, 60 }},
        {"BangBang", new float[] { 25, 80 }},
        {"Coringa", new float[] { 30 }},
        {"Nuvem", new float[] { 40, 15, 10 }},
    };

    public static Dictionary<string, float[]> potionsData = new Dictionary<string, float[]>
    {
        // Em ordem: Pie, Ice Cream, Croissant, Banana Split, Lollipop
        // Os números são em ordem que aparecem na planilha da esquerda pra direita
        {"HP", new float[] { 2, 0, 60 }}, // Heal [0] HP, [2] CD
        {"HPDano", new float[] { 4, 0.7f, 10, 40 }}, // Heal [0] HP, [1] de dano por [2] seg, [3] CD
        {"DanoHP", new float[] { 2, 10, -2, 40 }}, // x[0] Dano por [1] seg, [2] HP Máximo, [3] CD
        {"Hits", new float[] { 1.5f, 5, 10, 1, 60 }}, // x[0] dano por [1] hits, [2] seg [3] de dano, [4] CD
        {"Poder", new float[] { 2, 20, 1.5f, 75 }}, // x[0] dano do poder por [1] seg, x[2] CD permanente, [3] CD
    };

    public static Dictionary<string, float[]> bossData = new Dictionary<string, float[]>
    {
        // Level 0 | Level 1 | Level 2 | Level 3 | Level 4
        {"HP", new float[] { 500, 550, 605, 665, 735 }},
        {"Dano", new float[] { 1, 1, 2, 3, 4 }},
    };
}
