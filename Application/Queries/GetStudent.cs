using Application.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetStudent
    {
        public record GetStudentQuery(Guid Id):IRequest<GetstudentResponse>;
        public record GetstudentResponse(Guid Id, string Name, string Email, string Phone);

        public class Handler : IRequestHandler<GetStudentQuery , GetstudentResponse>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<GetstudentResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
            {
                var getStudent = await _studentRepository.GetStudentAsync(x => x.Id == request.Id);
                if (getStudent == null) {
                    throw new Exception("student not found");
                }

                return getStudent.Adapt<GetstudentResponse>();
            }
        }
    }
}
