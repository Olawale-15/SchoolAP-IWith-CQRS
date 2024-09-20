using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllStudents
    {
        public record GetAllStudentQueries(): IRequest<IReadOnlyList<GetaAllStudentsResponse>>;
        public record GetaAllStudentsResponse(Guid Id, string Name, string Eamil, string Phone);

        public class Handler : IRequestHandler<GetAllStudentQueries, IReadOnlyList<GetaAllStudentsResponse>>
        {
            private readonly IStudentRepository _studentRepository;

            public Handler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<IReadOnlyList<GetaAllStudentsResponse>> Handle(GetAllStudentQueries request, CancellationToken cancellationToken)
            {
                IReadOnlyList<Student> getStudents = await _studentRepository.GetAllAsync();
                return getStudents.Adapt<IReadOnlyList<GetaAllStudentsResponse>>();
            }
        }
    }
}
