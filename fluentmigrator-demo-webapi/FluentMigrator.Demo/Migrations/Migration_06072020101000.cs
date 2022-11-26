namespace FluentMigrator.Demo.Migrations
{
    [Migration(06072020101000)]
    public class Migration_06072020101000 : Migration
    {
        public override void Down()
        {
            Delete.Index("IX_Address_EmployeeId").OnTable("Address");
            Delete.Table("Address");
        }

        public override void Up()
        {
            Create.Table("Address")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Street").AsString().NotNullable()
                .WithColumn("City").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("Zip").AsString().Nullable()
                .WithColumn("EmployeeId").AsInt32().NotNullable().ForeignKey("Employee", "Id");

            Create.Index("IX_Address_EmployeeId")
                .OnTable("Address")
                .OnColumn("EmployeeId")
                .Ascending()
                .WithOptions().NonClustered();
        }
    }
}