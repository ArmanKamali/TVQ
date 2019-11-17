﻿using Genometric.TVQ.API.Infrastructure;
using Genometric.TVQ.API.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Genometric.TVQ.API.Analysis
{
    public class AnalysisService
    {
        private readonly TVQContext _dbContext;
        private readonly ILogger<AnalysisService> _logger;

        public AnalysisService(
            TVQContext dbContext,
            ILogger<AnalysisService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task UpdateStatsAsync(Repository repository, CancellationToken cancellationToken)
        {
            if (repository == null) return;

            EvaluateCitationImpact(repository);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private void EvaluateCitationImpact(Repository repository)
        {
            var citations = new Dictionary<int, int[]>();
            foreach (var tool in repository.Tools)
            {
                var toolAddedToRepoDate = DateTime.Now;
                foreach (var pub in tool.Publications)
                {
                    if (!citations.ContainsKey(tool.ID))
                        citations.Add(tool.ID, new int[2]);

                    if (pub.Citations != null)
                        foreach (var citation in pub.Citations)
                            if (citation.Date < toolAddedToRepoDate)
                                citations[tool.ID][0]++;
                            else
                                citations[tool.ID][1]++;
                }
            }

            repository.Statistics.TValue =
                InferentialStatistics.TTest(
                    citations.Values.Select(x => x[0]).ToList(),
                    citations.Values.Select(x => x[1]).ToList());
        }
    }
}
