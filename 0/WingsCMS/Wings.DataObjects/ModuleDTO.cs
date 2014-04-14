using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    public class ModuleDTOList : List<ModuleDTO>
    {
        public ModuleDTOList ToViewModel(List<ModuleDTO> modules = null)
        {
            ModuleDTOList gdtolist = new ModuleDTOList();
            if (modules == null)
            {
                modules = this;
                return ToViewModel(modules);
            }
            else
            {
                modules = modules.OrderByDescending(g => g.Index).ToList();
                modules.ForEach(g =>
                {
                    ModuleDTO dto = g.ToViewModel();
                    if (g.ChildModule != null && g.ChildModule.Count > 0)
                    {
                        dto.ChildModule = this.ToViewModel(g.ChildModule);
                    }
                    gdtolist.Add(dto);
                });
            }
            return gdtolist;
        }
        public List<Tree> ToTree(List<ModuleDTO> moduledtolist = null)
        {
            List<Tree> trees = new List<Tree>();

            if (moduledtolist == null)
            {
                moduledtolist = this;
            }
            if (moduledtolist.Count == 0)
            {
                return null;
            }
            moduledtolist.OrderByDescending(g => g.Index).ToList().ForEach(g =>
            {
                Tree tree = new Tree();
                tree.id = g.ID.ToString();
                tree.text = g.Name;
                if (g.ChildModule != null && g.ChildModule.Count > 0)
                {
                    tree.children = ToTree(g.ChildModule.ToList());
                }
                trees.Add(tree);
            });
            return trees;
        }
    }
    [DataContract]
    public class ModuleDTO : BaseDTO
    {
        public ModuleDTO()
        {
            ChildModule = new List<ModuleDTO>();

        }
        public ModuleDTO ToViewModel()
        {
            ModuleDTO dto = new ModuleDTO();
            dto.CreateDate = this.CreateDate;
            dto.Creator = this.Creator;
            dto.Description = this.Description;
            dto.EditDate = this.EditDate;
            dto.ID = this.ID.ToString();
            dto.Name = this.Name;
            dto.ParentID = this.ParentID;
            dto.ICON = this.ICON;
            dto.ParentName = this.ParentName;
            if (this.ParentModule != null)
            {
                Guid temp = Guid.Empty;
                Guid.TryParse(this.ParentModule.ID, out temp);
                dto._parentId = temp;
            }

            dto.Status = (Wings.DataObjects.Status)this.Status;
            dto.Index = this.Index;
            return dto;
        }
        [DataMember]
        public virtual Guid? ParentID
        {
            get
            {
                if (parentID == Guid.Empty)
                {
                    return null;
                }
                else
                {
                    return parentID;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    parentID = value.Value;
                }
            }
        }
        [DataMember]
        public virtual string ParentName { get; set; }
        [DataMember]
        /// <summary>
        /// 菜单名
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 详情
        /// </summary>
        public virtual string Description { get; set; }
        private Guid _actionid { get; set; }
        [DataMember]
        public Guid ActionID
        {
            get
            {
                return _actionid;
            }
            set
            {
                _actionid = value;
            }
        }
        [DataMember]
        /// <summary>
        /// 可访问点的id 
        /// </summary>
        public virtual Action Action { get; set; }
        [DataMember]
        ///// <summary>
        ///// 访问点的id
        ///// </summary>
        //public Guid ActionID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        ///
        public virtual string ICON { get; set; }
        [DataMember]
        /// <summary>
        /// 转跳链接
        /// </summary>
        public virtual string Url { get; set; }
        [DataMember]
        /// <summary>
        /// 排序索引
        /// </summary>
        public virtual int Index { get; set; }
        [DataMember]
        ///// <summary>
        ///// 父菜单标示
        ///// </summary>
        //public Guid ParentID { get; set; }
        /// <summary>
        /// 父栏目
        /// </summary>
        public virtual ModuleDTO ParentModule { get; set; }
        [DataMember]
        public Guid? _parentId
        {
            get
            {
                if(parentID!=Guid.Empty)
                {
                    return parentID;
                }
                if (ParentModule != null)
                {
                    Guid temp=Guid.Empty;
                    Guid.TryParse(ParentModule.ID, out temp);
                    return temp;
                }
                return null;
                
            }
            set
            {
                if(value.HasValue)
                {
                    parentID=value.Value;
                }
            }
        }
        [DataMember]
        private Guid parentID
        {
            get;
            set;

        }
        [DataMember]
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual List<ModuleDTO> ChildModule { get; set; }
        [DataMember]
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public virtual bool IsMenus { get; set; }
        [DataMember]
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        [DataMember]
        public string _webid { get; set; }
        [DataMember]
        public Guid WebID
        {
            get
            {
                Guid temp = Guid.Empty;
                Guid.TryParse(_webid, out temp);
                return temp;
            }
            set
            {
                _webid = value != null ? value.ToString() : string.Empty;
            }
        }
        /// <summary>
        /// 所属的站点
        /// </summary>
        public virtual WebDTO Web { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有着的分组
        /// </summary>
        public virtual List<GroupDTO> Groups { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有着的角色
        /// </summary>
        public virtual List<RoleDTO> Roles { get; set; }
        [DataMember]
        public virtual List<UserDTO> UserAllow { get; set; }
        [DataMember]
        public virtual List<UserDTO> UserBan { get; set; }

    }
}
