namespace FluentMigrator.Demo.Migrations
{
    [Migration(06142020100500)]
    public class Migration_06142020100500 : Migration
    {
        public override void Down()
        {
            Update.Table("Employee").Set(new { Name = "First Employee" })
                .Where(new { Id = 1 });
        }

        public override void Up()
        {
            Update.Table("Employee").Set(new { Name = "Second Employee" })
                .Where(new { Id = 1 });
        }
    }
}
