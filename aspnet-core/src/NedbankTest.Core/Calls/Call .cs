using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using NedbankTest.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NedbankTest.Calls
{
    [Table("AppCalls")]
    public class Call : FullAuditedEntity<int>, IMustHaveTenant
    {
        public Call()
        {

        }
        public const int MaxCodeLength = 10;
        public const int MaxDescriptionLength = 20;

        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; protected set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; protected set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; protected set; }
        public virtual long UserId { get; set; }


        public static Call Create(int tenantId, string code, User user, string description = null)
        {
            var @call = new Call
            {
                TenantId = tenantId,
                Code = code,
                Description = description,
                UserId = @user.Id,
                IsDeleted =false,
                //User = user
            };
            return @call;
        }
    }
}
