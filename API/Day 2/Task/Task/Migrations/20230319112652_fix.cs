using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actorș_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actorș",
                table: "Actorș");

            migrationBuilder.RenameTable(
                name: "Actorș",
                newName: "Actors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actorș");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actorș",
                table: "Actorș",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actorș_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actorș",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
