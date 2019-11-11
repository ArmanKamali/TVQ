﻿using Genometric.TVQ.API.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Genometric.TVQ.API.Infrastructure.BackgroundTasks
{
    public interface IBackgroundToolRepoCrawlingQueue
    {
        void QueueBackgroundWorkItem(Repository repository);

        Task<Repository> DequeueAsync(CancellationToken cancellationToken);
    }
}