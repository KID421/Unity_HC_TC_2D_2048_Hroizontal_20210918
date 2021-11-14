using UnityEngine;
using UnityEngine.Audio;            // �ޥ� ���� �R�W�Ŷ�
using UnityEngine.SceneManagement;  // �ޥ� �����޲z �R�W�Ŷ�

/// <summary>
/// �}�l�e�����޲z��
/// �}�l�C���B�]�w�B���}�C��
/// </summary>
public class MenuManager : MonoBehaviour
{
    // Unity ���s�P�{�����q
    // 1. ���}����k
    // 2. ���s�]�w�I���ƥ� On Click

    public AudioMixer mixer;

    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame()
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
    public void QuitGame()
    {
        // ���ε{��.���}()�F
        // Quit ���|�A Editor ����A�o�������� ����BPC
        Application.Quit();

        print("���}�C��~");
    }
}
