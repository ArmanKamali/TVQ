﻿using Genometric.TVQ.API.Infrastructure.EntityConfigurations;
using Genometric.TVQ.API.Model;
using Genometric.TVQ.API.Model.Associations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Genometric.TVQ.API.Infrastructure
{
    public class TVQContext : DbContext
    {
        public TVQContext(
            DbContextOptions<TVQContext> options) : base(options)
        { }

        public DbSet<AnalysisJob> AnalysisJobs { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<AuthorPublicationAssociation> AuthorPublicationAssociations { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Citation> Citations { set; get; }
        public DbSet<Keyword> Keywords { set; get; }
        public DbSet<LiteratureCrawlingJob> LiteratureCrawlingJobs { set; get; }
        public DbSet<Publication> Publications { set; get; }
        public DbSet<PublicationKeywordAssociation> PublicationKeywordAssociations { set; get; }
        public DbSet<RepoCrawlingJob> RepoCrawlingJobs { set; get; }
        public DbSet<Repository> Repositories { set; get; }
        public DbSet<Service> Services { set; get; }
        public DbSet<Statistics> Statistics { set; get; }
        public DbSet<Tool> Tools { set; get; }
        public DbSet<ToolDownloadRecord> ToolDownloadRecords { set; get; }
        public DbSet<ToolPublicationAssociation> ToolPublicationAssociations { set; get; }
        public DbSet<ToolRepoAssociation> ToolRepoAssociation { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.ApplyConfiguration(new ToolETC());
            builder.ApplyConfiguration(new ServiceETC());

            builder.ApplyConfiguration(new BaseETC<AnalysisJob>("AnalysisJobs"));
            builder.ApplyConfiguration(new BaseETC<Author>("Authors"));
            builder.ApplyConfiguration(new BaseETC<AuthorPublicationAssociation>("AuthorsPublicationAssociations"));
            builder.ApplyConfiguration(new BaseETC<Category>("Categories"));
            builder.ApplyConfiguration(new BaseETC<Citation>("Citations"));
            builder.ApplyConfiguration(new BaseETC<Keyword>("Keywords"));
            builder.ApplyConfiguration(new BaseETC<LiteratureCrawlingJob>("LiteratureCrawlingJobs"));
            builder.ApplyConfiguration(new BaseETC<Publication>("Publications"));
            builder.ApplyConfiguration(new BaseETC<PublicationKeywordAssociation>("PublicationKeywordAssociations"));
            builder.ApplyConfiguration(new BaseETC<RepoCrawlingJob>("RepoCrawlingJobs"));
            builder.ApplyConfiguration(new BaseETC<Repository>("Repositories"));
            builder.ApplyConfiguration(new BaseETC<Statistics>("Statistics"));
            builder.ApplyConfiguration(new BaseETC<ToolCategoryAssociation>("ToolCategoryAssociations"));
            builder.ApplyConfiguration(new BaseETC<ToolDownloadRecord>("ToolDownloadRecords"));
            builder.ApplyConfiguration(new BaseETC<ToolPublicationAssociation>("ToolPublicationAssociations"));
            builder.ApplyConfiguration(new BaseETC<ToolRepoAssociation>("ToolRepoAssociations"));
        }
    }
}
