using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public enum GameState
    {
        Start,      // bắt đầu game
        Play,    // trong quá trình chơi
        Pause,      // pause game
        End,        // xử lý thắng thua
    }
}
