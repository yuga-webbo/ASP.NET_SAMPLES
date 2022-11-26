using FluentMigrator;

namespace FluentMigrationApp.Migrations
{
    [Migration(202101261626, "v2.0.0")]
    public class InitialMigration : Migration
    {
        public override void Down()
        {
            #region Foreign Keys

            Delete.ForeignKey("FK_Journey_CaptainId").OnTable("Journey");
            Delete.ForeignKey("FK_JourneyDocuments_JourneyId").OnTable("JourneyDocuments");
            Delete.ForeignKey("FK_JourneyDocuments_CaptainId").OnTable("JourneyDocuments");

            #endregion

            #region Tables

            Delete.Table("Captain");
            Delete.Table("Journey");
            Delete.Table("JourneyDocuments");

            #endregion
        }

        public override void Up()
        {
            #region Tables

            Create.Table("Captain")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("NameSurname").AsString(50).NotNullable();

            Create.Table("Journey")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("JourneyDescription").AsString(100).NotNullable()
                .WithColumn("CaptainId").AsInt32().Nullable();

            Create.Table("JourneyDocuments")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("JourneyDocumentsDescription").AsDecimal(9, 2).NotNullable()
                .WithColumn("JourneyId").AsInt32().NotNullable()
                .WithColumn("CaptainId").AsInt32().NotNullable();

            #endregion

            #region Foreign Keys
            //Captain ve journey arasinda ki iliski
            Create.ForeignKey("FK_Journey_CaptainId")
                .FromTable("Journey").ForeignColumn("CaptainId")
                .ToTable("Captain").PrimaryColumn("Id");
            //journey ve journeydocuments arasina ki iliski
            Create.ForeignKey("FK_JourneyDocuments_JourneyId")
                .FromTable("JourneyDocuments").ForeignColumn("JourneyId")
                .ToTable("Journey").PrimaryColumn("Id");
            //captain ve journeyDocuments arasinda ki iliski
            Create.ForeignKey("FK_JourneyDocuments_CaptainId")
                .FromTable("JourneyDocuments").ForeignColumn("CaptainId")
                .ToTable("Captain").PrimaryColumn("Id");

            #endregion

            #region Initial Data

            //Insert.IntoTable("Captain")
            //    .Row(new { Id = 1, Username = "Edward Teach" })
            //    .Row(new { Id = 2, Username = "Francis Drake" });
            #endregion
        }
    }
}
