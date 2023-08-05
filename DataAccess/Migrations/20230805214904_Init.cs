using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "CreatedDate", "UpdatedDate" },
                values: new object[] { 1, "Math", new DateTime(2023, 8, 6, 0, 49, 3, 695, DateTimeKind.Local).AddTicks(9692), null });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DepartmentName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 8, 6, 0, 49, 3, 695, DateTimeKind.Local).AddTicks(9937), "Computer Science", null });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Standart" }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(604), 1, null, 1 },
                    { 2, new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(606), 2, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "PasswordHash", "PasswordSalt", "Status", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(1537), "admin@gmail.com", "admin", new byte[] { 68, 122, 103, 142, 198, 219, 212, 15, 255, 21, 38, 46, 51, 14, 253, 101, 216, 216, 237, 16, 55, 200, 142, 8, 250, 106, 198, 206, 206, 88, 99, 52, 96, 143, 111, 209, 65, 112, 168, 168, 118, 45, 96, 145, 177, 103, 238, 139, 50, 218, 39, 26, 139, 237, 226, 82, 25, 216, 181, 66, 58, 73, 236, 244 }, new byte[] { 14, 99, 241, 233, 203, 123, 53, 109, 25, 109, 98, 88, 141, 37, 11, 200, 238, 25, 66, 76, 254, 131, 107, 142, 162, 163, 119, 75, 103, 110, 88, 75, 57, 9, 53, 254, 188, 75, 243, 2, 16, 164, 34, 112, 202, 104, 131, 208, 180, 250, 239, 15, 148, 42, 188, 55, 215, 7, 3, 200, 246, 62, 81, 103, 45, 229, 73, 137, 217, 156, 100, 69, 43, 199, 203, 230, 181, 122, 78, 143, 128, 160, 17, 96, 147, 175, 22, 168, 243, 26, 65, 17, 253, 6, 24, 67, 214, 100, 210, 229, 63, 37, 212, 59, 243, 184, 228, 168, 227, 97, 93, 124, 73, 222, 84, 29, 20, 60, 43, 76, 205, 1, 235, 228, 142, 172, 146, 62 }, true, null, "admin" },
                    { 2, new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(1555), "standart@gmail.com", "standart", new byte[] { 68, 122, 103, 142, 198, 219, 212, 15, 255, 21, 38, 46, 51, 14, 253, 101, 216, 216, 237, 16, 55, 200, 142, 8, 250, 106, 198, 206, 206, 88, 99, 52, 96, 143, 111, 209, 65, 112, 168, 168, 118, 45, 96, 145, 177, 103, 238, 139, 50, 218, 39, 26, 139, 237, 226, 82, 25, 216, 181, 66, 58, 73, 236, 244 }, new byte[] { 14, 99, 241, 233, 203, 123, 53, 109, 25, 109, 98, 88, 141, 37, 11, 200, 238, 25, 66, 76, 254, 131, 107, 142, 162, 163, 119, 75, 103, 110, 88, 75, 57, 9, 53, 254, 188, 75, 243, 2, 16, 164, 34, 112, 202, 104, 131, 208, 180, 250, 239, 15, 148, 42, 188, 55, 215, 7, 3, 200, 246, 62, 81, 103, 45, 229, 73, 137, 217, 156, 100, 69, 43, 199, 203, 230, 181, 122, 78, 143, 128, 160, 17, 96, 147, 175, 22, 168, 243, 26, 65, 17, 253, 6, 24, 67, 214, 100, 210, 229, 63, 37, 212, 59, 243, 184, 228, 168, 227, 97, 93, 124, 73, 222, 84, 29, 20, 60, 43, 76, 205, 1, 235, 228, 142, 172, 146, 62 }, true, null, "standart" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "DepartmentId", "Name", "UpdatedDate" },
                values: new object[] { 1, 24, new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(413), 1, "Oğuzhan", null });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
