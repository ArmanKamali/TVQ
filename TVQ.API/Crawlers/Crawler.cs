﻿using Genometric.TVQ.API.Infrastructure;
using Genometric.TVQ.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Genometric.TVQ.API.Model.Repository;

namespace Genometric.TVQ.API.Crawlers
{
    public class Crawler
    {
        private readonly TVQContext _dbContext;
        private readonly ILogger _logger;

        public Crawler(
            TVQContext dbContext,
            ILogger<Crawler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task CrawlAsync(Repository repo, CancellationToken cancellationToken)
        {
            // TODO: check if another async operation is ongoing, if so, wait for that to finish before running this. 
            try
            {
                ToolRepoCrawler crawler;
                switch (repo.Name)
                {
                    case Repo.ToolShed:
                        crawler = new ToolShed(repo);
                        break;

                    case Repo.BioTools:
                        crawler = new BioTools(repo);
                        break;

                    case Repo.Bioconductor:
                        crawler = new Bioconductor(repo);
                        break;

                    default:
                        /// TODO: replace with an exception.
                        return;
                }

                if (!_dbContext.Repositories.Local.Any(e => e.ID == repo.ID))
                    _dbContext.Attach(repo);

                crawler.Tools =
                    new ConcurrentDictionary<string, Tool>(
                        repo.Tools.ToDictionary(
                            x => x.Name, x => x));

                await crawler.ScanAsync().ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                crawler.Dispose();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // TODO log this.
                throw;
            }
            catch(DbUpdateException e)
            {
                // TODO log this. 
                throw;
            }
        }
    }
}
