using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// HhTreeView派生类
    /// </summary>
    public class HhMenuTreeView : HhTreeView
    {
        private HhMenuTreeNode _rootNode = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public HhMenuTreeView()
        {
            HideSelection = false;
        }

        /// <summary>
        /// 根节点显示名称
        /// </summary>
        public string RootNodeText { get; set; } = "所有菜单";

        /// <summary>
        /// 是否需要根节点
        /// </summary>
        public bool NeedRootNode { get; set; } = false;

        /// <summary>
        /// 节点来源
        /// </summary>
        public IList<HhMenuTreeNode> SourceNodes { get; set; }

        /// <summary>
        /// 新建菜单视图
        /// </summary>
        /// <returns></returns>
        public void BuildView()
        {
            // 根节点
            _rootNode = new HhMenuTreeNode(RootNodeText);
            //
            // 加载所有子菜单节点
            LoadTreeNodes(_rootNode, ""); //注意：假设根菜单Id为""
            //
            // 清空并添加根节点
            this.Nodes.Clear();

            if (NeedRootNode)
            {
                this.Nodes.Add(_rootNode);
            }
            else
            {
                for (int i = 0; i < _rootNode.Nodes.Count; i++)
                {
                    this.Nodes.Add(_rootNode.Nodes[i]);
                }
            }
        }

        /// <summary>
        /// 递归加载所有子菜单节点
        /// </summary>
        /// <param name="currentNode">当前节点</param>
        /// <param name="parentId">父菜单Id</param>
        /// <returns></returns>
        private void LoadTreeNodes(HhMenuTreeNode currentNode, string parentId)
        {
            if (SourceNodes == null) return;

            var nodes = SourceNodes.Where(n => n.ParentId == parentId).OrderBy(n => n.Sort);
            foreach (var node in nodes)
            {
                //node.BackColor = Color.MediumTurquoise;
                currentNode.Nodes.Add(node);
                LoadTreeNodes(node, node.Id);
            };
        }

        //protected override void OnAfterCheck(TreeViewEventArgs e)
        //{
        //    base.OnAfterCheck(e);
        //    //
        //    for (int i = 0; i < e.Node.Nodes.Count; i++)
        //    {
        //        e.Node.Nodes[i].Checked = e.Node.Checked;
        //    }

        //}

        /// <summary>
        /// 选中指定菜单节点
        /// </summary>
        /// <param name="menuId"></param>
        public void SetNodeSelected(string menuId)
        {
            TreeNode node = FindNode(menuId);
            if (node != null)
            {
                this.SelectedNode = node;
            }
        }

        /// <summary>
        /// 查找指定菜单节点
        /// </summary>
        /// <param name="menuId"></param>
        public HhMenuTreeNode FindNode(string menuId)
        {
            var node = FindNodeInternal(this.Nodes[0] as HhMenuTreeNode, menuId);
            return node;
        }

        /// <summary>
        /// 递归查找指定菜单节点
        /// </summary>
        /// <param name="menuId"></param>
        private HhMenuTreeNode FindNodeInternal(HhMenuTreeNode currentNode, string menuId)
        {
            foreach (HhMenuTreeNode node in currentNode.Nodes)
            {
                if (node.Id == menuId)
                {
                    return node;
                }
                var nd = FindNodeInternal(node, menuId);
                if (nd != null) return nd;
            }
            return null;
        }

        /// <summary>
        /// 获取勾选的节点
        /// </summary>
        /// <returns></returns>
        public List<HhMenuTreeNode> GetCheckedNodes()
        {
            var lstNodes = new List<HhMenuTreeNode>();

            Action<HhMenuTreeNode> action = node =>
            {
                if (node.Checked)
                {
                    lstNodes.Add(node);
                }
            };

            TravellNodes(action);

            return lstNodes;
        }

        /// <summary>
        /// 设置勾选的节点
        /// </summary>
        /// <returns></returns>
        public void SetCheckedNodes(string[] ids)
        {
            Action<HhMenuTreeNode> action = node =>
            {
                if (ids != null && ids.Contains(node.Id))
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }
            };

            TravellNodes(action);
        }

        /// <summary>
        /// 移除勾选的节点
        /// </summary>
        public void RemoveCheckedNodes()
        {
            List<HhMenuTreeNode> removeNodes = new List<HhMenuTreeNode>();

            Action<HhMenuTreeNode> action = node =>
            {
                if (node.Checked)
                {
                    removeNodes.Add(node);
                }
            };

            TravellNodes(this.Nodes[0] as HhMenuTreeNode, action);

            removeNodes.OrderByDescending(m => m.Id).ToList().ForEach(n =>
            {
                n.Remove();
            });
        }

        /// <summary>
        /// 遍历节点
        /// </summary>
        public void TravellNodes(Action<HhMenuTreeNode> action)
        {
            foreach (HhMenuTreeNode node in this.Nodes)
            {
                TravellNodes(node, action);
            }
        }

        /// <summary>
        /// 递归遍历节点
        /// </summary>
        private void TravellNodes(HhMenuTreeNode currentNode, Action<HhMenuTreeNode> action)
        {
            action?.Invoke(currentNode);

            foreach (HhMenuTreeNode node in currentNode.Nodes)
            {
                //action?.Invoke(node);
                TravellNodes(node, action);
            }
        }
    }

    /// <summary>
    /// 自定义菜单TreeNode
    /// </summary>
    public class HhMenuTreeNode : TreeNode
    {
        public HhMenuTreeNode()
        {
        }

        public HhMenuTreeNode(string text)
            : base(text)
        { }

        /// <summary>
        /// 菜单ID
        /// </summary>
        //public int Id { get; set; }
        public string Id { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        //public int ParentId { get; set; }
        public string ParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        //public int Sort { get; set; }
        public string Sort { get; set; }
    }
}