using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    [CollectionDataContract(Name = "GroupDTOList", ItemName = "GroupDTO", Namespace="http://www.wings.com")]
    public class GroupDTOList : List<GroupDTO>
    {
        /// <summary>
        /// 转换为友好显示树形结构
        /// </summary>
        /// <param name="groupdtolist"></param>
        /// <returns></returns>
        public  List<Tree> ToTree(GroupDTOList groupdtolist=null)
        {
            List<Tree> trees = new List<Tree>();

            if (groupdtolist == null)
            {
                groupdtolist = this;
            }
            if (groupdtolist.Count == 0)
            {
                return null;
            }

            groupdtolist.ForEach(g =>
                {
                    Tree tree = new Tree();
                    tree.id = g.ID.ToString();
                    tree.text = g.Name;
                    if (g.ChildGroup != null && g.ChildGroup.Count > 0)
                    {
                        tree.children = ToTree((GroupDTOList)g.ChildGroup);
                    }
                    trees.Add(tree);
                });
            return trees;
        }
        
    }
    [DataContract]
    [Serializable]
    public class GroupDTO : BaseDTO, IExtensibleDataObject
    {
        public GroupDTO()
        {
            //ChildGroup = new List<GroupDTO>();
            //Users = new List<UserDTO>();
        }
        [DataMember]
        /// <summary>
        /// 分组名字
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 父组
        /// </summary>
        public virtual GroupDTO ParentGroup { get; set; }
        [DataMember]
        /// <summary>
        /// 父节点ID
        /// </summary>
        public virtual Guid ParentID
        {
            get
            {
                if (ParentGroup != null)
                {
                    Guid temp = Guid.Empty;
                    if (Guid.TryParse(ParentGroup.ID, out temp))
                    {
                        return temp;
                    }
                }
                return Guid.Empty;
            }
            set
            {
                Guid temp = Guid.Empty;
                if (Guid.TryParse(value.ToString(), out temp))
                {
                    ParentGroup = new GroupDTO();
                    ParentGroup.ID = value.ToString();
                }
            }
        }
        [DataMember]
        /// <summary>
        /// 父节点名字
        /// </summary>
        public virtual string ParentName
        {

            get
            {
                if (ParentGroup != null)
                {
                    return ParentGroup.Name;
                }
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ParentGroup = new GroupDTO();
                    ParentGroup.Name = value.ToString();
                }
            }
        }
        [DataMember]
        /// <summary>
        /// 子分组
        /// </summary>
        public virtual List<GroupDTO> ChildGroup { get; set; }
        /// <summary>
        /// 该分组下的用户
        /// </summary>
        [DataMember]
        public virtual List<UserDTO> Users { get; set; }
        /// <summary>
        /// 该用户组拥有的模块
        /// </summary>
        [DataMember]
        public virtual List<ModuleDTO> Modules { get; set; }

        public ExtensionDataObject ExtensionData

        { get; set; }

    }
}
