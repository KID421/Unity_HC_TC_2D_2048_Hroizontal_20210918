using UnityEngine;

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
    #endregion

    #region ��k�G���}
    /// <summary>
    /// ������k
    /// </summary>
    public void Attack()
    {
        print("�o�ʧ����A�����O���G" + attack);
    }
    #endregion
}
