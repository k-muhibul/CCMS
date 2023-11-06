using Microsoft.EntityFrameworkCore.Migrations;

namespace Child_Care_Mangement_System.Migrations
{
    public partial class ChildMealLogAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildMealLog_Children_ChildId",
                table: "ChildMealLog");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildMealLog_Meals_MealId",
                table: "ChildMealLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildMealLog",
                table: "ChildMealLog");

            migrationBuilder.RenameTable(
                name: "ChildMealLog",
                newName: "ChildMealLogs");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMealLog_MealId",
                table: "ChildMealLogs",
                newName: "IX_ChildMealLogs_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMealLog_ChildId",
                table: "ChildMealLogs",
                newName: "IX_ChildMealLogs_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildMealLogs",
                table: "ChildMealLogs",
                column: "ChildMealLogId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fa46b350-cfcf-4505-b802-86bc9cfda573");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6c7862a6-c8e2-4584-9ee1-2ba71a76a745");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b56b45fd-cea7-4fe3-8e12-c1b3327d9a1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "8a4304a2-72d1-4299-ad2b-914883264289");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b89bb94-e672-4d4c-a474-6dc6b669ce51", "AQAAAAEAACcQAAAAEBy2S4d8d5fV6UgWUZwE7QxgKkJ1rMUKsup2t6vKVvYraazcUREnlz3V4g69/fMtRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c1a99d0-1932-46ef-a0c9-f9bcc9086acb", "AQAAAAEAACcQAAAAEBUmn9WNQRHXjz5T5g6sqoXixe1TN9h/L0V5LeOCLeVhJ3NCsJOzEb5QTwtHeC94Gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "edc03259-aac6-4e84-b60d-7231cea8c73e", "AQAAAAEAACcQAAAAELiwpnKnkluHa4e7ha2MWEN8kIR/1l3xxtq0zgOIKf2ougv5QtLVppEqWolWvF5EsA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMealLogs_Children_ChildId",
                table: "ChildMealLogs",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMealLogs_Meals_MealId",
                table: "ChildMealLogs",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildMealLogs_Children_ChildId",
                table: "ChildMealLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildMealLogs_Meals_MealId",
                table: "ChildMealLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildMealLogs",
                table: "ChildMealLogs");

            migrationBuilder.RenameTable(
                name: "ChildMealLogs",
                newName: "ChildMealLog");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMealLogs_MealId",
                table: "ChildMealLog",
                newName: "IX_ChildMealLog_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildMealLogs_ChildId",
                table: "ChildMealLog",
                newName: "IX_ChildMealLog_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildMealLog",
                table: "ChildMealLog",
                column: "ChildMealLogId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "03ce162a-46fa-46c3-bda8-6949ed3a8653");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1ecd3047-2621-4959-8212-acfec8d67c03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2371b9af-5784-4735-a3b5-da17c82133fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e0b383b5-e639-4af9-b340-cf45478a2f4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0869e050-bc0d-4d83-8c15-c552d906dfb9", "AQAAAAEAACcQAAAAEN0EwdUWBZpuf6ata73sDfZyMLMTob6Xsk3s+Lkwp6LMQsNYpmqj3c4EB/fEVItgXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51a9cc66-4a37-42b6-a774-d6a7e470d114", "AQAAAAEAACcQAAAAED5nWaPaxAKgFf7dT4t1z6zNrW2MR9sa6fEvMqkYNIEmIw5J/7NRPtQq8Cg6Fr/mSw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9b5deb5-71cc-4ab9-a92e-28d9bfa769c2", "AQAAAAEAACcQAAAAEJdrH1qTMbJ3BbkHE4nLmr5UlFIQRx5N18TzMCBK8iaG9c5RRmPMlrK/Fn1OhTtWcg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMealLog_Children_ChildId",
                table: "ChildMealLog",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildMealLog_Meals_MealId",
                table: "ChildMealLog",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
