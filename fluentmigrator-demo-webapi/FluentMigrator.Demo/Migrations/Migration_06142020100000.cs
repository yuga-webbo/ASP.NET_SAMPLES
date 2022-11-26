namespace FluentMigrator.Demo.Migrations
{
    [Migration(06142020100000)]
    public class Migration_06142020100000 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Employee").Row(new { Name = "First Employee", Age = 25 });
        }

        public override void Up()
        {
            Insert.IntoTable("Employee").Row(new { Name = "First Employee", Age = 25 });
        }
    }
}