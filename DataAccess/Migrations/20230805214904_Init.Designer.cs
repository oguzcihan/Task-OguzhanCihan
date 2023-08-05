﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230805214904_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "Math",
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 695, DateTimeKind.Local).AddTicks(9692)
                        });
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 695, DateTimeKind.Local).AddTicks(9937),
                            DepartmentName = "Computer Science"
                        });
                });

            modelBuilder.Entity("Core.Entities.Identity.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Standart"
                        });
                });

            modelBuilder.Entity("Core.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(1537),
                            Email = "admin@gmail.com",
                            FirstName = "admin",
                            PasswordHash = new byte[] { 68, 122, 103, 142, 198, 219, 212, 15, 255, 21, 38, 46, 51, 14, 253, 101, 216, 216, 237, 16, 55, 200, 142, 8, 250, 106, 198, 206, 206, 88, 99, 52, 96, 143, 111, 209, 65, 112, 168, 168, 118, 45, 96, 145, 177, 103, 238, 139, 50, 218, 39, 26, 139, 237, 226, 82, 25, 216, 181, 66, 58, 73, 236, 244 },
                            PasswordSalt = new byte[] { 14, 99, 241, 233, 203, 123, 53, 109, 25, 109, 98, 88, 141, 37, 11, 200, 238, 25, 66, 76, 254, 131, 107, 142, 162, 163, 119, 75, 103, 110, 88, 75, 57, 9, 53, 254, 188, 75, 243, 2, 16, 164, 34, 112, 202, 104, 131, 208, 180, 250, 239, 15, 148, 42, 188, 55, 215, 7, 3, 200, 246, 62, 81, 103, 45, 229, 73, 137, 217, 156, 100, 69, 43, 199, 203, 230, 181, 122, 78, 143, 128, 160, 17, 96, 147, 175, 22, 168, 243, 26, 65, 17, 253, 6, 24, 67, 214, 100, 210, 229, 63, 37, 212, 59, 243, 184, 228, 168, 227, 97, 93, 124, 73, 222, 84, 29, 20, 60, 43, 76, 205, 1, 235, 228, 142, 172, 146, 62 },
                            Status = true,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(1555),
                            Email = "standart@gmail.com",
                            FirstName = "standart",
                            PasswordHash = new byte[] { 68, 122, 103, 142, 198, 219, 212, 15, 255, 21, 38, 46, 51, 14, 253, 101, 216, 216, 237, 16, 55, 200, 142, 8, 250, 106, 198, 206, 206, 88, 99, 52, 96, 143, 111, 209, 65, 112, 168, 168, 118, 45, 96, 145, 177, 103, 238, 139, 50, 218, 39, 26, 139, 237, 226, 82, 25, 216, 181, 66, 58, 73, 236, 244 },
                            PasswordSalt = new byte[] { 14, 99, 241, 233, 203, 123, 53, 109, 25, 109, 98, 88, 141, 37, 11, 200, 238, 25, 66, 76, 254, 131, 107, 142, 162, 163, 119, 75, 103, 110, 88, 75, 57, 9, 53, 254, 188, 75, 243, 2, 16, 164, 34, 112, 202, 104, 131, 208, 180, 250, 239, 15, 148, 42, 188, 55, 215, 7, 3, 200, 246, 62, 81, 103, 45, 229, 73, 137, 217, 156, 100, 69, 43, 199, 203, 230, 181, 122, 78, 143, 128, 160, 17, 96, 147, 175, 22, 168, 243, 26, 65, 17, 253, 6, 24, 67, 214, 100, 210, 229, 63, 37, 212, 59, 243, 184, 228, 168, 227, 97, 93, 124, 73, 222, 84, 29, 20, 60, 43, 76, 205, 1, 235, 228, 142, 172, 146, 62 },
                            Status = true,
                            Username = "standart"
                        });
                });

            modelBuilder.Entity("Core.Entities.Identity.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(604),
                            OperationClaimId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(606),
                            OperationClaimId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Core.Entities.Relationships.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 1
                        });
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 24,
                            CreatedDate = new DateTime(2023, 8, 6, 0, 49, 3, 696, DateTimeKind.Local).AddTicks(413),
                            DepartmentId = 1,
                            Name = "Oğuzhan"
                        });
                });

            modelBuilder.Entity("Core.Entities.Relationships.StudentCourse", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.HasOne("Core.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
