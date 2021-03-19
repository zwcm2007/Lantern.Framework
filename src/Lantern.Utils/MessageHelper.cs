using System.Windows.Forms;

namespace Anch.QMS.Common
{
    /// <summary>
    /// 消息对话框工具
    /// </summary>
    public static class MessageHelper
    {
        public static DialogResult ShowOKCancel(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowError(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowOK(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static DialogResult ShowYesNo(string text, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.YesNo, icon);
        }

        public static DialogResult ShowExclamation(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowInformation(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}