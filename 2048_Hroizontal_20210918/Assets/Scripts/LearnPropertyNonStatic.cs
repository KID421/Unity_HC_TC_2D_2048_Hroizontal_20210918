using UnityEngine;

/// <summary>
/// �ǲ߫D�R�A�ݩʡB��k
/// </summary>
public class LearnPropertyNonStatic : MonoBehaviour
{
    // �R�A�P�D�R�A�t���G
    // 1. �w�q���
    // 2. ����������P���O�ۦP
    // 3. ���n�x�s����
    public Camera cam;
    public Transform tra;

    private void Start()
    {
        // �R�A��Ӳ�
        print("��v���ƶq�G" + Camera.allCamerasCount);

        // �D�R�A�ݩ�
        // ���o�D�R�A�ݩʻy�k�G
        // ���W��.�D�R�A�ݩʦW��
        print("��v���`�סG" + cam.depth);

        // �]�w�D�R�A�ݩʻy�k�G
        // ���W��.�D�R�A�ݩʦW�� ���w �ȡF
        tra.position = new Vector3(5, 0, 0);
    }

    private void Update()
    {
        // �I�s�D�R�A��k�y�k�G
        // ���W��.�D�R�A��k�W��(�������޼�)
        tra.Translate(1, 0, 0);
    }
}
