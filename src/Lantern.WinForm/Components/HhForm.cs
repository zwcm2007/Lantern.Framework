using Lantern.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// Form派生类
    /// </summary>
    public class HhForm : Form, IMessageFilter
    {
        private HotKeyManager _hotKeyMng = new HotKeyManager();
        private List<HotKeyEntity> _formHotKeys;

        #region 属性

        /// <summary>
        /// 热键是否启用
        /// </summary>
        public bool HotKeyEnabled { get; set; }

        /// <summary>
        /// 热键是否已注册
        /// </summary>
        public bool IsHotKeyRegisted
        {
            get { return _hotKeyMng.Count > 0; }
        }

        #endregion 属性

        #region 窗体热键

        /// <summary>
        /// 注册窗体所有热键
        /// </summary>
        private void RegisterFormHotKeys()
        {
            FormHotKeys.ForEach(k =>
            {
                _hotKeyMng.Regist(this, k);
            });
        }

        /// <summary>
        /// 窗体热键集合
        /// </summary>
        protected virtual List<HotKeyEntity> FormHotKeys
        {
            get
            {
                if (_formHotKeys == null)
                {
                    _formHotKeys = _hotKeyMng.GetHotKeysByForm();
                }
                return _formHotKeys;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            // 窗体激活时注册
            if (HotKeyEnabled && !IsHotKeyRegisted)
            {
                RegisterFormHotKeys();
            }
            //
            base.OnActivated(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            // 窗体最小化时注销
            if (HotKeyEnabled && WindowState == FormWindowState.Minimized)
            {
                _hotKeyMng.Unregist(this);  // 注销窗体热键
                _formHotKeys = null;
            }
            //
            base.OnSizeChanged(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            // 窗体关闭时注销
            if (HotKeyEnabled && IsHotKeyRegisted)
            {
                _hotKeyMng.Unregist(this);    // 注销窗体热键
            }
            //
            base.OnClosed(e);
        }

        /// <summary>
        /// 刷新热键
        /// </summary>
        public void RefreshHotKeys()
        {
            if (HotKeyEnabled)
            {
                if (IsHotKeyRegisted)
                {
                    _hotKeyMng.Unregist(this);   // 注销窗体热键
                    _formHotKeys = null;
                }
                RegisterFormHotKeys();
            }
        }

        #endregion 窗体热键

        protected override void OnLoad(EventArgs e)
        {
            InitializeOnLoad();
            //
            base.OnLoad(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            FinalizeOnClosed();
        }

        protected virtual void InitializeOnLoad()
        {
        }

        protected virtual void FinalizeOnClosed()
        {
        }

        protected override void WndProc(ref Message m)
        {
            _hotKeyMng.ProcessHotKey(m);
            //
            base.WndProc(ref m);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg >= 513 && m.Msg <= 515)
            {
                //不响应鼠标左键消息
                return true;
            }
            else if (m.Msg >= 256 && m.Msg <= 258)
            {
                //不响应键盘消息
                return true;
            }
            else if (m.Msg == HotKeyManager.WM_HOTKEY)
            {
                //不响应热键消息
                return true;
            }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.SendWait("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}