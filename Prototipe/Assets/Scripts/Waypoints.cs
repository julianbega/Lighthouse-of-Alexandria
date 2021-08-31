using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] AllWaypoints;
    public Transform[] Path1;
    public Transform[] Path2;
    public Transform[] Path3;
    public Transform[] Path4;
    public Transform[] Path5;
    public Transform[] Path6;
    public Transform[] Path7;
    public Transform[] Path8;
    public Transform[] Path9;
    public Transform[] Path10;
    public Transform[] Path11;
    public Transform[] Path12;
    public Transform[] Path13;
    public Transform[] Path14;
    public Transform[] Path15;
    public Transform[] Path16;
    public Transform[] Path17;
    public Transform[] Path18;
    public Transform[] Path19;
    public Transform[] Path20;
    public Transform[] Path21;
    public Transform[] Path22;
    public Transform[] Path23;
    public Transform[] Path24;
    public Transform[] Path25;
    public Transform[] Path26;
    public Transform[] Path27;
    public Transform[] Path28;
    public Transform[] Path29;
    public Transform[] Path30;
    public Transform[] Path31;
    public Transform[] Path32;
    public Transform[] Path33;
    public Transform[] Path34;
    public Transform[] Path35;
    public Transform[] Path36;
    public Transform[] Path37;
    public Transform[] Path38;
    public Transform[] Path39;
    public Transform[] Path40;
    public Transform father;

    private void Awake()
    {
        
        AllWaypoints = new Transform[father.childCount+1];
        AllWaypoints[0] = father;
        Debug.Log("father" + (father.childCount + 1));
        Debug.Log("father" + (AllWaypoints.Length + 1));
        for (int i = 1; i <= AllWaypoints.Length-1 ; i++)
        {
            AllWaypoints[i] = father.GetChild(i-1);
        }
    }
    private void Start()
    {
        #region Spawner1
        #region Path1 
        Path1[0] = AllWaypoints[1];
        Path1[1] = AllWaypoints[2];
        Path1[2] = AllWaypoints[3];
        Path1[3] = AllWaypoints[4];
        Path1[4] = AllWaypoints[5];
        Path1[5] = AllWaypoints[6];
        Path1[6] = AllWaypoints[10];
        Path1[7] = AllWaypoints[23];
        Path1[8] = AllWaypoints[52];
        #endregion /// bien
        #region Path2 
        Path2[0] = AllWaypoints[1];
        Path2[1] = AllWaypoints[2];
        Path2[2] = AllWaypoints[8];
        Path2[3] = AllWaypoints[9];
        Path2[4] = AllWaypoints[4];
        Path2[5] = AllWaypoints[5];
        Path2[6] = AllWaypoints[6];
        Path2[7] = AllWaypoints[10];
        Path2[8] = AllWaypoints[23];
        Path2[9] = AllWaypoints[52];
        #endregion /// bien
        #region Path3 
        Path3[0] = AllWaypoints[1];
        Path3[1] = AllWaypoints[2];
        Path3[2] = AllWaypoints[3];
        Path3[3] = AllWaypoints[4];
        Path3[4] = AllWaypoints[5];
        Path3[5] = AllWaypoints[15];
        Path3[6] = AllWaypoints[21];
        Path3[7] = AllWaypoints[52];
        #endregion ///bien
        #region Path4
        Path4[0] = AllWaypoints[1];
        Path4[1] = AllWaypoints[2];
        Path4[2] = AllWaypoints[8];
        Path4[3] = AllWaypoints[9];
        Path4[4] = AllWaypoints[4];
        Path4[5] = AllWaypoints[5];
        Path4[6] = AllWaypoints[15];
        Path4[7] = AllWaypoints[21];
        Path4[8] = AllWaypoints[52];
        #endregion /// bien
        #region Path5
        Path5[0] = AllWaypoints[1];
        Path5[1] = AllWaypoints[2];
        Path5[2] = AllWaypoints[8];
        Path5[3] = AllWaypoints[9];
        Path5[4] = AllWaypoints[13];
        Path5[5] = AllWaypoints[15];
        Path5[6] = AllWaypoints[21];
        Path5[7] = AllWaypoints[52];
        #endregion
        #endregion

        #region Spawner2
        #region Path6
        Path6[0] = AllWaypoints[7];
        Path6[1] = AllWaypoints[8];
        Path6[2] = AllWaypoints[9];
        Path6[3] = AllWaypoints[4];
        Path6[4] = AllWaypoints[5];
        Path6[5] = AllWaypoints[6];
        Path6[6] = AllWaypoints[10];
        Path6[7] = AllWaypoints[23];
        Path6[8] = AllWaypoints[52];
        #endregion
        #region Path7
        Path7[0] = AllWaypoints[7];
        Path7[1] = AllWaypoints[8];
        Path7[2] = AllWaypoints[9];
        Path7[3] = AllWaypoints[4];
        Path7[4] = AllWaypoints[5];
        Path7[5] = AllWaypoints[15];
        Path7[6] = AllWaypoints[21];
        Path7[7] = AllWaypoints[52];
        #endregion
        #region Path8
        Path8[0] = AllWaypoints[7];
        Path8[1] = AllWaypoints[8];
        Path8[2] = AllWaypoints[9];
        Path8[3] = AllWaypoints[13];
        Path8[4] = AllWaypoints[15];
        Path8[5] = AllWaypoints[21];
        Path8[6] = AllWaypoints[52];
        #endregion
        #region Path9
        Path9[0] = AllWaypoints[7];
        Path9[1] = AllWaypoints[16];
        Path9[2] = AllWaypoints[11];
        Path9[3] = AllWaypoints[12];
        Path9[4] = AllWaypoints[9];
        Path9[5] = AllWaypoints[13];
        Path9[6] = AllWaypoints[15];
        Path9[7] = AllWaypoints[21];
        Path9[8] = AllWaypoints[52];
        #endregion
        #region Path10
        Path10[0] = AllWaypoints[7];
        Path10[1] = AllWaypoints[16];
        Path10[2] = AllWaypoints[11];
        Path10[3] = AllWaypoints[12];
        Path10[4] = AllWaypoints[9];
        Path10[5] = AllWaypoints[4];
        Path10[6] = AllWaypoints[5];
        Path10[7] = AllWaypoints[15];
        Path10[8] = AllWaypoints[21];
        Path10[9] = AllWaypoints[52];
        #endregion
        #region Path11
        Path11[0] = AllWaypoints[7];
        Path11[1] = AllWaypoints[16];
        Path11[2] = AllWaypoints[11];
        Path11[3] = AllWaypoints[12];
        Path11[4] = AllWaypoints[9];
        Path11[5] = AllWaypoints[4];
        Path11[6] = AllWaypoints[5];
        Path11[7] = AllWaypoints[6];
        Path11[8] = AllWaypoints[10];
        Path11[9] = AllWaypoints[23];
        Path11[10] = AllWaypoints[52];
        #endregion
        #region Path12
        Path12[0] = AllWaypoints[7];
        Path12[1] = AllWaypoints[16];
        Path12[2] = AllWaypoints[17];
        Path12[3] = AllWaypoints[18];
        Path12[4] = AllWaypoints[19];
        Path12[5] = AllWaypoints[24];
        Path12[6] = AllWaypoints[14];
        Path12[7] = AllWaypoints[15];
        Path12[8] = AllWaypoints[21];
        Path12[9] = AllWaypoints[52];
        #endregion
        #region Path13
        Path13[0] = AllWaypoints[7];
        Path13[1] = AllWaypoints[16];
        Path13[2] = AllWaypoints[17];
        Path13[3] = AllWaypoints[18];
        Path13[4] = AllWaypoints[19];
        Path13[5] = AllWaypoints[27];
        Path13[6] = AllWaypoints[29];
        Path13[7] = AllWaypoints[20];
        Path13[8] = AllWaypoints[52];
        #endregion
        #region Path14
        Path14[0] = AllWaypoints[7];
        Path14[1] = AllWaypoints[16];
        Path14[2] = AllWaypoints[25];
        Path14[3] = AllWaypoints[26];
        Path14[4] = AllWaypoints[35];
        Path14[5] = AllWaypoints[36];
        Path14[6] = AllWaypoints[28];
        Path14[7] = AllWaypoints[29];
        Path14[8] = AllWaypoints[20];
        Path14[9] = AllWaypoints[52];
        #endregion
        #region Path15
        Path15[0] = AllWaypoints[7];
        Path15[1] = AllWaypoints[16];
        Path15[2] = AllWaypoints[25];
        Path15[3] = AllWaypoints[26];
        Path15[4] = AllWaypoints[35];
        Path15[5] = AllWaypoints[37];
        Path15[6] = AllWaypoints[44];
        Path15[7] = AllWaypoints[30];
        Path15[8] = AllWaypoints[22];
        Path15[9] = AllWaypoints[52];
        #endregion
        #endregion

        #region Spawner3
        #region Path16
        Path16[0] = AllWaypoints[16];
        Path16[1] = AllWaypoints[11];
        Path16[2] = AllWaypoints[12];
        Path16[3] = AllWaypoints[9];
        Path16[4] = AllWaypoints[13];
        Path16[5] = AllWaypoints[15];
        Path16[6] = AllWaypoints[21];
        Path16[7] = AllWaypoints[52];
        #endregion
        #region Path17
        Path17[0] = AllWaypoints[16];
        Path17[1] = AllWaypoints[11];
        Path17[2] = AllWaypoints[12];
        Path17[3] = AllWaypoints[9];
        Path17[4] = AllWaypoints[4];
        Path17[5] = AllWaypoints[5];
        Path17[6] = AllWaypoints[15];
        Path17[7] = AllWaypoints[21];
        Path17[8] = AllWaypoints[52];
        #endregion
        #region Path18
        Path18[0] = AllWaypoints[16];
        Path18[1] = AllWaypoints[11];
        Path18[2] = AllWaypoints[12];
        Path18[3] = AllWaypoints[9];
        Path18[4] = AllWaypoints[4];
        Path18[5] = AllWaypoints[5];
        Path18[6] = AllWaypoints[6];
        Path18[7] = AllWaypoints[10];
        Path18[8] = AllWaypoints[23];
        Path18[9] = AllWaypoints[52];
        #endregion
        #region Path19
        Path19[0] = AllWaypoints[16];
        Path19[1] = AllWaypoints[17];
        Path19[2] = AllWaypoints[18];
        Path19[3] = AllWaypoints[19];
        Path19[4] = AllWaypoints[24];
        Path19[5] = AllWaypoints[14];
        Path19[6] = AllWaypoints[15];
        Path19[7] = AllWaypoints[21];
        Path19[8] = AllWaypoints[52];
        #endregion
        #region Path20
        Path20[0] = AllWaypoints[16];
        Path20[1] = AllWaypoints[17];
        Path20[2] = AllWaypoints[18];
        Path20[3] = AllWaypoints[19];
        Path20[4] = AllWaypoints[27];
        Path20[5] = AllWaypoints[29];
        Path20[6] = AllWaypoints[20];
        Path20[7] = AllWaypoints[52];
        #endregion
        #region Path21
        Path21[0] = AllWaypoints[16];
        Path21[1] = AllWaypoints[25];
        Path21[2] = AllWaypoints[26];
        Path21[3] = AllWaypoints[35];
        Path21[4] = AllWaypoints[36];
        Path21[5] = AllWaypoints[28];
        Path21[6] = AllWaypoints[29];
        Path21[7] = AllWaypoints[20];
        Path21[8] = AllWaypoints[52];
        #endregion
        #region Path22
        Path22[0] = AllWaypoints[16];
        Path22[1] = AllWaypoints[25];
        Path22[2] = AllWaypoints[26];
        Path22[3] = AllWaypoints[35];
        Path22[4] = AllWaypoints[37];
        Path22[5] = AllWaypoints[44];
        Path22[6] = AllWaypoints[30];
        Path22[7] = AllWaypoints[22];
        Path22[8] = AllWaypoints[52];
        #endregion
        #endregion

        #region Spawner4
        #region Path23
        Path23[0] = AllWaypoints[38];
        Path23[1] = AllWaypoints[31];
        Path23[2] = AllWaypoints[33];
        Path23[3] = AllWaypoints[25];
        Path23[4] = AllWaypoints[26];
        Path23[5] = AllWaypoints[35];
        Path23[6] = AllWaypoints[36];
        Path23[7] = AllWaypoints[28];
        Path23[8] = AllWaypoints[29];
        Path23[9] = AllWaypoints[20];
        Path23[10] = AllWaypoints[52];
        #endregion
        #region Path24
        Path24[0] = AllWaypoints[38];
        Path24[1] = AllWaypoints[31];
        Path24[2] = AllWaypoints[33];
        Path24[3] = AllWaypoints[25];
        Path24[4] = AllWaypoints[26];
        Path24[5] = AllWaypoints[35];
        Path24[6] = AllWaypoints[37];
        Path24[7] = AllWaypoints[44];
        Path24[8] = AllWaypoints[30];
        Path24[9] = AllWaypoints[22];
        Path24[10] = AllWaypoints[52];
        #endregion
        #region Path25
        Path25[0] = AllWaypoints[38];
        Path25[1] = AllWaypoints[31];
        Path25[2] = AllWaypoints[32];
        Path25[3] = AllWaypoints[40];
        Path25[3] = AllWaypoints[41];
        Path25[4] = AllWaypoints[34];
        Path25[5] = AllWaypoints[36];
        Path25[6] = AllWaypoints[28];
        Path25[7] = AllWaypoints[29];
        Path25[8] = AllWaypoints[20];
        Path25[9] = AllWaypoints[52];
        #endregion
        #region Path26
        Path26[0] = AllWaypoints[38];
        Path26[1] = AllWaypoints[31];
        Path26[2] = AllWaypoints[32];
        Path26[3] = AllWaypoints[40];
        Path26[4] = AllWaypoints[43];
        Path26[5] = AllWaypoints[28];
        Path26[6] = AllWaypoints[29];
        Path26[7] = AllWaypoints[20];
        Path26[8] = AllWaypoints[52];
        #endregion
        #region Path27
        Path27[0] = AllWaypoints[38];
        Path27[1] = AllWaypoints[31];
        Path27[2] = AllWaypoints[32];
        Path27[3] = AllWaypoints[40];
        Path27[4] = AllWaypoints[41];
        Path27[5] = AllWaypoints[34];
        Path27[6] = AllWaypoints[37];
        Path27[7] = AllWaypoints[44];
        Path27[8] = AllWaypoints[30];
        Path27[9] = AllWaypoints[22];
        Path27[10] = AllWaypoints[52];
        #endregion
        #region Path28
        Path28[0] = AllWaypoints[38];
        Path28[1] = AllWaypoints[31];
        Path28[2] = AllWaypoints[32];
        Path28[3] = AllWaypoints[40];
        Path28[4] = AllWaypoints[43];
        Path28[5] = AllWaypoints[36];
        Path28[6] = AllWaypoints[37];
        Path28[7] = AllWaypoints[44];
        Path28[8] = AllWaypoints[30];
        Path28[9] = AllWaypoints[22];
        Path28[10] = AllWaypoints[52];
        #endregion
        #region Path29
        Path29[0] = AllWaypoints[38];
        Path29[1] = AllWaypoints[31];
        Path29[2] = AllWaypoints[32];
        Path29[3] = AllWaypoints[40];
        Path29[4] = AllWaypoints[42];
        Path29[5] = AllWaypoints[49];
        Path29[6] = AllWaypoints[50];
        Path29[7] = AllWaypoints[30];
        Path29[8] = AllWaypoints[22];
        Path29[9] = AllWaypoints[52];
        #endregion
        #region Path30
        Path30[0] = AllWaypoints[38];
        Path30[1] = AllWaypoints[45];
        Path30[2] = AllWaypoints[46];
        Path30[3] = AllWaypoints[39];
        Path30[4] = AllWaypoints[41];
        Path30[5] = AllWaypoints[34];
        Path30[6] = AllWaypoints[36];
        Path30[7] = AllWaypoints[28];
        Path30[8] = AllWaypoints[29];
        Path30[9] = AllWaypoints[20];
        Path30[10] = AllWaypoints[52];
        #endregion
        #region Path31
        Path31[0] = AllWaypoints[38];
        Path31[1] = AllWaypoints[45];
        Path31[2] = AllWaypoints[46];
        Path31[3] = AllWaypoints[39];
        Path31[4] = AllWaypoints[43];
        Path31[5] = AllWaypoints[28];
        Path31[6] = AllWaypoints[29];
        Path31[7] = AllWaypoints[20];
        Path31[8] = AllWaypoints[52];
        #endregion
        #region Path32
        Path32[0] = AllWaypoints[38];
        Path32[1] = AllWaypoints[45];
        Path32[2] = AllWaypoints[46];
        Path32[3] = AllWaypoints[39];
        Path32[4] = AllWaypoints[41];
        Path32[5] = AllWaypoints[34];
        Path32[6] = AllWaypoints[37];
        Path32[7] = AllWaypoints[44];
        Path32[8] = AllWaypoints[30];
        Path32[9] = AllWaypoints[22];
        Path32[10] = AllWaypoints[52];
        #endregion
        #region Path33
        Path33[0] = AllWaypoints[38];
        Path33[1] = AllWaypoints[45];
        Path33[2] = AllWaypoints[46];
        Path33[3] = AllWaypoints[39];
        Path33[4] = AllWaypoints[43];
        Path33[5] = AllWaypoints[36];
        Path33[6] = AllWaypoints[37];
        Path33[7] = AllWaypoints[44];
        Path33[8] = AllWaypoints[30];
        Path33[9] = AllWaypoints[22];
        Path33[10] = AllWaypoints[52];
        #endregion
        #region Path34
        Path34[0] = AllWaypoints[38];
        Path34[1] = AllWaypoints[45];
        Path34[2] = AllWaypoints[46];
        Path34[3] = AllWaypoints[39];
        Path34[4] = AllWaypoints[42];
        Path34[5] = AllWaypoints[49];
        Path34[6] = AllWaypoints[50];
        Path34[7] = AllWaypoints[30];
        Path34[8] = AllWaypoints[22];
        Path34[9] = AllWaypoints[52];
        #endregion
        #region Path35
        Path35[0] = AllWaypoints[38];
        Path35[1] = AllWaypoints[45];
        Path35[2] = AllWaypoints[47];
        Path35[3] = AllWaypoints[48];
        Path35[4] = AllWaypoints[49];
        Path35[5] = AllWaypoints[42];
        Path35[6] = AllWaypoints[43];
        Path35[7] = AllWaypoints[36];
        Path35[8] = AllWaypoints[28];
        Path35[9] = AllWaypoints[29];
        Path35[10] = AllWaypoints[20];
        Path35[11] = AllWaypoints[52];
        #endregion
        #region Path36
        Path36[0] = AllWaypoints[38];
        Path36[1] = AllWaypoints[45];
        Path36[2] = AllWaypoints[47];
        Path36[3] = AllWaypoints[48];
        Path36[4] = AllWaypoints[49];
        Path36[5] = AllWaypoints[42];
        Path36[6] = AllWaypoints[43];
        Path36[7] = AllWaypoints[36];
        Path36[8] = AllWaypoints[37];
        Path36[9] = AllWaypoints[44];
        Path36[10] = AllWaypoints[30];
        Path36[11] = AllWaypoints[22];
        Path36[12] = AllWaypoints[52];
        #endregion
        #region Path37
        Path37[0] = AllWaypoints[38];
        Path37[1] = AllWaypoints[45];
        Path37[2] = AllWaypoints[47];
        Path37[3] = AllWaypoints[48];
        Path37[4] = AllWaypoints[50];
        Path37[5] = AllWaypoints[30];
        Path37[6] = AllWaypoints[22];
        Path37[7] = AllWaypoints[52];
        #endregion
        #endregion

        #region Spawner5
        #region Path38
        Path38[0] = AllWaypoints[51];
        Path38[1] = AllWaypoints[48];
        Path38[2] = AllWaypoints[49];
        Path38[3] = AllWaypoints[42];
        Path38[4] = AllWaypoints[43];
        Path38[5] = AllWaypoints[36];
        Path38[6] = AllWaypoints[28];
        Path38[7] = AllWaypoints[29];
        Path38[8] = AllWaypoints[20];
        Path38[9] = AllWaypoints[52];
        #endregion
        #region Path39
        Path39[0] = AllWaypoints[51];
        Path39[1] = AllWaypoints[48];
        Path39[2] = AllWaypoints[49];
        Path39[3] = AllWaypoints[42];
        Path39[4] = AllWaypoints[43];
        Path39[5] = AllWaypoints[36];
        Path39[6] = AllWaypoints[37];
        Path39[7] = AllWaypoints[44];
        Path39[8] = AllWaypoints[30];
        Path39[9] = AllWaypoints[22];
        Path39[10] = AllWaypoints[52];
        #endregion
        #region Path40
        Path40[0] = AllWaypoints[51];
        Path40[1] = AllWaypoints[48];
        Path40[2] = AllWaypoints[50];
        Path40[3] = AllWaypoints[30];
        Path40[4] = AllWaypoints[22];
        Path40[5] = AllWaypoints[52];
        #endregion
        #endregion
    }
}
