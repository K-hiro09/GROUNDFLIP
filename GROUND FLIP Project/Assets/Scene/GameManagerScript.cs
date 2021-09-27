using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲーム全体を管理
public class GameManagerScript
{
    static private bool PlayerJump;         //プレイヤーがジャンプ中かの判定
    static private int PlayerWallWhich;     //プレイヤーが上下どちらの壁にいるかの判定
    static private bool PlayerAlive;        //プレイヤーの生死判定
    static private bool PlayerContinuDead;  //プレイヤー
    static private int ScoreNum;            //スコア
    static private int AudioNum;            //ステージセレクト時のBGM
    static private int GameTimer;           //ゲーム全体の時間(BGMサビ部分で加速させる用(ｶﾘ))
    static private bool Performance;        //演出中化否か。
    static private int Dir;                 //どの方向に飛んでいる最中か
    static private int AreaScorePlus;       //どの程度エリア内に居たかで加算スコアを変更する用
    static private bool HitScoreStar;       //スコア加算スターがスコアテキストに当たったか否かチェック
    static private bool SpeedUpFlg;         //BGMがサビ部分に来たら障害物等のスピードを上げる
    static private int WaveCount;           //何Wave目か取得
    static private int MaxWaveCount;        //全Wave幾つかの取得
    static private bool PlayerGoalFlg;      //ステージのゴール判定
    static private int StageNumber;         //何ステージ目か取得
    static private float NowAudioTime;      //各ステージBGMの時間が今何秒なのか
    static private float MaxAudioTime;      //各ステージBGMのマックスの時間(ゴール時の)
    static private int StageNow;            //何ステージ目まで行ってたのか
    static private bool GoalHit;            //ゴールしたかどうか
    static private int SponaRand;
    static public void Init()
    {
        PlayerJump = false;
        PlayerAlive = true;
        PlayerContinuDead = false;
        PlayerWallWhich = 0;    //0:下 1:上
        ScoreNum = 0;
        AudioNum = 1;
        GameTimer = 0;
        Performance = false;
        Dir = 0;               //0:下方向 1:上方向
        AreaScorePlus = 0;     //1:一段階目 2:二段階目 3:最大
        HitScoreStar = false;
        SpeedUpFlg = false;
        WaveCount = 0;
        MaxWaveCount = 0;
        PlayerGoalFlg = false;
        StageNumber = 0;
        NowAudioTime = 0.0f;
        MaxAudioTime = 0.0f;
        StageNow = 0;
        GoalHit = false;
        SponaRand = 0;
    }
    // ゲッター
    static public bool GetPlayerJump() { return PlayerJump; }
    static public int GetPlayerWallWhich() { return PlayerWallWhich; }
    static public bool GetPlayerAlive() { return PlayerAlive; }
    static public bool GetPlayerContinuDead() { return PlayerContinuDead; }

    static public int GetScoreNum() { return ScoreNum; }
    static public int GetAudioNum() { return AudioNum; }
    static public int GetGameTimer() { return GameTimer; }
    static public bool GetPerformance() { return Performance; }
    static public int GetPlayerDir() { return Dir; }
    static public int GetAreaScorePlus() { return AreaScorePlus; }
    static public bool GetHitScoreStar() { return HitScoreStar; }
    static public bool GetSpeedUpFlg() { return SpeedUpFlg; }
    static public int GetWaveCount() { return WaveCount; }
    static public int GetMaxWaveCount() { return MaxWaveCount; }

    static public bool GetPlayerGoalFlg() { return PlayerGoalFlg; }
    static public int GetStageNumber() { return StageNumber; }
    static public float GetNowAudioTime() { return NowAudioTime; }
    static public float GetMaxAudioTime() { return MaxAudioTime; }
    static public int GetStageNow() { return StageNow; }
    static public bool GetGolaHit() { return GoalHit; }

    static public int GetSponaRand() { return SponaRand;}

    // セッター
    static public void SetPlayerJump(bool Flag) { PlayerJump = Flag; }
    static public void SetPlayerWallWhich(int Which) { PlayerWallWhich = Which; }
    static public void SetPlayerAlive(bool Flag) { PlayerAlive = Flag; }
    static public void SetPlayerContinuDead(bool Flag) { PlayerContinuDead = Flag; }
    static public void SetScoreNum(int Num) { ScoreNum = Num; }
    static public void SetAudioNum(int Num) { AudioNum = Num; }
    static public void SetGameTimer(int T) { GameTimer += T; }
    static public void SetPerformance(bool Flag) { Performance = Flag; }
    static public void SetPlayerDir(int D) { Dir = D; }
    static public void SetAreaScorePlus(int Num) { AreaScorePlus = Num; }
    static public void SetHitScoreStar(bool Flag) { HitScoreStar = Flag; }
    static public void SetSpeedUpFlg(bool Flag) { SpeedUpFlg = Flag; }
    static public void SetWaveCount(int Count) { WaveCount = Count; }
    static public void SetMaxWaveCount(int Count) { MaxWaveCount = Count; }
    static public void SetPlayerGoalFlg(bool Flag) { PlayerGoalFlg = Flag; }
    static public void SetStageNumber(int Num) { StageNumber = Num; }
    static public void SetNowAudioTime(float Time) { NowAudioTime = Time; }
    static public void SetMaxAudioTime(float Time) { MaxAudioTime = Time; }
    static public void SetStageNow(int Num) { StageNow = Num; }
    static public void SetGoalHit(bool flg) { GoalHit = flg; }
    static public void SetSponaRand(int num) { SponaRand = num; }
}
