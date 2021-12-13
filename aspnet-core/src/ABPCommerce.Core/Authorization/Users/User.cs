using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace ABPCommerce.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";
        public const int UrlMaxLength = 2048;
        public const int ImgMaxLength = 1024 * 1024;
        public const int OrgMaxLength = 400;
        public const int TitleMaxLength = 100;

        [MaxLength(ImgMaxLength)]
        public string ImgBase64 { get; set; }
        [MaxLength(UrlMaxLength)]
        public string Website { get; set; }
        [MaxLength(OrgMaxLength)]
        public string Organization { get; set; }
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
