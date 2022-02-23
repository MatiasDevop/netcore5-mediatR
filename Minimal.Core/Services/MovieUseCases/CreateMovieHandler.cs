using MediatR;
using Microsoft.Extensions.Logging;
using Minimal.Core.DTOs;
using Minimal.Core.Interfaces;
using Minimal.Core.Models;
using Minimal.Core.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Minimal.Core.Services.MovieUseCases
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieRequest, BaseResponseDto<bool>>
    {
        private readonly IRepository<Movie> _repository;
        private readonly ILogger<CreateMovieHandler> _logger;
        private readonly IMediator _mediator;

        public CreateMovieHandler(IRepository<Movie> repository, ILogger<CreateMovieHandler> logger, IMediator mediator)
        {
            _repository = repository;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<BaseResponseDto<bool>> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            BaseResponseDto<bool> response = new BaseResponseDto<bool>();

            try
            {
                var movie = new Movie
                {
                    Name = request.Name,
                    Rating = request.Rating,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now
                };

                await _repository.CreateAsync(movie);
                response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error ocurred while creating the movie.");
            }

            return response;
        }
    }
}
