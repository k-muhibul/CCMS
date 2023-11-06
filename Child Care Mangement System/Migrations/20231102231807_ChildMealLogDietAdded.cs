using Microsoft.EntityFrameworkCore.Migrations;

namespace Child_Care_Mangement_System.Migrations
{
    public partial class ChildMealLogDietAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "ChildMealLogs",
                newName: "DietId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "11bf815d-722b-4bc8-b28e-3b8f04a589a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c5632553-c743-4943-84b6-a6cf5ae69019");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ccf1a20a-af9e-4e6b-a185-8ada35e5e3c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "812c126f-f02f-49d6-bd56-fb380bb05f3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90b14719-76e2-4d9b-84d4-40b342ab571d", "AQAAAAEAACcQAAAAEDLV4N3gCYNDZX0m9mnlDb2tVLi9B6jhusqxSqkay2U2GQUjnfqSDHxLGDDEK2+KzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26af227c-474d-4b8f-87cb-8b1bb425f4b1", "AQAAAAEAACcQAAAAEM22V0fRBx4oEMkAyucwYPxxbrEvJAjJOoIl99XD+ibxa1eK9ONXYjRymc67YJ0PRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d0680e3-c624-4d35-802b-1a195e62916b", "AQAAAAEAACcQAAAAEIWWsa80X15QNpjp3jW7IBZ/DRhTwZyhEJB4OpVDP+NbKC6y4RdgfAqSQ2rQ4X9IDw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ChildMealLogs_DietId",
                table: "ChildMealLogs",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMealLogs_Diets_DietId",
                table: "ChildMealLogs",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "DietId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildMealLogs_Diets_DietId",
                table: "ChildMealLogs");

            migrationBuilder.DropIndex(
                name: "IX_ChildMealLogs_DietId",
                table: "ChildMealLogs");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "ChildMealLogs",
                newName: "Test");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e043975d-4a06-47fc-b69a-bf2739a57693");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6b249608-937d-42d3-b74b-df94c7a6e170");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "25235f74-a963-4eba-a92d-87345548e66a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "c6deb0de-f157-4fc1-8695-61a0390c6b6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87990ec4-dce8-42bd-9de8-5f1939736508", "AQAAAAEAACcQAAAAEJRCL1x6x2ihIONVwXE57IOXTcNst3hqZSBsl6aT+XMofXTGYZsLshM0EXYrMxWItQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "08078d24-3f16-490d-81ec-09e22817cc77", "AQAAAAEAACcQAAAAECOzTnqaqpngZ1obVlcG3eonKR4lZwOgimCZhnG6nLK58HevaXuc78YN8soV/Sd5ng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4652c14-d0b6-4813-b973-cf5377cd6920", "AQAAAAEAACcQAAAAELPCD/JDODBdCbYe7nfeQUh0EoRZx3kUaVxMjr/gv9an1YJgAmGTEJTNy9DHGAW1MQ==" });
        }
    }
}
