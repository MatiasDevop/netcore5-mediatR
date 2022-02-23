using MediatR;
using Minimal.Core.DTOs;
using System.Collections.Generic;

namespace Minimal.Core.Requests
{
    public class GetBestMoviesForKidsRequest : IRequest<BaseResponseDto<List<MovieDto>>>
    {
    }
}
