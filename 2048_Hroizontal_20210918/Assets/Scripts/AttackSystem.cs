using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����t�ΡG��Z��
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region ���G���}
    [Header("�����O��")]
    public float attack = 10;
    [Header("�����ؼ�")]
    public GameObject goTarget;
    [Header("�����O����")]
    public Text textAttack;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        textAttack.text = "Atk " + attack;
    }
    #endregion

    #region ��k�G���}
    // virtual �����G���\�l���O�Ƽg
    /// <summary>
    /// ������k
    /// </summary>
    public virtual void Attack()
    {
        print("�o�ʧ����A�����O���G" + attack);
    }
    #endregion
}
