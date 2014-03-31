using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    public class RoleDTOList : List<RoleDTO>
    {
        public RoleDTOList ToViewModel()
        {
            RoleDTOList viewmodels = new RoleDTOList();
            if (this != null)
            {
                this.ForEach(r => 
                {
                    RoleDTO dto = new RoleDTO();
                    dto.ID = r.ID;
                    dto.Name = r.Name;
                    dto.Status = r.Status;
                    dto.Version = r.Version;
                    dto.CreateDate = r.CreateDate;
                    dto.Creator = r.Creator;
                    dto.Description = r.Description;
                    dto.EditDate = r.EditDate;
                    viewmodels.Add(dto);
                });
            }
            return viewmodels;
        }
        public List<Tree> ToTree()
        {
            List<Tree> trees = new List<Tree>();
            if (this != null)
            {
                this.ForEach(r =>
                {
                    Tree tree = new Tree();
                    tree.id = r.ID;
                    tree.text = r.Name;
                    trees.Add(tree);
                });
            }
            return trees;
        }
    }
    [DataContract]
    public class RoleDTO : BaseDTO
    {
        public RoleDTO()
        {
            Users = new List<UserDTO>();
        }
        [DataMember]
        /// <summary>
        /// 角色名
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        [DataMember]
        /// <summary>
        /// 该角色拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
    }
}
