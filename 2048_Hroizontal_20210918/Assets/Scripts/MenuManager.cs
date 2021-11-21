using UnityEngine;
using UnityEngine.Audio;            // �ޥ� ���� �R�W�Ŷ�
using UnityEngine.SceneManagement;  // �ޥ� �����޲z �R�W�Ŷ�

/// <summary>
/// �}�l�e�����޲z��
/// �}�l�C���B�]�w�B���}�C��
/// </summary>
/// �~�����O�N�i�H�s���䦨���G���B�ݩʡB��k
public class MenuManager : MonoBehaviour
{
    // Unity ���s�P�{�����q
    // 1. ���}����k
    // 2. ���s�]�w�I���ƥ� On Click

    public AudioMixer mixer;

    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame(float delay)
    {
        // �ϥ��~�����O�������y�k�G
        // �~�����O����k
        // ��k�W��(�������޼�)
        // ���� delay ���I�s ��k
        Invoke("DelayStartGame", delay);    
    }

    private void DelayStartGame()
    {
        // �����޲z.���J����(�����W��)
        SceneManager.LoadScene("�C������");
        // SceneManager.LoadScene(1);
    }

    /// <summary>
    /// �]�w�C��
    /// </summary>
    public void SettingGameBGM(float volume)
    {
        mixer.SetFloat("���qBGM", volume);
    }

    /// <summary>
    /// �]�w�C��
    /// </summary>
    public void SettingGameSFX(float volume)
    {
        mixer.SetFloat("���qSFX", volume);
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame(float delay)
    {
        Invoke("DelayQuitGame", delay);
    }

    private void DelayQuitGame()
    {
        // ���ε{��.���}()�F
        // Quit ���|�A Editor ����A�o�������� ����BPC
        Application.Quit();

        print("���}�C��~");
    }
}
