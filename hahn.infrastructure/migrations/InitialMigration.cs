using FluentMigrator;

namespace hahn.infrastructure.migrations;

[Migration(1)]
public class InitialMigration : Migration {
    
    public override void Up()
    {
        Create.Table("Countries")
            .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Capital").AsString().NotNullable()
            .WithColumn("Region").AsString().NotNullable()
            .WithColumn("Subregion").AsString().NotNullable()
            .WithColumn("Flag").AsString().NotNullable()
            .WithColumn("Population").AsInt32().NotNullable()
            .WithColumn("Area").AsInt32().NotNullable()
            .WithColumn("Currency").AsString().NotNullable();
        

    }

    public override void Down()
    {
        Delete.Table("Countries");
            
    }
}