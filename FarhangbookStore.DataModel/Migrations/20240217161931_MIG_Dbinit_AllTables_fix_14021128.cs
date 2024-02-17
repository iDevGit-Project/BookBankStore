using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarhangbookStore.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class MIG_Dbinit_AllTables_fix_14021128 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLProducts_TBLProductGroupBooks_GroupBookid",
                table: "TBLProducts");

            migrationBuilder.DropIndex(
                name: "IX_TBLProducts_GroupBookid",
                table: "TBLProducts");

            migrationBuilder.DropColumn(
                name: "GroupBookid",
                table: "TBLProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupBookid",
                table: "TBLProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_GroupBookid",
                table: "TBLProducts",
                column: "GroupBookid");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLProducts_TBLProductGroupBooks_GroupBookid",
                table: "TBLProducts",
                column: "GroupBookid",
                principalTable: "TBLProductGroupBooks",
                principalColumn: "GroupBookid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
