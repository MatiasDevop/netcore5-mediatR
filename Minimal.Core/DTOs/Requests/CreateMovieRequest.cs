using MediatR;
using Minimal.Core.DTOs;

namespace Minimal.Core.Requests
{
    public class CreateMovieRequest : IRequest<BaseResponseDto<bool>>
    {
        public string Name { get; set; }
        public double Rating { get; set; }
    }
}
