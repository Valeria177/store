using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class FullTextSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction: true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON Details(Company, Title) KEY INDEX PK_Details WITH STOPLIST = SYSTEM", suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FULLTEXT INDEX ON Details", suppressTransaction: true);
            migrationBuilder.Sql("DROP FULLTEXT CATALOG StoreFullTextCatalog", suppressTransaction: true);
        }
    }
}
