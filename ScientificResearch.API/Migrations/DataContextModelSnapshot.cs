﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScientificResearch.API.Data;

#nullable disable

namespace ScientificResearch.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScientificResearch.Shared.Entities.Investigator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("membership")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("specialty")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Investigators");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.Publication", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ResearcherParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Investigators")
                        .HasColumnType("int");

                    b.Property<int>("Id_ScientificInvestigations")
                        .HasColumnType("int");

                    b.Property<int?>("InvestigatorsId")
                        .HasColumnType("int");

                    b.Property<int?>("ScientificInvestigationsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvestigatorsId");

                    b.HasIndex("ScientificInvestigationsId");

                    b.ToTable("ResearcherParticipations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ResourceAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_ScientificInvestigations")
                        .HasColumnType("int");

                    b.Property<int>("Id_searchActivities")
                        .HasColumnType("int");

                    b.Property<int>("Id_specializedResources")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ScientificInvestigationsId")
                        .HasColumnType("int");

                    b.Property<int?>("searchActivitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("specializedResourcesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScientificInvestigationsId");

                    b.HasIndex("searchActivitiesId");

                    b.HasIndex("specializedResourcesId");

                    b.ToTable("ResourceAllocations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ScientificInvestigation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ScientificInvestigations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.searchActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("searchActivities");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.specializedResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("deliveyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("supplier")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("specializedResources");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ResearcherParticipation", b =>
                {
                    b.HasOne("ScientificResearch.Shared.Entities.Investigator", "Investigators")
                        .WithMany("ResearcherParticipations")
                        .HasForeignKey("InvestigatorsId");

                    b.HasOne("ScientificResearch.Shared.Entities.ScientificInvestigation", "ScientificInvestigations")
                        .WithMany("ResearcherParticipations")
                        .HasForeignKey("ScientificInvestigationsId");

                    b.Navigation("Investigators");

                    b.Navigation("ScientificInvestigations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ResourceAllocation", b =>
                {
                    b.HasOne("ScientificResearch.Shared.Entities.ScientificInvestigation", "ScientificInvestigations")
                        .WithMany()
                        .HasForeignKey("ScientificInvestigationsId");

                    b.HasOne("ScientificResearch.Shared.Entities.searchActivity", "searchActivities")
                        .WithMany("ResourceAllocations")
                        .HasForeignKey("searchActivitiesId");

                    b.HasOne("ScientificResearch.Shared.Entities.specializedResource", "specializedResources")
                        .WithMany("ResourceAllocations")
                        .HasForeignKey("specializedResourcesId");

                    b.Navigation("ScientificInvestigations");

                    b.Navigation("searchActivities");

                    b.Navigation("specializedResources");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.Investigator", b =>
                {
                    b.Navigation("ResearcherParticipations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.ScientificInvestigation", b =>
                {
                    b.Navigation("ResearcherParticipations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.searchActivity", b =>
                {
                    b.Navigation("ResourceAllocations");
                });

            modelBuilder.Entity("ScientificResearch.Shared.Entities.specializedResource", b =>
                {
                    b.Navigation("ResourceAllocations");
                });
#pragma warning restore 612, 618
        }
    }
}
