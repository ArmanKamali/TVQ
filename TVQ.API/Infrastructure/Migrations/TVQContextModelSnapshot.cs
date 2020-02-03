﻿// <auto-generated />
using System;
using Genometric.TVQ.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Genometric.TVQ.API.Infrastructure.Migrations
{
    [DbContext(typeof(TVQContext))]
    partial class TVQContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Genometric.TVQ.API.Model.AnalysisJob", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepositoryID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RepositoryID");

                    b.ToTable("AnalysisJobs");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublicationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PublicationID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.AuthorPublication", b =>
                {
                    b.Property<int>("PublicationID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.HasKey("PublicationID", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("AuthorsPublications");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToolShedID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Citation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccumulatedCount")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublicationID")
                        .HasColumnType("int");

                    b.Property<int?>("Source")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PublicationID");

                    b.ToTable("Citations");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Keyword", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PublicationID");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.LiteratureCrawlingJob", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ScanAllPublications")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("LiteratureCrawlingJobs");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Publication", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BibTeXEntry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chapter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CitedBy")
                        .HasColumnType("int");

                    b.Property<string>("DOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Day")
                        .HasColumnType("int");

                    b.Property<string>("EID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Journal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LiteratureCrawlingJobID")
                        .HasColumnType("int");

                    b.Property<int?>("Month")
                        .HasColumnType("int");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PubMedID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScopusID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToolID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LiteratureCrawlingJobID");

                    b.HasIndex("ToolID");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.RepoCrawlingJob", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepositoryID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RepositoryID");

                    b.HasIndex("Status");

                    b.ToTable("RepoCrawlingJobs");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Repository", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Name")
                        .HasColumnType("int");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxDegreeOfParallelism")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Statistics", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("CriticalValue")
                        .HasColumnType("float");

                    b.Property<double?>("DegreeOfFreedom")
                        .HasColumnType("float");

                    b.Property<bool?>("MeansSignificantlyDifferent")
                        .HasColumnType("bit");

                    b.Property<double?>("PValue")
                        .HasColumnType("float");

                    b.Property<int>("RepositoryID")
                        .HasColumnType("int");

                    b.Property<double?>("TScore")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("RepositoryID")
                        .IsUnique();

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Tool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeRepo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homepage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolCategoryAssociation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ToolID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ToolID");

                    b.ToTable("ToolCategoryAssociation");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolDownloadRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ToolID")
                        .HasColumnType("int");

                    b.Property<int?>("ToolRepoAssociationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ToolID");

                    b.HasIndex("ToolRepoAssociationID");

                    b.ToTable("ToolDownloadRecords");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolRepoAssociation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAddedToRepository")
                        .HasColumnType("datetime2");

                    b.Property<string>("IDinRepo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepositoryID")
                        .HasColumnType("int");

                    b.Property<int?>("TimesDownloaded")
                        .HasColumnType("int");

                    b.Property<int>("ToolID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RepositoryID");

                    b.HasIndex("ToolID");

                    b.ToTable("ToolRepoAssociations");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.AnalysisJob", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Repository", "Repository")
                        .WithMany()
                        .HasForeignKey("RepositoryID");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Author", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Publication", null)
                        .WithMany("Authors")
                        .HasForeignKey("PublicationID");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.AuthorPublication", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Author", "Author")
                        .WithMany("AuthorPublications")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Genometric.TVQ.API.Model.Publication", "Publication")
                        .WithMany("AuthorPublications")
                        .HasForeignKey("PublicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Citation", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Publication", "Publication")
                        .WithMany("Citations")
                        .HasForeignKey("PublicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Keyword", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Publication", "Publication")
                        .WithMany("Keywords")
                        .HasForeignKey("PublicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Publication", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.LiteratureCrawlingJob", null)
                        .WithMany("Publications")
                        .HasForeignKey("LiteratureCrawlingJobID");

                    b.HasOne("Genometric.TVQ.API.Model.Tool", "Tool")
                        .WithMany("Publications")
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.RepoCrawlingJob", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Repository", "Repository")
                        .WithMany()
                        .HasForeignKey("RepositoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.Statistics", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Repository", "Repository")
                        .WithOne("Statistics")
                        .HasForeignKey("Genometric.TVQ.API.Model.Statistics", "RepositoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolCategoryAssociation", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Category", "Category")
                        .WithMany("ToolAssociations")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Genometric.TVQ.API.Model.Tool", "Tool")
                        .WithMany("CategoryAssociations")
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolDownloadRecord", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Genometric.TVQ.API.Model.ToolRepoAssociation", null)
                        .WithMany("Downloads")
                        .HasForeignKey("ToolRepoAssociationID");
                });

            modelBuilder.Entity("Genometric.TVQ.API.Model.ToolRepoAssociation", b =>
                {
                    b.HasOne("Genometric.TVQ.API.Model.Repository", "Repository")
                        .WithMany("ToolAssociations")
                        .HasForeignKey("RepositoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Genometric.TVQ.API.Model.Tool", "Tool")
                        .WithMany("RepoAssociations")
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
