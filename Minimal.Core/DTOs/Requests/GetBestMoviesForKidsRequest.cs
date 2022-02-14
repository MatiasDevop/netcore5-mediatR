using MediatR;
using Minimal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Core.Requests
{
    public class GetBestMoviesForKidsRequest : IRequest<BaseResponseDto<List<MovieDto>>>
    {
    }
}
