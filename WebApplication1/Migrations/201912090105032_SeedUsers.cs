namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"


INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd47745b9-8299-4d2c-b5a3-29b36fc7e5f8', N'admin@vidiling.com', 0, N'ACzKi54JxWt/HTTQtotgEkqOjy0Ofz4uQPzM8GPMYxeBw2O4XpySsSV2/8bfwEFWug==', N'816281b3-aa97-491a-b235-f1eabf3abdac', NULL, 0, 0, NULL, 1, 0, N'admin@vidiling.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f9886c72-3e49-46fb-8c5f-83630c324fa0', N'guest@vidiling.com', 0, N'ABEAR+kudIfgf0sL7LOXc3rbKmPeIkLrqThGgotTaZLw7LfnWVjMKVMcCriMwxwwCA==', N'b867c7c3-bc0b-4e28-a50f-b098bddbb5a3', NULL, 0, 0, NULL, 1, 0, N'guest@vidiling.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a2f04504-76fd-4f56-a68d-7e1754464848', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd47745b9-8299-4d2c-b5a3-29b36fc7e5f8', N'a2f04504-76fd-4f56-a68d-7e1754464848')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
