using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExplanationUI : MonoBehaviour
{
    private string explanation;
    [SerializeField] private GameObject explanationScreen;
    [SerializeField] private Text explanationText;

    private void Start()
    {
        explanationScreen.SetActive(false);
    }

    private void OpenScreen()
    {

        explanationText.text = explanation;
        explanationScreen.SetActive(true);
    }

    public void CloseScreen()
    {
        explanationScreen.SetActive(false);
    }

    public void AllP()
    {
        explanation = "�S�ẴJ�[�h�̃p���[��[+1]�����";
        OpenScreen();
    }

    public void RP()
    {
        explanation = "���b�h�J�[�h�̃p���[��[+3]�����";
        OpenScreen();
    }

    public void GP()
    {
        explanation = "�O���[���J�[�h�̃p���[��[+3]�����";
        OpenScreen();
    }

    public void BP()
    {
        explanation = "�u���[�J�[�h�̃p���[��[+3]�����";
        OpenScreen();
    }

    public void RcomP()
    {
        explanation = "���b�h���m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+5]�����";
        OpenScreen();
    }

    public void GcomP()
    {
        explanation = "�O���[�����m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+5]�����";
        OpenScreen();
    }

    public void BcomP()
    {
        explanation = "�u���[���m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+5]�����";
        OpenScreen();
    }

    public void AddR()
    {
        explanation = "���b�h�J�[�h���ꖇ�ǉ�����";
        OpenScreen();
    }

    public void AddG()
    {
        explanation = "�O���[���J�[�h���ꖇ�ǉ�����";
        OpenScreen();
    }

    public void AddB()
    {
        explanation = "�u���[�J�[�h���ꖇ�ǉ�����";
        OpenScreen();
    }

    public void McomP()
    {
        explanation = "�}�[���^���m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+20]�����";
        OpenScreen();
    }

    public void McomMag()
    {
        explanation = "�}�[���^�������̔{����[+0.5]�����";
        OpenScreen();
    }

    public void CcomP()
    {
        explanation = "�V�A�����m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+20]�����";
        OpenScreen();
    }

    public void CcomMag()
    {
        explanation = "�V�A���������̔{����[+0.5]�����";
        OpenScreen();
    }

    public void YcomP()
    {
        explanation = "�C�G���[���m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+20]�����";
        OpenScreen();
    }

    public void YcomMag()
    {
        explanation = "�C�G���[�������̔{����[+0.5]�����";
        OpenScreen();
    }

    public void WcomP()
    {
        explanation = "�z���C�g���m��g�ݍ��킹�邱�ƂŃp���[�{�[�i�X[+50]�����";
        OpenScreen();
    }

    public void WcomMag()
    {
        explanation = "�z���C�g�������̔{����[+0.5]�����";
        OpenScreen();
    }

    public void Rwide()
    {
        explanation = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Gwide()
    {
        explanation = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Bwide()
    {
        explanation = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Rup()
    {
        explanation = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Gup()
    {
        explanation = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Bup()
    {
        explanation = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        OpenScreen();
    }

    public void Rcount()
    {
        explanation = "���b�h�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A���b�h�J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Gcount()
    {
        explanation = "�O���[���J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�O���[���J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Bcount()
    {
        explanation = "�u���[�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�u���[�J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Mcount()
    {
        explanation = "�}�[���^�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�}�[���^�J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Ccount()
    {
        explanation = "�V�A���J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�V�A���J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Ycount()
    {
        explanation = "�C�G���[�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�C�G���[�J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Wcount()
    {
        explanation = "�z���C�g�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�z���C�g�J�[�h���o�����тɁA1���J�E���g�����";
        OpenScreen();
    }

    public void Bubble()
    {
        explanation = "�����_���̃J�[�h�ɃV���{���̌��ʂ���\n�V���{�����t���ƁA10�b�Ń��C�g�͏��ł��邪\n1�b���Ƃɒl��1.3�{����Ă���";
        OpenScreen();
    }

    public void LvUpper()
    {
        explanation = "�l��EXP��[+1]������";
        OpenScreen();
    }

    public void SpeedUpper()
    {
        explanation = "���C�g�̑��x��1.2�{�ɂȂ�";
        OpenScreen();
    }

    public void SlowTimer()
    {
        explanation = "5�b�ԁA�G�̑��x��0.8�{�ɂȂ�";
        OpenScreen();
    }

    public void Flash()
    {
        explanation = "30�b���ɔ����A�G�S�̂�100�_���[�W��^����";
        OpenScreen();
    }

    public void WindowBomb()
    {
        explanation = "���C�g��20���o�����ɁA�G�S�̂���֔�΂�";
        OpenScreen();
    }
}
