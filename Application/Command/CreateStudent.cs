using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class CreateStudent
    {
        public record CreateStudentCommand(string Name, string Email, string Phone):IRequest<StudentResponse>;
        public record StudentResponse(Guid Id, string Name, string Email, string Phone);

        public class Handler : IRequestHandler<CreateStudentCommand, StudentResponse>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                var checkExist = await _studentRepository.GetStudentAsync(x => x.Name == request.Name);
                if(checkExist != null)
                {
                    throw new Exception("student name already exist");
                }

                Student student = new Student(request.Name, request.Email, request.Phone);
                await _studentRepository.CreateStudentAsync(student);
                await _unitOfWork.SaveAsync();

                return student.Adapt<StudentResponse>();
            }
        }
    }
}
