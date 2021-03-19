using Lantern.WinForm.Components;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lantern.WinForm.Common
{
    /// <summary>
    /// �ȼ�������
    /// </summary>
    public sealed class HotKeyManager
    {
        public const int WM_HOTKEY = 0x0312;

        private static readonly List<HhForm> _registedForms = new List<HhForm>(); //ע��Ĵ���
        private Dictionary<int, HotKeyEntity> _keyMap = new Dictionary<int, HotKeyEntity>();
        private HotKeyDao _dao = new HotKeyDao();

        /// <summary>
        /// ע������
        /// </summary>
        public int Count
        {
            get { return _keyMap.Count; }
        }

        /// <summary>
        /// ע���ȼ�
        /// </summary>
        /// <param name="form"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Regist(HhForm form, HotKeyEntity entity)
        {
            bool ret = entity.Regist(form.Handle);
            if (ret)
            {
                if (!_registedForms.Contains(form))
                {
                    _registedForms.Add(form);
                }
                _keyMap[entity.Id] = entity;
            }
            return ret;
        }

        /// <summary>
        /// ע���ȼ�
        /// </summary>
        public void Unregist(HhForm form)
        {
            foreach (KeyValuePair<int, HotKeyEntity> pair in _keyMap)
            {
                bool ret = pair.Value.Unregist(form.Handle);
                if (!ret)
                {
                    MessageBox.Show("ע���ȼ�ʧ��");
                }
            }
            _registedForms.Remove(form);
            _keyMap.Clear();
        }

        /// <summary>
        /// ��ݼ���Ϣ����
        /// </summary>
        /// <param name="m"></param>
        internal void ProcessHotKey(Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                //
                HotKeyEntity hotKey;
                if (_keyMap.TryGetValue(id, out hotKey))
                {
                    hotKey.CallBack?.Invoke();
                }
            }
        }

        /// <summary>
        /// �����Զ����ȼ�
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveCustomHotKey(HotKeyEntity entity)
        {
            bool ret = _dao.Update(entity);
            if (ret)
            {
                HhForm[] forms = _registedForms.ToArray();
                foreach (var item in forms)
                {
                    item.RefreshHotKeys();
                }
            }
            return ret;
        }

        /// <summary>
        /// ��ȡ�Զ����ȼ�
        /// </summary>
        /// <returns></returns>
        public List<HotKeyEntity> GetCustomHotKeys()
        {
            return _dao.GetAll().ToList();
        }

        /// <summary>
        /// ��ȡ�����ȼ�
        /// </summary>
        public List<HotKeyEntity> GetHotKeysByForm()
        {
            return _dao.GetAll().ToList();
        }

        /// <summary>
        /// �ȼ��Ƿ���ʹ��
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsHotKeyExist(HotKeyEntity entity)
        {
            return _dao.IsExist(entity);
        }

        /// <summary>
        /// ��ȡָ��Id�ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotKeyEntity GetHotKeyEntityById(int id)
        {
            return _dao.GetEntityById(id);
        }

        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ClearHotKey(int id)
        {
            var entity = new HotKeyEntity(id) { KeyVal = Keys.None, Modifier = KeyModifiers.None };
            return _dao.Update(entity);
        }
    }
}