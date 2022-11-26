using FluentMigrator.SqlServer;

namespace FluentMigrator.Demo.Migrations
{
    [Migration(06072020100000)]
    public class Migration_06072020100000 : Migration
    {
        public override void Down()
        {
            Delete.Table("Employee");
        }

        public override void Up()
        {
            Create.Table("Employee")
                .WithColumn("Id").AsInt32().NotNullable().Identity(1, 1).PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Age").AsInt32().Nullable();
        }
    }
}