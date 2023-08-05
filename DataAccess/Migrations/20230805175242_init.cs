using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
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
                values: new object[] { 1, "Math", new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(2089), null });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DepartmentName", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(2254), "Computer Science", null });

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
                    { 1, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(2695), 1, null, 1 },
                    { 2, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(2696), 2, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "PasswordHash", "PasswordSalt", "Status", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(3495), "admin@gmail.com", "admin", new byte[] { 145, 50, 72, 228, 99, 55, 189, 17, 222, 199, 51, 212, 179, 166, 60, 112, 161, 246, 33, 247, 130, 245, 189, 9, 173, 74, 70, 22, 11, 163, 32, 246, 90, 93, 31, 85, 229, 221, 241, 53, 63, 196, 211, 0, 117, 103, 104, 96, 217, 40, 240, 198, 110, 29, 239, 230, 145, 238, 59, 86, 223, 102, 16, 232 }, new byte[] { 28, 155, 44, 117, 98, 140, 74, 76, 182, 126, 203, 171, 72, 178, 157, 203, 132, 121, 185, 214, 216, 35, 19, 39, 252, 185, 139, 53, 201, 210, 65, 25, 77, 157, 28, 23, 76, 82, 184, 206, 224, 228, 210, 152, 192, 238, 151, 68, 194, 252, 125, 202, 130, 225, 242, 243, 131, 181, 221, 19, 205, 196, 163, 248, 89, 184, 254, 183, 11, 131, 169, 222, 224, 172, 65, 126, 19, 179, 135, 126, 41, 11, 231, 172, 89, 49, 159, 240, 150, 128, 222, 120, 218, 70, 83, 224, 214, 57, 106, 232, 108, 26, 122, 69, 8, 35, 66, 222, 90, 50, 3, 251, 68, 157, 59, 20, 86, 159, 59, 173, 109, 196, 169, 72, 181, 225, 219, 162 }, true, null, "admin" },
                    { 2, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(3505), "standart@gmail.com", "standart", new byte[] { 207, 141, 197, 159, 155, 29, 8, 10, 7, 248, 200, 132, 145, 24, 225, 144, 119, 35, 164, 97, 82, 33, 201, 38, 109, 92, 141, 173, 100, 21, 200, 99, 89, 25, 173, 164, 159, 77, 110, 152, 215, 35, 118, 166, 235, 210, 214, 138, 140, 179, 20, 96, 107, 190, 193, 55, 244, 16, 115, 172, 134, 85, 45, 44 }, new byte[] { 28, 155, 44, 117, 98, 140, 74, 76, 182, 126, 203, 171, 72, 178, 157, 203, 132, 121, 185, 214, 216, 35, 19, 39, 252, 185, 139, 53, 201, 210, 65, 25, 77, 157, 28, 23, 76, 82, 184, 206, 224, 228, 210, 152, 192, 238, 151, 68, 194, 252, 125, 202, 130, 225, 242, 243, 131, 181, 221, 19, 205, 196, 163, 248, 89, 184, 254, 183, 11, 131, 169, 222, 224, 172, 65, 126, 19, 179, 135, 126, 41, 11, 231, 172, 89, 49, 159, 240, 150, 128, 222, 120, 218, 70, 83, 224, 214, 57, 106, 232, 108, 26, 122, 69, 8, 35, 66, 222, 90, 50, 3, 251, 68, 157, 59, 20, 86, 159, 59, 173, 109, 196, 169, 72, 181, 225, 219, 162 }, true, null, "standart" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "DepartmentId", "Name", "UpdatedDate" },
                values: new object[] { 1, 24, new DateTime(2023, 8, 5, 20, 52, 42, 542, DateTimeKind.Local).AddTicks(2600), 1, "Oğuzhan", null });

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
