using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bellhop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bellhop");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountClaims",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLogins",
                schema: "Bellhop",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AccountLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTokens",
                schema: "Bellhop",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AccountTokens_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountsRoles",
                schema: "Bellhop",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountsRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Bellhop",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaims",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Bellhop",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chanels",
                schema: "Bellhop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SysName = table.Column<string>(nullable: true),
                    MessageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chanels_Messages_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "Bellhop",
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChanelMembers",
                schema: "Bellhop",
                columns: table => new
                {
                    ChanelId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChanelMembers", x => new { x.ChanelId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_ChanelMembers_Chanels_ChanelId",
                        column: x => x.ChanelId,
                        principalSchema: "Bellhop",
                        principalTable: "Chanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChanelMembers_Accounts_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Bellhop",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountClaims_UserId",
                schema: "Bellhop",
                table: "AccountClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLogins_UserId",
                schema: "Bellhop",
                table: "AccountLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Bellhop",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Bellhop",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsRoles_RoleId",
                schema: "Bellhop",
                table: "AccountsRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChanelMembers_MemberId",
                schema: "Bellhop",
                table: "ChanelMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Chanels_MessageId",
                schema: "Bellhop",
                table: "Chanels",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorId",
                schema: "Bellhop",
                table: "Messages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Bellhop",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaims_RoleId",
                schema: "Bellhop",
                table: "RolesClaims",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountClaims",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "AccountLogins",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "AccountsRoles",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "AccountTokens",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "ChanelMembers",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "RolesClaims",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "Chanels",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "Bellhop");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Bellhop");
        }
    }
}
