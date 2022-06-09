﻿using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public FinishProjectCommandHandler(DevFreelaDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Finish();
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
