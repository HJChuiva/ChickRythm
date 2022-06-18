using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text txtScore = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    ComboManager theCombo;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        theCombo = FindObjectOfType<ComboManager>();
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState)
    {
        //�޺� ����
        theCombo.IncreaseCombo();
        

        //�޺� ���ʽ� ���� ���
        //�޺� ���� 10-19 10�� 20-29 20��
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //����ġ ���
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        //���� �ݿ�
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        //�ִϸ��̼�
        myAnim.SetTrigger(animScoreUp);
    }
}
